﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Interop;

namespace Ingeloop.WPF.Core
{
    public static class DialogService
    {
        private readonly static List<string> resourcesToCopy = new List<string> { "Primary", "PrimaryBrush", "Secondary", "SecondaryBrush" };
        public static Window DialogHost { get; private set; }

        public static readonly DependencyProperty DialogHostProperty = DependencyProperty.RegisterAttached("DialogHost",
        typeof(bool), typeof(DialogService), new PropertyMetadata(DialogHostChanged));

        public static bool GetDialogHost(DependencyObject target)
        {
            return (bool)target.GetValue(DialogHostProperty);
        }

        public static void SetDialogHost(DependencyObject target, bool value)
        {
            target.SetValue(DialogHostProperty, value);
        }

        private static Dictionary<string, Type> WindowsTypesCache = new Dictionary<string, Type>();

        private static void DialogHostChanged(DependencyObject target, DependencyPropertyChangedEventArgs e)
        {
            if (DesignerProperties.GetIsInDesignMode(target))
                return;

            if ((bool)e.NewValue)
            {
                DialogHost = Window.GetWindow(target);
                if (DialogHost == null)
                {
                    ((Control)target).Loaded += (o, re) => DialogHost = Window.GetWindow(target);
                }

                Assembly uiAssembly = target.GetType().Assembly;
                List<Assembly> assembliesSource = new List<Assembly> { uiAssembly };
                assembliesSource.AddRange(AppDomain.CurrentDomain.GetAssemblies()
                    .Where(x => x.GetName().Name.StartsWith(nameof(Ingeloop))));

                List<Type> windowsTypes = new List<Type>();
                foreach (Assembly assembly in assembliesSource)
                {
                    windowsTypes.AddRange(assembly.GetTypes().ToList().FindAll(x => x.IsSubclassOf(typeof(Window))));
                }

                WindowsTypesCache.Clear();
                foreach (Type windowsType in windowsTypes)
                {
                    string viewModelType = $"{windowsType.Name}ViewModel";
                    if (!WindowsTypesCache.ContainsKey(viewModelType))
                    {
                        WindowsTypesCache.Add(viewModelType, windowsType);
                    }
                }
            }
        }

        internal static bool? ShowDialog(DialogViewModel dialogViewModel)
        {
            var viewModelKey = dialogViewModel.GetType().Name;
            if (!WindowsTypesCache.TryGetValue(viewModelKey, out Type windowType))
            {
                return null;
            }

            if (!(Activator.CreateInstance(windowType) is Window dialogWindow))
            {
                return null;
            }

            foreach (string resourceToCopy in resourcesToCopy)
            {
                object resourceValue = DialogHost?.TryFindResource(resourceToCopy);
                if (resourceValue != null)
                {
                    dialogWindow.Resources[resourceToCopy] = resourceValue;
                }
            }

            //Set Owner (Current Process Main Window, or DialogHost)
            bool ownerWindowFound = false;
            try
            {
                var currentProcess = Process.GetCurrentProcess();
                var mainWindowHandle = currentProcess.MainWindowHandle;
                if (mainWindowHandle != IntPtr.Zero)
                {
                    new WindowInteropHelper(dialogWindow).Owner = mainWindowHandle ;
                }
                ownerWindowFound = true;
            }
            catch { }
            if (!ownerWindowFound)
            {
                dialogWindow.Owner = DialogHost;
            }

            dialogWindow.DataContext = dialogViewModel;

            return dialogWindow.ShowDialog();
        }
    }
}

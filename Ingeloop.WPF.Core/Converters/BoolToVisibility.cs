using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;

namespace Ingeloop.WPF.Core
{
	public class BoolToVisibility : IValueConverter
	{
		public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
		{
			bool targetVisibility = (bool)value;
			if (parameter != null && bool.Parse(parameter.ToString()))
			{
				targetVisibility = !targetVisibility;
			}

			if (targetVisibility)
			{
				return Visibility.Visible;
			}
			else
			{
				return Visibility.Collapsed;
			}
		}

		public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
		{
			return Binding.DoNothing;
		}
	}
}

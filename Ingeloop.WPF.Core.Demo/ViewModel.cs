using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Ingeloop.WPF.Core.Demo
{
    public class ViewModel : BaseViewModel
    {
        private int progress = 0;
        public int Progress
        {
            get
            {
                return progress;
            }
            set
            {
                progress = value;
                OnPropertyChanged(nameof(Progress));
            }
        }

        public ICommand UpdateProgressCommand
        {
            get
            {
                return new RelayCommand(UpdateProgress);
            }
        }

        public ViewModel()
        {
        }

        private async void UpdateProgress()
        {
            for(int i = 0; i <= 100; i++)
            {
                await Task.Delay(10);
                Progress = i;
            }
        }
    }
}

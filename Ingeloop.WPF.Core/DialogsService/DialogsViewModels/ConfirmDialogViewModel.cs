using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ingeloop.WPF.Core
{
    public class ConfirmDialogViewModel : DialogViewModel
    {
        private string message;
        private string okText = "Ok";
        private string cancelText = "Cancel";

        public string Message
        {
            get
            {
                return message;
            }
            set
            {
                message = value;
                OnPropertyChanged(nameof(Message));
            }
        }

        public string OkText
        {
            get
            {
                return okText;
            }
            set
            {
                okText = value;
                OnPropertyChanged(nameof(OkText));
            }
        }

        public string CancelText
        {
            get
            {
                return cancelText;
            }
            set
            {
                cancelText = value;
                OnPropertyChanged(nameof(CancelText));
            }
        }

        public ConfirmDialogViewModel(string title, string message)
        {
            Title = title;
            Message = message;
        }
    }
}

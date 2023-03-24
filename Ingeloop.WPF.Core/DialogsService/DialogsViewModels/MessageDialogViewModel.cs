using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ingeloop.WPF.Core
{
    public class MessageDialogViewModel : DialogViewModel
    {
        private string message;
        private string okText = "Ok";

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

        public MessageDialogViewModel()
        {
        }
    }
}

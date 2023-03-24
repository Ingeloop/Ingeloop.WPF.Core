using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ingeloop.WPF.Core
{
    public class TextInputDialogViewModel : DialogViewModel
    {
        private string message;
        private string text;
        private readonly bool allowsEmpty;
        private bool allowsMultiline;
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

        public string Text
        {
            get
            {
                return text;
            }
            set
            {
                text = value;
                OnPropertyChanged(nameof(Text));
                OnPropertyChanged(nameof(IsOKButtonEnabled));
            }
        }

        public bool AllowsMultiline
        {
            get
            {
                return allowsMultiline;
            }
            set
            {
                allowsMultiline = value;
                OnPropertyChanged(nameof(AllowsMultiline));
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

        public override bool IsOKButtonEnabled => allowsEmpty ? base.IsOKButtonEnabled : !String.IsNullOrEmpty(Text);

        public TextInputDialogViewModel(bool allowsEmpty, bool allowsMultiline = false)
        {
            this.allowsEmpty = allowsEmpty;
            AllowsMultiline = allowsMultiline;
        }
    }
}

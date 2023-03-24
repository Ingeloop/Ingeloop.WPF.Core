using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ingeloop.WPF.Core
{
    public abstract class DialogViewModel : BaseViewModel
    {
        private string title;

        public string Title
        {
            get
            {
                return title;
            }
            set
            {
                title = value;
                OnPropertyChanged(nameof(Title));
            }
        }

        public DialogViewModel()
        {
        }

        public virtual bool IsOKButtonEnabled => true;

        public bool? ShowDialog()
        {
            bool? dialogResult = DialogService.ShowDialog(this);
            return dialogResult;
        }
    }
}

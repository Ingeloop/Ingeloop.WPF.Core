using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace Ingeloop.WPF.Core
{
    public class DateToStringConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value == null) return null;
            Enum.TryParse(parameter.ToString(), out DateFormatting dateFormatting);

            DateTime date = (DateTime)value;
            string formattedDate = null;
            switch (dateFormatting)
            {
                case DateFormatting.Short:
                    {
                        if (date.Date == DateTime.Today)
                        {
                            formattedDate = date.ToString("HH:mm", culture);
                        }
                        else
                        {
                            formattedDate = date.ToString("dd/MM", culture);
                        }
                        break;
                    }
                case DateFormatting.Medium:
                    {
                        if (date.Date == DateTime.Today)
                        {
                            formattedDate = String.Format("Today {0}", date.ToString("HH:mm", culture));
                        }
                        else
                        {
                            formattedDate = date.ToString("dd/MM HH:mm", culture);
                        }
                        break;
                    }
                case DateFormatting.Full:
                    {
                        formattedDate = date.ToString("dd/MM/yyyy HH:mm");
                        break;
                    }
            }
            return formattedDate;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return Binding.DoNothing;
        }
    }

    public enum DateFormatting
    {
        Short,
        Medium,
        Full
    }
}

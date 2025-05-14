using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mads195.MadsMauiLib.Converters
{
    public class DateTimeFormatConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is DateTime dateTime)
            {
                var format = parameter as string;
                return string.IsNullOrEmpty(format) ? dateTime.ToString(culture) : dateTime.ToString(format, culture);
            }

            return value;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is string str && targetType == typeof(DateTime))
            {
                var format = parameter as string;
                if (!string.IsNullOrEmpty(format))
                {
                    if (DateTime.TryParseExact(str, format, culture, DateTimeStyles.None, out var parsed))
                        return parsed;
                }
                else
                {
                    if (DateTime.TryParse(str, culture, DateTimeStyles.None, out var parsed))
                        return parsed;
                }
            }

            return value;
        }
    }
}

using System;
using System.Globalization;
using System.Collections.Generic;
using Microsoft.Maui.Controls;

namespace Mads195.MadsMauiLib.Converters
{
    public class TwoDigitConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is int number)
                return number.ToString("D2");
            return value;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (int.TryParse(value?.ToString(), out int result))
                return result;
            return 0;
        }
    }

}

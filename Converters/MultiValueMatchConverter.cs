using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mads195.MadsMauiLib.Converters
{
    public class MultiValueMatchConverter : IMultiValueConverter
    {
        // Expects the parameter as a comma-separated list of expected values
        // e.g., "Expected1,Expected2,true"
        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            if (values == null || parameter == null)
                return false;

            var expectedValues = parameter.ToString()?.Split(',');

            if (expectedValues == null || expectedValues.Length != values.Length)
                return false;

            for (int i = 0; i < values.Length; i++)
            {
                var current = values[i]?.ToString()?.Trim();
                var expected = expectedValues[i]?.Trim();
                
                if (!string.Equals(current, expected, StringComparison.OrdinalIgnoreCase))
                    return false;
            }

            return true;
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            throw new NotSupportedException("MultiValueMatchConverter does not support ConvertBack.");
        }
    }
}

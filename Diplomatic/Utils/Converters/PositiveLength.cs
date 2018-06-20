using System;
using System.Globalization;
using Xamarin.Forms;

namespace Diplomatic.Utils.Converters
{
    public class PositiveLength : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is int length)
            {
                return length > 0;
            }
            else
            {
                throw new ArgumentException("Invalid argument type.", nameof(value));
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotSupportedException();
        }
    }
}

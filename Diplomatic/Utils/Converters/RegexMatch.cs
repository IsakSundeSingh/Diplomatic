using System;
using System.Globalization;
using System.Text.RegularExpressions;
using Xamarin.Forms;

namespace Diplomatic.Utils.Converters
{
    public class RegexMatch : IValueConverter
    {
        public string Pattern { get; set; } = "";

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is string text)
            {
                return Regex.IsMatch(text, Pattern);
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

using System.Text.RegularExpressions;
using Xamarin.Forms;

namespace Diplomatic.Utils.Behaviors
{
    public class FormatValidator : Behavior<Entry>
    {
        public string Pattern { get; set; } = "";
        protected override void OnAttachedTo(Entry entry)
        {
            entry.TextChanged += ValidateFormat;
            base.OnAttachedTo(entry);
        }

        protected override void OnDetachingFrom(Entry entry)
        {
            entry.TextChanged -= ValidateFormat;
            base.OnDetachingFrom(entry);
        }

        public void ValidateFormat(object sender, TextChangedEventArgs args)
        {
            string text = (sender as Entry).Text;
            var regex = new Regex(Pattern, RegexOptions.Compiled);
            (sender as Entry).TextColor = regex.IsMatch(text) ? Color.Default : Color.Red;
        }
    }
}

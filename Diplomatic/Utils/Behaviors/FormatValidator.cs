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
            var entry = (Entry)sender;
            string text = entry.Text;
            entry.TextColor = Regex.IsMatch(text, Pattern) ? Color.Default : Color.Red;
        }
    }
}

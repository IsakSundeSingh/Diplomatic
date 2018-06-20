using System;

namespace Diplomatic.ViewModels
{
    public class TextFieldViewModel
    {
        // TODO: Get these labels from fields in the given template

        // Place data in these
        public string Name { get; set; }
        public DateTime Date { get; set; } = DateTime.UtcNow;
        public DateTime MaxDate { get; set; } = DateTime.UtcNow;

        // Label fields with these
        public string NameLabel { get; set; } = "Name";
    }
}

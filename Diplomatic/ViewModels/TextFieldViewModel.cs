namespace Diplomatic.ViewModels
{
    using Models;
    public class TextFieldViewModel
    {
        public Template SelectedTemplate { get; set; }
        public TextFieldViewModel(Template selectedTemplate)
        {
            SelectedTemplate = selectedTemplate;
        }
    }
}

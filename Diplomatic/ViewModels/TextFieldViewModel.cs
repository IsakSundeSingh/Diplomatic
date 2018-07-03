namespace Diplomatic.ViewModels
{
    public class TextFieldViewModel
    {
        public Template SelectedTemplate { get; set; }
        public TextFieldViewModel(Template selectedTemplate)
        {
            SelectedTemplate = selectedTemplate;
        }
    }
}

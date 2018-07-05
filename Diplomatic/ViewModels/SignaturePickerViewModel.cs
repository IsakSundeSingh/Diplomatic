using System.Linq;

namespace Diplomatic.ViewModels
{
    using Models;
    using Utils;

    public class SignaturePickerViewModel
    {
        public Signature[] Signatures { get; set; }
        public Template SelectedTemplate { get; set; }

        public SignaturePickerViewModel(Template selectedTemplate)
        {
            SelectedTemplate = selectedTemplate;
            Signatures = new WebSignatureProvider().GetTemplates().ToArray();
        }
    }
}

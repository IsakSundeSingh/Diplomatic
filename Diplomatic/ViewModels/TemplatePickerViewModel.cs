using System.Linq;

namespace Diplomatic.ViewModels
{
    using Models;
    using Utils;

    public class TemplatePickerViewModel
    {
        public Template[] Templates { get; set; }

        public TemplatePickerViewModel()
        {
            Templates = new WebTemplateProvider().GetTemplates().ToArray();
        }
    }
}

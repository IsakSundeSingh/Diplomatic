using System.Linq;
using Diplomatic.Utils;


namespace Diplomatic.ViewModels
{
    public class TemplatePickerViewModel
    {
        public Template[] TemplateList { get; set; }
        public TemplatePickerViewModel()
        {
            TemplateList = new WebTemplateProvider().GetTemplates().ToArray();
        }
    }
}

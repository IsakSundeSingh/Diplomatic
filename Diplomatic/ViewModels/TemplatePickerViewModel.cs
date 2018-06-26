using System.Linq;
using Diplomatic.Core;
using Diplomatic.Utils;


namespace Diplomatic.ViewModels
{
    public class TemplatePickerViewModel
    {
        public Template[] TemplateList { get; set; }
        public TemplatePickerViewModel()
        {
            TemplateList = new ResourceTemplateProvider("templates.json").GetTemplates().ToArray();

        }
    }
}

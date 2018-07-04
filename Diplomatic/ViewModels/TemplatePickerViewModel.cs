using System.Collections.Generic;
using System.Linq;
using Diplomatic.Utils;


namespace Diplomatic.ViewModels
{
    using Models;
    public class TemplatePickerViewModel
    {
        public Template[] Templates { get; set; }
        public TemplatePickerViewModel()
        {
            Templates = new WebTemplateProvider().GetTemplates().ToArray();
        }
    }
}

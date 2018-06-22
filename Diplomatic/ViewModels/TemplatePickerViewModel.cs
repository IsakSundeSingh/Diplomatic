using System;
using System.Collections.Generic;
using System.Linq;
using Diplomatic.Utils;
using Diplomatic.Core;


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

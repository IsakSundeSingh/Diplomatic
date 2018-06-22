using System;
using Diplomatic.Utils;

namespace Diplomatic.ViewModels
{
    public class TemplatePickerViewModel
    {
        public TemplatePickerViewModel()
        {
            var templates = new ResourceTemplateProvider("templates.json").GetTemplates();
        }
    }
}

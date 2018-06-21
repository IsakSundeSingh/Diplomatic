using System.Collections.Generic;

namespace Diplomatic.Core
{
    interface ITemplateProvider
    {
        IEnumerable<Template> GetTemplates();
    }
}

using System.Collections.Generic;
using System.IO;
using System.Linq;
using Diplomatic.Core;
using Newtonsoft.Json;

namespace Diplomatic.Utils
{
    public class ResourceTemplateProvider
    {
        readonly List<Template> templates;
        public IEnumerable<Template> GetTemplates() => templates.Select(t => t);

        public ResourceTemplateProvider(string path)
        {
            var res = new MemoryStream(new ResourceLoader().LoadBinary(path).ToArray());
            using (var r = new StreamReader(res))
            {
                string json = r.ReadToEnd();
                templates = JsonConvert.DeserializeObject<List<Template>>(json, new TemplateConverter());
            }
        }
    }
}

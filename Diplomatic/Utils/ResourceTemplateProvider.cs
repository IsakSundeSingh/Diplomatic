using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Diplomatic.Core;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Linq;

namespace Diplomatic.Utils
{
    public class ResourceTemplateProvider
    {
        private readonly List<Template> templates;
        public IEnumerable<Template> GetTemplates() => templates.Select(t => t);

        public ResourceTemplateProvider(string path)
        {
            byte[] bytes = new ResourceLoader().LoadBinary(path).ToArray();
            string json = System.Text.Encoding.UTF8.GetString(bytes);
            templates = JsonConvert.DeserializeObject<List<Template>>(json);
        }
    }
}

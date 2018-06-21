using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Diplomatic.Core
{
    public class FileTemplateProvider : ITemplateProvider
    {
        private readonly List<Template> templates;

        public FileTemplateProvider(string path)
        {
            if (!File.Exists(path))
                throw new ArgumentException("File not found.", nameof(path));

            using (StreamReader r = new StreamReader(path))
            {
                string json = r.ReadToEnd();
                templates = JsonConvert.DeserializeObject<List<Template>>(json, new TemplateConverter());
            }
        }

        public IEnumerable<Template> GetTemplates()
        {
            return templates.Select(t => t);
        }
    }
}

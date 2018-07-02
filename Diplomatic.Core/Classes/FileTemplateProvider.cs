using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Diplomatic.Core
{
    public class FileTemplateProvider : ITemplateProvider
    {
        readonly List<Template> templates;
        public IEnumerable<Template> GetTemplates() => templates.Select(t => t);

        public FileTemplateProvider(string path)
        {
            if (!File.Exists(path))
                throw new ArgumentException($"File not found: {path}, searching from {Directory.GetCurrentDirectory()}", nameof(path));

            using (var r = new StreamReader(path))
            {
                string json = r.ReadToEnd();
                templates = JsonConvert.DeserializeObject<List<Template>>(json);
            }
        }
    }
}

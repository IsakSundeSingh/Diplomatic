using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;

namespace Diplomatic.Core
{
    [Serializable]
    public class Template
    {
        public string FilePath;
        public string TemplateName;
        public IEnumerable<Field> Fields { get; private set; }
        [JsonIgnore]
        public bool IsValid => Fields.All(f => f.IsValid);

        public Template(string path, string name, IEnumerable<Field> fields)
        {
            FilePath = path;
            TemplateName = name;
            Fields = fields;
        }
    }
}

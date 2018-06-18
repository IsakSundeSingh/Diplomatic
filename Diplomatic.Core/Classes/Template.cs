using System;
using System.Collections.Generic;

namespace Diplomatic.Core
{
    [Serializable]
    public class Template
    {
        public string FilePath;
        public string TemplateName;
        public IEnumerable<Field> Fields;

        public Template(string path, string name, IEnumerable<Field> fields)
        {
            FilePath = path;
            TemplateName = name;
            Fields = fields;
        }
    }



}

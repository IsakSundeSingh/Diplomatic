using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

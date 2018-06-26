using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Diplomatic.Core
{
    [Serializable]
    public class Template
    {
        public string TemplateName { get; set; }
        public string ResourcePath { get; set; }
        [JsonConverter(typeof(ConcreteCollectionTypeConverter<List<IField>, Field, IField>))]
        public IEnumerable<IField> Fields { get; set; }
        public Field Signature { get; set; }

        [JsonIgnore]
        public bool IsValid
        {
            get
            {
                bool hasFields = Fields.AsQueryable().Any();
                bool allFieldsValid = Fields.All(f => f.IsValid);
                return hasFields && allFieldsValid;
            }
        }

        public Template(string name, string resourcePath, IEnumerable<IField> fields)
        {
            TemplateName = name;
            ResourcePath = resourcePath;
            Fields = fields;
        }

        public override string ToString()
        {
            int invalidFields = Fields.Sum((f) => f.IsValid ? 0 : 1);
            string allFieldsValid = invalidFields == 0 ? "All fields valid" : $"{invalidFields} invalid fields";
            return $"{TemplateName} ({allFieldsValid})";
        }
    }
}

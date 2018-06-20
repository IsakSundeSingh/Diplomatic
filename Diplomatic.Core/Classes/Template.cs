﻿using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Diplomatic.Core
{
    [Serializable]
    public class Template
    {
        public string TemplateName;
        [JsonConverter(typeof(ConcreteCollectionTypeConverter<List<IField>, Field, IField>))]
        public IEnumerable<IField> Fields { get; set; }

        [JsonIgnore]
        public ITemplateStream RawTemplate;
        [JsonIgnore]
        public Stream Stream => RawTemplate.Stream;
        [JsonIgnore]
        public bool IsValid
        {
            get
            {
                bool hasFields = Fields.AsQueryable().Any();
                bool allFieldsValid = Fields.All(f => f.IsValid);
                return hasFields &&
                       allFieldsValid &&
                       RawTemplate.IsValid;
            }
        }

        public Template(ITemplateStream rawTemplate)
        {
            RawTemplate = rawTemplate;
        }

        public Template(string name, ITemplateStream rawTemplate, IEnumerable<IField> fields) : this(rawTemplate)
        {
            TemplateName = name;
            Fields = fields;
        }
    }
}

using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;

namespace Diplomatic.Core
{
    public class TemplateConverter : CustomCreationConverter<Template>
    {
        public override Template Create(Type objectType)
        {
            throw new NotImplementedException();
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            var jObject = JObject.Load(reader);

            var path = (string)jObject.Property("FilePath");
            var fileStream = new FileStream(path);
            var template = new Template(fileStream);
            serializer.Populate(jObject.CreateReader(), template);
            return template;
        }
    }

    public class ConcreteCollectionTypeConverter<TEnumerable, TItem, TBaseItem> : JsonConverter
    where TEnumerable : IEnumerable<TBaseItem>, new()
    where TItem : TBaseItem
    {
        public override void WriteJson(
            JsonWriter writer, object value, JsonSerializer serializer)
        {
            serializer.Serialize(writer, value);
        }

        public override object ReadJson(
            JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            var collection = new TEnumerable();
            var items = serializer.Deserialize<IEnumerable<TItem>>(reader);

            return items;
        }

        public override bool CanConvert(Type objectType)
        {
            return typeof(IEnumerable<TBaseItem>).IsAssignableFrom(objectType);
        }
    }
}

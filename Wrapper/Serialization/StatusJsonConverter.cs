using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using PUBGAPIWrapper.Models;
using System;

namespace PUBGAPIWrapper.Serialization
{
    public class StatusJsonConverter : JsonConverter
    {
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            JObject obj = JObject.Load(reader);
            return new Status()
            {
                Id = (string)obj["data"]["id"],
                Type = (string)obj["data"]["type"]
            };
        }

        public override bool CanConvert(Type objectType)
        {
            return true;
        }
    }
}

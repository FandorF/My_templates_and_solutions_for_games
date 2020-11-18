using Newtonsoft.Json;
using System;

namespace Game.Common.Data.Serializer
{
    //класс который десериализует Json/текс в С# классы(объекты .net) и серириализует в обратном порядке.
    public class JsonUtilitySerializer : IObjectStringSerializer
    {
        public object ToObject(string input, Type type)
        {
            var deserialized = JsonConvert.DeserializeObject(input, type);
            return deserialized;
        }

        public string ToString(object input)
        {
            var serialized = JsonConvert.SerializeObject(input);
            return serialized;
        }
    }
}
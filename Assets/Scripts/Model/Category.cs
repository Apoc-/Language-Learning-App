using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using UI;

namespace Model
{
    [Serializable]
    public class Category
    {
        public string Id { get; set; }

        public Translation Name { get; set; }
        
        [JsonConverter(typeof(StringEnumConverter))]
        public ClassType ClassType{ get; set; }
    }
}

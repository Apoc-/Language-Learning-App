using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;

namespace Model
{
    [Serializable]
    public class Alphabet
    {
        public string Id { get; set; }

        [JsonConverter(typeof(StringEnumConverter))]
        public Language Type { get; set; }

        public List<AlphabetEntry> Entries { get; set; }

        public Alphabet()
        {
            Entries = new List<AlphabetEntry>();
        }
    }
}
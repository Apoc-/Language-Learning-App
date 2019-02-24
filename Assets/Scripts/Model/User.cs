using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using Gamification;

namespace Model
{
    [Serializable]
    public class User
    {
        public string Name { get; set; }

        /// <summary>
        /// Xp = Experience Points
        /// </summary>
        public int Xp { get; set; }

        public int Level { get; set; }
        
        [JsonConverter(typeof(StringEnumConverter))]
        public Language LearningLanguage { get; set; }
        
        [JsonConverter(typeof(StringEnumConverter))]
        public Language UiLanguage { get; set; }

        [JsonProperty (ItemConverterType = typeof(StringEnumConverter))]
        public List<TrophyType> Trophies { get; set; }

        public User()
        {
            Trophies = new List<TrophyType>();
        }
    }
}

using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;

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
        public ChosenLanguage LearningLanguage { get; set; }
        
        [JsonConverter(typeof(StringEnumConverter))]
        public ChosenLanguage UiLanguage { get; set; }

        public List<Streak> Streaks { get; set; }

        public List<Trophy> Trophies { get; set; }

        public User()
        {
            Streaks = new List<Streak>();
            Trophies = new List<Trophy>();
        }
    }
}

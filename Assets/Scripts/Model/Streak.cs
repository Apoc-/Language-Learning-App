using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;

namespace Model
{
    [Serializable]
    public class Streak
    {
        public string Id { get; set; }

        [JsonConverter(typeof(StringEnumConverter))]
        public StreakType Type { get; set; }

        public int Duration { get; set; }

        public DateTime LastAction { get; set; }
    }

    [Serializable]
    public enum StreakType
    {
        LearningStreak,
        LoginStreak,
        //not defined yet
    }
}

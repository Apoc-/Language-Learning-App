using System;

namespace Model
{
    public class Streak
    {
        public string ID { get; set; }
        public StreakType Type { get; set; }
        public int Duration { get; set; }
        public DateTime LastAction { get; set; }
    }

    public enum StreakType
    {
        LearningStreak,
        LoginStreak,
        //not defined yet
    }
}

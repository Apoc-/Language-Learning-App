using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.Model
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

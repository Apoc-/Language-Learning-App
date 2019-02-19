using System.Collections.Generic;
using LeitnerSystem;

namespace Model
{
    public class User
    {
        public string Name { get; set; }

        /// <summary>
        /// XP = Experience Points
        /// </summary>
        public int XP { get; set; }

        public int Level { get; set; }
        public ChosenLanguage ChosenLanguage { get; set; }
        public LeitnerState LearnState { get; set; }
        public List<Streak> Streaks { get; set; }
        public List<Trophy> Trophies { get; set; }
    }
}

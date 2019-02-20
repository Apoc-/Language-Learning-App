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

        public ChosenLanguage ChosenLanguage { get; set; }

        public List<Streak> Streaks { get; set; }

        public List<Trophy> Trophies { get; set; }
    }
}

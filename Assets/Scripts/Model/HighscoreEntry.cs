﻿using Assets.Scripts.Model;

namespace Model
{
    public class HighscoreEntry
    {
        /// <summary>
        /// not yet defined what we want here
        /// e.g. error rate, word count, ..?
        /// </summary>
        public string Info { get; set; }
        public int Score { get; set; }
        public User User { get; set; }
    }
}

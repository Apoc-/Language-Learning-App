using Newtonsoft.Json;
using System;

namespace Model
{
    [Serializable]
    public class HighscoreEntry
    {
        /// <summary>
        /// not yet defined what we want here
        /// e.g. error rate, word count, ..?
        /// </summary>
        public string Info { get; set; }

        public int Score { get; set; }
    }
}

using System;
using System.Collections.Generic;

namespace Model
{
    [Serializable]
    public class Alphabet
    {
        public string Id { get; set; }

        public ChosenLanguage Type { get; set; }

        public List<AlphabetEntry> Entries { get; set; }

        public Alphabet()
        {
            Entries = new List<AlphabetEntry>();
        }
    }
}
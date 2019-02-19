﻿using System.Collections.Generic;
using Assets.Scripts.Model;

namespace Model
{
    public class Alphabet
    {
        public string ID { get; set; }
        public ChosenLanguage Type { get; set; }
        public List<AlphabetEntry> Entries { get; set; }

        public Alphabet()
        {
            Entries = new List<AlphabetEntry>();
        }
    }
}
using System.Collections.Generic;

namespace Assets.Scripts.Model
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
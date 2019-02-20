using System;
using System.Collections.Generic;

namespace Model
{
    [Serializable]
    public class Dialogue
    {
        public string Id { get; set; }

        public Translation Name { get; set; }

        public Category Category { get; set; }

        public Dictionary<ChosenLanguage, List<DialogueEntry>> Entries { get; private set; }

        public Dialogue()
        {
            Entries = new Dictionary<ChosenLanguage, List<DialogueEntry>>();
        }
    }
}

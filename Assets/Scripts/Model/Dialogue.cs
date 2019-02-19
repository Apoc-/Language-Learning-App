using System.Collections.Generic;
using Assets.Scripts.Model;

namespace Model
{
    public class Dialogue
    {
        public string ID { get; set; }
        public Translation Name { get; set; }
        public Category Category { get; set; }
        public List<DialogueEntry> Entries { get; private set; }

        public Dialogue()
        {
            Entries = new List<DialogueEntry>();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.Model
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

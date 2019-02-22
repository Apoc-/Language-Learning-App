using System;
using System.Collections.Generic;

namespace Model
{
    [Serializable]
    public class DialogueEntry
    {
        public string Id { get; set; }

        public string Text { get; set; }

        public List<string> WrongAnswers { get; set; }
        
        public AudioData Audio { get; set; }

        public string Bopomofo { get; set; }
    }
}
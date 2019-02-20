using UnityEngine;

namespace Model
{
    public class DialogueEntry
    {
        public string Id { get; set; }
        public string Text { get; set; }
        public AudioClip Audio { get; set; }
        public string Bopomofo { get; set; }
    }
}
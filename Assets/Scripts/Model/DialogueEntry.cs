using Assets.Scripts.Model;
using UnityEngine;

namespace Model
{
    public class DialogueEntry
    {
        public string ID { get; set; }
        public Translation Translation { get; set; }
        public AudioClip Audio { get; set; }
        public string Bopomofo { get; set; }
    }
}
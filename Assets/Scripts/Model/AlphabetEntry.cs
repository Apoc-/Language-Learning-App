using UnityEngine;

namespace Assets.Scripts.Model
{
    public class AlphabetEntry : LearnItem
    {
        public string ID { get; set; }
        public string character { get; set; }
        public AudioClip ContextFreeAudio { get; set; }
        public AudioClip ContextSensitiveAudio { get; set; }
        public AudioClip ExampleWordAudio { get; set; }
    }
}

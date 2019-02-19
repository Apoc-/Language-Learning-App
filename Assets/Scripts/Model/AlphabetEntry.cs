using LeitnerSystem;
using UnityEngine;

namespace Model
{
    public class AlphabetEntry : LearnItem
    {
        public string character { get; set; }
        public AudioClip ContextFreeAudio { get; set; }
        public AudioClip ContextSensitiveAudio { get; set; }
        public AudioClip ExampleWordAudio { get; set; }
    }
}

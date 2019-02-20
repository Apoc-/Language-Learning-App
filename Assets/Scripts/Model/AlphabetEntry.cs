using LeitnerSystem;
using System;

namespace Model
{
    [Serializable]
    public class AlphabetEntry : LearnItem
    {
        public string Character { get; set; }

        public AudioData ContextFreeAudio { get; set; }

        public AudioData ContextSensitiveAudio { get; set; }

        public AudioData ExampleWordAudio { get; set; }
    }
}

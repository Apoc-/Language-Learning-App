using UnityEngine;

namespace LeitnerSystem
{
    public class AudioQuestion : Question
    {
        public AudioClip AudioClip { get; }

        public AudioQuestion(AudioClip audioClip)
        {
            AudioClip = audioClip;
        }
    }
}
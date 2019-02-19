using UnityEngine;

namespace LeitnerSystem
{
    public class Question
    {
        public string Text { get; }
        public AudioClip AudioClip { get; }

        public Question(string text, AudioClip audioClip = null)
        {
            Text = text;
            AudioClip = audioClip;
        }

        public bool HasAudioClip()
        {
            return AudioClip != null;
        }
    }
}
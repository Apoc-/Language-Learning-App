using UnityEngine;

namespace LeitnerSystem
{
    public class AudioAnswer : Answer
    {
        public AudioClip AudioClip { get; }

        public AudioAnswer(AudioClip audioClip, bool isCorrectAnswer)
        {
            AudioClip = audioClip;
            _isCorrectAnswer = isCorrectAnswer;
        }
    }
}
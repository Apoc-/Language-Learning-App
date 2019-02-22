using System;

namespace LeitnerSystem
{
    public abstract class Answer
    {
        protected bool _isCorrectAnswer = false;

        public bool IsCorrectAnswer()
        {
            return _isCorrectAnswer;
        }

        public ImageAnswer AsImageAnswer()
        {
            return (ImageAnswer) this;
        }

        public TextAnswer AsTextAnswer()
        {
            return (TextAnswer) this;
        }

        public AudioAnswer AsAudioAnswer()
        {
            return (AudioAnswer) this;
        }
    }
}
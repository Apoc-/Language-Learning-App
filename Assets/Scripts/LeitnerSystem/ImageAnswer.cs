using UnityEngine;

namespace LeitnerSystem
{
    public class ImageAnswer : Answer
    {
        public Sprite Image { get; }

        public ImageAnswer(Sprite image, bool isCorrectAnswer)
        {
            Image = image;
            _isCorrectAnswer = isCorrectAnswer;
        }
    }
}
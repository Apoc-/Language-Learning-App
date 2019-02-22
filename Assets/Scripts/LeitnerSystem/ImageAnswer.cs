using UnityEngine;

namespace LeitnerSystem
{
    public class ImageAnswer : Answer
    {
        public Texture2D Image { get; }

        public ImageAnswer(Texture2D image, bool isCorrectAnswer)
        {
            Image = image;
            _isCorrectAnswer = isCorrectAnswer;
        }
    }
}
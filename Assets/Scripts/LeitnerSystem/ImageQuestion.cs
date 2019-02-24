using UnityEngine;

namespace LeitnerSystem
{
    public class ImageQuestion : Question
    {
        public Sprite Image { get; }

        public ImageQuestion(Sprite image)
        {
            Image = image;
        }
    }
}
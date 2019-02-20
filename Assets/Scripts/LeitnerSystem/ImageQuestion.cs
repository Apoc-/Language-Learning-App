using UnityEngine;

namespace LeitnerSystem
{
    public class ImageQuestion : Question
    {
        public Texture2D Image { get; }

        public ImageQuestion(Texture2D image)
        {
            Image = image;
        }
    }
}
using UnityEngine;

namespace LeitnerSystem
{
    public class TextQuestion : Question
    {
        public string Text { get; }

        public TextQuestion(string text)
        {
            Text = text;
        }
    }
}
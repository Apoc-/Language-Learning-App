namespace LeitnerSystem
{
    public class TextAnswer : Answer
    {
        public string Text { get; }
        
        public TextAnswer(string text, bool isCorrectAnswer)
        {
            Text = text;
            _isCorrectAnswer = isCorrectAnswer;
        }
    }
}
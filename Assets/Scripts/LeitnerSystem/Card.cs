using System.Collections.Generic;
using UnityEngine;

namespace LeitnerSystem
{
    public class Card
    {
        public Question Question { get; set; }
        private readonly List<Answer> _answers;
        public string LearnItemId { get; }
        public bool AnsweredCorrectly { get; private set; }
        public CardFormat CardFormat { get; set; }

        public Card(string learnItemId)
        {
            LearnItemId = learnItemId;
            _answers = new List<Answer>();
        }

        public void AddAnswer(Answer answer)
        {
            _answers.Add(answer);
        }

        /// <summary>
        /// Answers the card.
        /// </summary>
        /// <param name="answer">The by the user given answer</param>
        /// <returns>True if answer was correct</returns>
        public bool AnswerWith(Answer answer)
        {
            AnsweredCorrectly = _answers.Contains(answer) && answer.IsCorrectAnswer();

            return AnsweredCorrectly;
        }

        /// <summary>
        /// Returns the correct answer to this card's question.
        /// </summary>
        /// <returns>Correct answer</returns>
        public Answer GetCorrectAnswer()
        {
            return _answers.Find(a => a.IsCorrectAnswer());
        }
    }
}
using System.Collections.Generic;
using UnityEngine;

namespace LeitnerSystem
{
    public class Card
    {
        public Question Question { get; }
        private readonly List<Answer> _answers;
        public string LearnItemId { get; }
        public bool AnsweredCorrectly { get; private set; }

        public Card(string learnItemId, Question question, List<Answer> answers)
        {
            LearnItemId = learnItemId;
            Question = question;
            _answers = answers;
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
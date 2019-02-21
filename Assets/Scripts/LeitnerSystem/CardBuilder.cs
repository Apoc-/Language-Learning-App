using UnityEngine;
using UnityEngine.UI;

namespace LeitnerSystem
{
    public class CardBuilder
    {
        private Card card; 
        
        private CardBuilder(string learnItemId)
        {
            card = new Card(learnItemId);
        }

        public static CardBuilder Create(string learnItemId)
        {
            return new CardBuilder(learnItemId);
        }

        public CardBuilder WithCardFormat(CardFormat format)
        {
            card.CardFormat = format;
            return this;
        }
        
        public CardBuilder WithTextQuestion(string text)
        {
            card.Question = new TextQuestion(text);
            return this;
        }

        public CardBuilder WithImageQuestion(Texture2D image)
        {
            card.Question = new ImageQuestion(image);
            return this;
        }

        public CardBuilder WithAudioQuestion(AudioClip audio)
        {
            card.Question = new AudioQuestion(audio);
            return this;
        }

        public CardBuilder AddTextAnswer(string text, bool correctAnswer)
        {
            card.AddAnswer(new TextAnswer(text, correctAnswer));
            return this;
        }
        
        public CardBuilder AddImageAnswer(Texture2D image, bool correctAnswer)
        {
            card.AddAnswer(new ImageAnswer(image, correctAnswer));
            return this;
        }
        
        public CardBuilder AddAudioAnswer(AudioClip audio, bool correctAnswer)
        {
            card.AddAnswer(new AudioAnswer(audio, correctAnswer));
            return this;
        }

        public Card End()
        {
            return card;
        }
    }
}
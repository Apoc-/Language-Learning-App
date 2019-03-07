using System.Collections.Generic;
using System.Linq;
using Model;
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

        public CardBuilder WithImageQuestion(Sprite image)
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

        public CardBuilder AddImageAnswer(Sprite image, bool correctAnswer)
        {
            card.AddAnswer(new ImageAnswer(image, correctAnswer));
            return this;
        }

        public CardBuilder AddAudioAnswer(AudioClip audio, bool correctAnswer)
        {
            card.AddAnswer(new AudioAnswer(audio, correctAnswer));
            return this;
        }

        public CardBuilder AddImageAnswers(Sprite askedImage, List<Sprite> wrongImages)
        {
            AddImageAnswer(askedImage, true);
            AddImageAnswer(wrongImages[0], false);
            AddImageAnswer(wrongImages[1], false);
            
            return this;
        }

        public CardBuilder AddTextAnswers(string askedAnswer, List<string> wrongAnswers)
        {
            AddTextAnswer(askedAnswer, true);
            AddTextAnswer(wrongAnswers[0], false);
            AddTextAnswer(wrongAnswers[1], false);
            
            return this;
        }

        public CardBuilder AddAudioAnswers(AudioClip askedAudio, List<AudioClip> wrongAudio)
        {
            AddAudioAnswer(askedAudio, true);
            AddAudioAnswer(wrongAudio[0], false);
            AddAudioAnswer(wrongAudio[1], false);

            return this;
        }


        public Card End()
        {
            return card;
        }
    }
}
using System;
using System.Collections.Generic;
using Model;
using UnityEditor.U2D;

namespace LeitnerSystem
{
    public class VocabCardFactory
    {
        public Card CreateCard(Vocabulary askedVocab, List<Vocabulary> wrongVocab)
        {
            var format = GetRandomCardFormat();

            var cardBuilder = CardBuilder.Create(askedVocab.Id).WithCardFormat(format);
            
            switch (format)
            {
                case CardFormat.ForeignTextToLocalText:
                    AddForeignLanguageTextQuestion(cardBuilder, askedVocab);
                    AddLocalLanguageTextAnswers(cardBuilder, askedVocab, wrongVocab);
                    break;
                case CardFormat.ForeignTextToImage:
                    AddForeignLanguageTextQuestion(cardBuilder, askedVocab);
                    AddImageAnswers(cardBuilder, askedVocab, wrongVocab);
                    break;
                case CardFormat.LocalTextToForeignText:
                    break;
                case CardFormat.LocalTextToForeignAudio:
                    break;
                case CardFormat.ImageToForeignText:
                    break;
                case CardFormat.ForeignAudioToLocalText:
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }

            return cardBuilder.End();
        }

        private void AddImageAnswers(CardBuilder cardBuilder, Vocabulary askedVocab, List<Vocabulary> wrongVocab)
        {
            cardBuilder
                .AddImageAnswer(askedVocab.Image.Image, true)
                .AddImageAnswer(wrongVocab[0].Image.Image, false)
                .AddImageAnswer(wrongVocab[1].Image.Image, false);
        }
        
        private void AddForeignLanguageTextQuestion(CardBuilder cardBuilder, Vocabulary askedVocab)
        {
            cardBuilder.WithTextQuestion(GetForeignLanguageTranslation(askedVocab));
        }

        private void AddLocalLanguageTextAnswers(CardBuilder cardBuilder, Vocabulary askedVocab, List<Vocabulary> wrongVocab)
        {
            cardBuilder
                .AddTextAnswer(GetLocalLanguageTranslation(askedVocab), true)
                .AddTextAnswer(GetLocalLanguageTranslation(wrongVocab[0]), false)
                .AddTextAnswer(GetLocalLanguageTranslation(wrongVocab[1]), false);
        }

        private string GetForeignLanguageTranslation(Vocabulary vocab)
        {
            //todo ask for current language
            //todo maybe we should use a dict here too
            var lang = ChosenLanguage.Taiwanese;
            
            return lang == ChosenLanguage.German ? vocab.Translation.German : vocab.Translation.Taiwanese;
        }

        private string GetLocalLanguageTranslation(Vocabulary vocab)
        {
            //todo ask for current language
            //todo maybe we should use a dict here too
            var lang = ChosenLanguage.German;
            return lang == ChosenLanguage.German ? vocab.Translation.Taiwanese : vocab.Translation.German;
        }

        private CardFormat GetRandomCardFormat()
        {
            CardFormat[] possibleFormats =
            {
                CardFormat.ForeignTextToLocalText,
                CardFormat.ForeignTextToImage,
                CardFormat.LocalTextToForeignText,
                CardFormat.LocalTextToForeignAudio,
                CardFormat.ImageToForeignText,
                CardFormat.ForeignAudioToLocalText
            };

            var rand = Helpers.NextInt(0, possibleFormats.Length);

            return possibleFormats[rand];
        }
    }
}
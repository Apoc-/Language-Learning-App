using System;
using System.Collections.Generic;
using System.Linq;
using Gamification;
using Model;
using UnityEngine;
using UnityEngine.Assertions.Must;

namespace LeitnerSystem
{
    public class SayingCardFactory
    {
        public static Card CreateCard(Saying askedSaying, List<Saying> wrongSayings)
        {
            var format = GetRandomCardFormat();

            var cardBuilder = CardBuilder.Create(askedSaying.Id).WithCardFormat(format);
            
            switch (GetRandomCardFormat())
            {
                    case CardFormat.ForeignTextToLocalText:
                        return cardBuilder
                            .WithTextQuestion(askedSaying.Text)
                            .AddTextAnswers(askedSaying.Meaning, GetMeanings(wrongSayings))
                            .End();
                    case CardFormat.ForeignTextToForeignAudio:
                        return cardBuilder
                            .WithTextQuestion(askedSaying.Text)
                            .AddAudioAnswers(askedSaying.Audio.Audio, GetAudios(wrongSayings))
                            .End();
                    case CardFormat.ForeignAudioToForeignText:
                        return cardBuilder
                            .WithAudioQuestion(askedSaying.Audio.Audio)
                            .AddTextAnswers(askedSaying.Text, GetTexts(wrongSayings))
                            .End();
                    case CardFormat.ForeignAudioToLocalText:
                        return cardBuilder
                            .WithAudioQuestion(askedSaying.Audio.Audio)
                            .AddTextAnswers(askedSaying.Meaning, GetMeanings(wrongSayings))
                            .End();
                        
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        private static List<string> GetTexts(List<Saying> sayings)
        {
            return sayings.Select(saying => saying.Text).ToList();
        }
        
        private static List<string> GetMeanings(List<Saying> sayings)
        {
            return sayings.Select(saying => saying.Meaning).ToList();
        }

        private static List<AudioClip> GetAudios(List<Saying> sayings)
        {
            return sayings.Select(saying => saying.Audio.Audio).ToList();
        }
        
        private static CardFormat GetRandomCardFormat()
        {
            CardFormat[] possibleFormats =
            {
                CardFormat.ForeignTextToLocalText,
                CardFormat.ForeignTextToForeignAudio,
                CardFormat.ForeignAudioToForeignText,
                CardFormat.ForeignAudioToLocalText
            };

            var rand = Helpers.NextInt(0, possibleFormats.Length);

            return possibleFormats[rand];
        }
    }
}
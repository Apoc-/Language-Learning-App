using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Security.Cryptography;
using Model;
using UnityEngine;
using Random = System.Random;

namespace LeitnerSystem
{
    public class AlphabetCardFactory
    {
        public static Card CreateCard(AlphabetEntry questionEntry, List<AlphabetEntry> wrongAnswerEntries)
        {
            switch (GetRandomCardFormat())
            {
                case CardFormat.ForeignTextToForeignAudio:
                    return CreateCardWithTextQuestion(questionEntry, wrongAnswerEntries);
                case CardFormat.ForeignAudioToForeignText:
                    return CreateCardWithAudioQuestion(questionEntry, wrongAnswerEntries);
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }
        
        private static Card CreateCardWithTextQuestion(AlphabetEntry questionEntry, List<AlphabetEntry> wrongAnswerEntries)
        {
            return CardBuilder
                .Create(questionEntry.Id)
                .WithCardFormat(CardFormat.ForeignTextToForeignAudio)
                .WithTextQuestion(questionEntry.Character)
                .AddAudioAnswers(GetAudio(questionEntry), GetAudios(wrongAnswerEntries))
                .End();
        }

        private static Card CreateCardWithAudioQuestion(AlphabetEntry questionEntry, List<AlphabetEntry> wrongAnswerEntries)
        {
            return CardBuilder
                .Create(questionEntry.Id)
                .WithCardFormat(CardFormat.ForeignAudioToForeignText)
                .WithAudioQuestion(GetAudio(questionEntry))
                .AddTextAnswer(questionEntry.Character, true)
                .AddTextAnswer(wrongAnswerEntries[0].Character, true)
                .AddTextAnswer(wrongAnswerEntries[1].Character, true)
                .End();
        }
        
        
        private static AudioClip GetAudio(AlphabetEntry entry)
        {
            return entry.ContextFreeAudio.Audio;
        }

        private static List<AudioClip> GetAudios(List<AlphabetEntry> entries)
        {
            return entries.Select(entry => entry.ContextFreeAudio.Audio).ToList();
        }

        private static CardFormat GetRandomCardFormat()
        {
            CardFormat[] possibleFormats =
            {
                CardFormat.ForeignTextToForeignAudio, 
                CardFormat.ForeignAudioToForeignText
            };
            
            var rand = Helpers.NextInt(0, possibleFormats.Length);

            return possibleFormats[rand];
        }
        
    }
}
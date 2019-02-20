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
            var rand = Helpers.NextInt(0, 2);

            if (rand == 0)
            {
                return CreateCardWithAudioQuestion(questionEntry, wrongAnswerEntries);
            }

            return CreateCardWithTextQuestion(questionEntry, wrongAnswerEntries);
        }
        
        private static Card CreateCardWithTextQuestion(AlphabetEntry questionEntry, List<AlphabetEntry> wrongAnswerEntries)
        {
            return CardBuilder
                .Create(questionEntry.Id, CardFormat.ForeignTextToForeignAudio)
                .WithTextQuestion(questionEntry.character)
                .AddAudioAnswer(questionEntry.ContextFreeAudio, true)
                .AddAudioAnswer(wrongAnswerEntries[1].ContextFreeAudio, false)
                .AddAudioAnswer(wrongAnswerEntries[2].ContextFreeAudio, false)
                .End();
        }
        
        private static Card CreateCardWithAudioQuestion(AlphabetEntry questionEntry, List<AlphabetEntry> wrongAnswerEntries)
        {
            return CardBuilder
                .Create(questionEntry.Id, CardFormat.ForeignAudioToForeignText)
                .WithAudioQuestion(questionEntry.ContextFreeAudio)
                .AddTextAnswer(questionEntry.character, true)
                .AddTextAnswer(wrongAnswerEntries[1].character, true)
                .AddTextAnswer(wrongAnswerEntries[2].character, true)
                .End();
        }
        
    }
}
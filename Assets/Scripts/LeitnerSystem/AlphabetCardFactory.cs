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
<<<<<<< HEAD
            return CardBuilder
                .Create(questionEntry.Id, CardFormat.ForeignTextToForeignAudio)
                .WithTextQuestion(questionEntry.character)
                .AddAudioAnswer(questionEntry.ContextFreeAudio, true)
                .AddAudioAnswer(wrongAnswerEntries[1].ContextFreeAudio, false)
                .AddAudioAnswer(wrongAnswerEntries[2].ContextFreeAudio, false)
                .End();
=======
            var askedEntry = entries.First();
            var questionText = "Was bedeutet dieses Zeichen?\n" + askedEntry.Character; //todo localization
            var question = new Question(questionText);

            var answers = new List<Answer>
            {
                new AudioAnswer(askedEntry.ContextFreeAudio.Audio, true),
                new AudioAnswer(entries[1].ContextFreeAudio.Audio, false),
                new AudioAnswer(entries[2].ContextFreeAudio.Audio, false)
            };
            
            return new Card(askedEntry.Id, question, answers);
>>>>>>> b276756425544226ffc45930bf964afcd1b4a29b
        }
        
        private static Card CreateCardWithAudioQuestion(AlphabetEntry questionEntry, List<AlphabetEntry> wrongAnswerEntries)
        {
<<<<<<< HEAD
            return CardBuilder
                .Create(questionEntry.Id, CardFormat.ForeignAudioToForeignText)
                .WithAudioQuestion(questionEntry.ContextFreeAudio)
                .AddTextAnswer(questionEntry.character, true)
                .AddTextAnswer(wrongAnswerEntries[1].character, true)
                .AddTextAnswer(wrongAnswerEntries[2].character, true)
                .End();
=======
            var askedEntry = entries.First();
            var questionText = "Welches Zeichen hörst du?\n"; //todo localization
            var questionAudio = askedEntry.ContextFreeAudio;
            var question = new Question(questionText, questionAudio.Audio);
            
            var answers = new List<Answer>
            {
                new TextAnswer(askedEntry.Character, true),
                new TextAnswer(entries[1].Character, false),
                new TextAnswer(entries[2].Character, false)
            };
            
            return new Card(askedEntry.Id, question, answers);
>>>>>>> b276756425544226ffc45930bf964afcd1b4a29b
        }
        
    }
}
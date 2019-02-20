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
        private static Random rng = new Random(DateTime.Now.Millisecond);
        
        public static Card CreateCard(List<AlphabetEntry> entries)
        {
            var rand = rng.Next(0, 2);

            if (rand == 0)
            {
                return CreateCardWithAudioQuestion(entries);
            }

            return CreateCardWithTextQuestion(entries);
        }
        
        private static Card CreateCardWithTextQuestion(List<AlphabetEntry> entries)
        {
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
        }
        
        private static Card CreateCardWithAudioQuestion(List<AlphabetEntry> entries)
        {
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
        }
        
    }
}
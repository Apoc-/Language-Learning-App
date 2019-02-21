using System;
using System.Collections.Generic;
using System.Linq;
using Model;
using UnityEditor.U2D;
using UnityEngine;

namespace LeitnerSystem
{
    public class VocabCardFactory
    {
        public static Card CreateCard(Vocabulary askedVocab, List<Vocabulary> wrongVocab)
        {
            var format = GetRandomCardFormat();

            var cardBuilder = CardBuilder.Create(askedVocab.Id).WithCardFormat(format);

            switch (format)
            {
                case CardFormat.ForeignTextToLocalText:
                    return cardBuilder
                        .WithTextQuestion(GetForeignTranslation(askedVocab))
                        .AddTextAnswers(GetLocalTranslation(askedVocab), GetLocalTranslations(wrongVocab))
                        .End();
                case CardFormat.ForeignTextToImage:
                    return cardBuilder
                        .WithTextQuestion(GetForeignTranslation(askedVocab))
                        .AddImageAnswers(GetImage(askedVocab), GetImages(wrongVocab))
                        .End();
                case CardFormat.LocalTextToForeignText:
                    return cardBuilder
                        .WithTextQuestion(GetLocalTranslation(askedVocab))
                        .AddTextAnswers(GetForeignTranslation(askedVocab), GetForeignTranslations(wrongVocab))
                        .End();
                case CardFormat.LocalTextToForeignAudio:
                    return cardBuilder
                        .WithTextQuestion(GetLocalTranslation(askedVocab))
                        .AddAudioAnswers(GetForeignAudio(askedVocab), GetForeignAudios(wrongVocab))
                        .End();
                case CardFormat.ImageToForeignText:
                    return cardBuilder
                        .WithImageQuestion(GetImage(askedVocab))
                        .AddTextAnswers(GetForeignTranslation(askedVocab), GetForeignTranslations(wrongVocab))
                        .End();
                case CardFormat.ForeignAudioToLocalText:
                    return cardBuilder
                        .WithAudioQuestion(GetForeignAudio(askedVocab))
                        .AddTextAnswers(GetLocalTranslation(askedVocab), GetLocalTranslations(wrongVocab))
                        .End();
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        private static AudioClip GetForeignAudio(Vocabulary vocab)
        {
            //todo ask for current language
            //todo maybe we should use a dict here too
            var lang = ChosenLanguage.German;

            return vocab.Audio[lang].Audio;
        }

        private static string GetForeignTranslation(Vocabulary vocab)
        {
            //todo ask for current language
            //todo maybe we should use a dict here too
            var lang = ChosenLanguage.German;

            return vocab.Translation[lang];
        }

        private static string GetLocalTranslation(Vocabulary vocab)
        {
            //todo ask for current language
            //todo maybe we should use a dict here too
            var lang = ChosenLanguage.German;

            return vocab.Translation[vocab.Translation.Keys.ToList().First(k => k != lang)];
        }

        private static List<string> GetLocalTranslations(List<Vocabulary> vocabs)
        {
            //todo ask for current language
            //todo maybe we should use a dict here too
            var lang = ChosenLanguage.German;

            return vocabs.Select(item => item.Translation[lang]).ToList();
        }

        private static List<string> GetForeignTranslations(List<Vocabulary> vocabs)
        {
            //todo ask for current language
            //todo maybe we should use a dict here too
            var lang = ChosenLanguage.German;

            return vocabs.Select(item => item.Translation[lang]).ToList();
        }

        private static Texture2D GetImage(Vocabulary vocab)
        {
            return vocab.Image.Image;
        }

        private static List<Texture2D> GetImages(List<Vocabulary> vocabs)
        {
            return vocabs.Select(item => item.Image.Image).ToList();
        }

        private static List<AudioClip> GetForeignAudios(List<Vocabulary> vocabs)
        {
            //todo ask for current language
            //todo maybe we should use a dict here too
            var lang = ChosenLanguage.German;

            return vocabs.Select(item => item.Audio[lang].Audio).ToList();
        }
        
        private static List<AudioClip> GetLocalAudios(List<Vocabulary> vocabs)
        {
            //todo ask for current language
            //todo maybe we should use a dict here too
            var lang = ChosenLanguage.Taiwanese;

            return vocabs.Select(item => item.Audio[lang].Audio).ToList();
        }


        private static CardFormat GetRandomCardFormat()
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
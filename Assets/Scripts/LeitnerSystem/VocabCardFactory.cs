using System;
using System.Collections.Generic;
using Model;

namespace LeitnerSystem
{
    public class VocabCardFactory
    {
        public Card CreateCard(Vocabulary askedVocab, List<Vocabulary> wrongVocab)
        {
            var format = GetRandomCardFormat();

            switch (format)
            {
                case CardFormat.ForeignTextToLocalText:
                    break;
                case CardFormat.ForeignTextToImage:
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

            return null;
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
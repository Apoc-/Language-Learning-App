using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Model;

namespace LeitnerSystem
{
    //Leitner system with three boxes
    public class LeitnerSession
    {
        private List<Card> _cards;
        private LearnItemHandler _learnItemHandler;

        private LeitnerSession()
        {
            _cards = new List<Card>();
        }

        public static LeitnerSession CreateSession()
        {
            var session = new LeitnerSession();

            session.InitializeLearnItemHandler();
            
            return session;
        }
        
        #region alphabet cards
        public List<Card> GetAlphabetCards(int amount)
        {
            var boxSizes = BoxSizes(amount);

            var boxOneCards = GetAlphabetCardsFromBoxNr(0, boxSizes[0]);
            var boxTwoCards = GetAlphabetCardsFromBoxNr(1, boxSizes[1]);
            var boxThreeCards = GetAlphabetCardsFromBoxNr(2, boxSizes[2]);
            
            _cards = boxOneCards.Union(boxTwoCards).Union(boxThreeCards).ToList();

            if (_cards.Count >= amount) return _cards;
            
            var additionalNewCards = GetAlphabetCardsWithoutBox(amount - _cards.Count);
            additionalNewCards.ForEach(card =>
            {
                _learnItemHandler.GetLearnItemById(card.LearnItemId).CurrentLeitnerBoxNr = 0;
            });

            return _cards;
        }

        private List<Card> GetAlphabetCardsWithoutBox(int amount)
        {
            return GetAlphabetCardsFromBoxNr(-1, amount);
        }
        
        private List<Card> GetAlphabetCardsFromBoxNr(int boxNr, int amount)
        {
            var cards = new List<Card>();
            var boxItems = GetAlphabetLearnItemFromBoxNr(boxNr);

            var askedItems = boxItems.Shuffle().Take(amount).ToList();
            
            askedItems.ForEach(item =>
            {
                var cleanedList = _learnItemHandler.AlphabetLearnItems.Values.ToList();
                cleanedList.Remove(item);
                
                var wrongAnswers = cleanedList.Shuffle().Take(2).ToList();

                var card = AlphabetCardFactory.CreateCard(item, wrongAnswers);
                cards.Add(card);
            });
            
            return cards;
        }
        
        private List<AlphabetEntry> GetAlphabetLearnItemFromBoxNr(int boxNr)
        {
            return _learnItemHandler.AlphabetLearnItems.Values
                .Where(item => item.CurrentLeitnerBoxNr == boxNr)
                .ToList();
        }
        #endregion

        #region vocab cards
        public List<Card> GetVocabCards(int amount)
        {
            var boxSizes = BoxSizes(amount);

            var boxOneCards = GetVocabCardsFromBoxNr(0, boxSizes[0]);
            var boxTwoCards = GetVocabCardsFromBoxNr(1, boxSizes[1]);
            var boxThreeCards = GetVocabCardsFromBoxNr(2, boxSizes[2]);
            
            _cards = boxOneCards.Union(boxTwoCards).Union(boxThreeCards).ToList();

            if (_cards.Count >= amount) return _cards;
            
            var additionalNewCards = GetVocabCardsWithoutBox(amount - _cards.Count);
            additionalNewCards.ForEach(card =>
            {
                _learnItemHandler.GetLearnItemById(card.LearnItemId).CurrentLeitnerBoxNr = 0;
            });

            return _cards;
        }

        private List<Card> GetVocabCardsWithoutBox(int amount)
        {
            return GetVocabCardsFromBoxNr(-1, amount);
        }
        
        private List<Card> GetVocabCardsFromBoxNr(int boxNr, int amount)
        {
            var cards = new List<Card>();
            var boxItems = GetVocabularyLearnItemsFromBoxNr(boxNr);

            var askedItems = boxItems.Shuffle().Take(amount).ToList();
            
            askedItems.ForEach(item =>
            {
                var cleanedList = _learnItemHandler.VocabularyLearnItems.Values.ToList();
                cleanedList.Remove(item);
                
                var wrongAnswers = cleanedList.Shuffle().Take(2).ToList();

                var card = VocabCardFactory.CreateCard(item, wrongAnswers);
                cards.Add(card);
            });
            
            return cards;
        }
        
        private List<Vocabulary> GetVocabularyLearnItemsFromBoxNr(int boxNr)
        {
            return _learnItemHandler.VocabularyLearnItems.Values
                .Where(item => item.CurrentLeitnerBoxNr == boxNr)
                .ToList();
        }
        #endregion
        
        #region saying cards
        public List<Card> GetSayingCards(int amount)
        {
            var boxSizes = BoxSizes(amount);

            var boxOneCards = GetSayingCardsFromBoxNr(0, boxSizes[0]);
            var boxTwoCards = GetSayingCardsFromBoxNr(1, boxSizes[1]);
            var boxThreeCards = GetSayingCardsFromBoxNr(2, boxSizes[2]);
            
            _cards = boxOneCards.Union(boxTwoCards).Union(boxThreeCards).ToList();

            if (_cards.Count >= amount) return _cards;
            
            var additionalNewCards = GetSayingCardsWithoutBox(amount - _cards.Count);
            additionalNewCards.ForEach(card =>
            {
                _learnItemHandler.GetLearnItemById(card.LearnItemId).CurrentLeitnerBoxNr = 0;
            });

            return _cards;
        }

        private List<Card> GetSayingCardsWithoutBox(int amount)
        {
            return GetSayingCardsFromBoxNr(-1, amount);
        }
        
        private List<Card> GetSayingCardsFromBoxNr(int boxNr, int amount)
        {
            var cards = new List<Card>();
            var boxItems = GetSayingLearnItemsFromBoxNr(boxNr);

            var askedItems = boxItems.Shuffle().Take(amount).ToList();
            
            askedItems.ForEach(item =>
            {
                var cleanedList = _learnItemHandler.SayingLearnItems.Values.ToList();
                cleanedList.Remove(item);
                
                var wrongAnswers = cleanedList.Shuffle().Take(2).ToList();

                var card = SayingCardFactory.CreateCard(item, wrongAnswers);
                cards.Add(card);
            });
            
            return cards;
        }
        
        private List<Saying> GetSayingLearnItemsFromBoxNr(int boxNr)
        {
            return _learnItemHandler.SayingLearnItems.Values
                .Where(item => item.CurrentLeitnerBoxNr == boxNr)
                .ToList();
        }
        #endregion

        #region card helper

        private int[] BoxSizes(int amount)
        {
            var boxOneSize = BoxOneSize(amount);
            var boxTwoSize = BoxTwoSize(amount);
            var boxThreeSize = BoxThreeSize(amount, boxOneSize, boxTwoSize);

            return new[] {boxOneSize, boxTwoSize, boxThreeSize};
        }
        
        private int BoxOneSize(int amount)
        {
            return (int) (amount * (3f/6f)); // 3/6th of the cards are from box 1
        }

        private int BoxTwoSize(int amount)
        {
            return (int) (amount * (2f/6f)); // 2/6th are from box 2
        }

        private int BoxThreeSize(int amount, int boxOneSize, int boxTwoSize)
        {
            return amount - (boxOneSize + boxTwoSize); // 1/6th or the rest, are from box 3
        }

        #endregion
        
        public void FinishSession()
        {
            _cards.ForEach(card =>
            {
                var learnItem = _learnItemHandler.GetLearnItemById(card.LearnItemId);

                if (card.AnsweredCorrectly && learnItem.CurrentLeitnerBoxNr < 2)
                {
                    learnItem.CurrentLeitnerBoxNr += 1;
                }

                if (!card.AnsweredCorrectly && learnItem.CurrentLeitnerBoxNr > 0)
                {
                    learnItem.CurrentLeitnerBoxNr -= 1;
                }
                
            });
        }
        
        private void InitializeLearnItemHandler()
        {
            _learnItemHandler = new LearnItemHandler();
        }
    }
}
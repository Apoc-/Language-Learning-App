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
            var boxOneSize = BoxOneSize(amount);
            var boxTwoSize = BoxTwoSize(amount);
            var boxThreeSize = BoxThreeSize(amount, boxOneSize, boxTwoSize);

            var boxOneCards = GetAlphabetCardsFromBoxNr(0, boxOneSize);
            var boxTwoCards = GetAlphabetCardsFromBoxNr(1, boxTwoSize);
            var boxThreeCards = GetAlphabetCardsFromBoxNr(2, boxThreeSize);
            
            _cards = boxOneCards.Union(boxTwoCards).Union(boxThreeCards).ToList();

            if (_cards.Count >= amount) return _cards;
            
            var newCards = GetAlphabetCardsFromBoxNr(-1, amount - _cards.Count);
            newCards.ForEach(card =>
            {
                _learnItemHandler.GetLearnItemById(card.LearnItemId).CurrentLeitnerBoxNr = 0;
            });

            return _cards;
        }

        private List<Card> GetAlphabetCardsFromBoxNr(int boxNr, int amount)
        {
            var cards = new List<Card>();
            var boxItems = GetAlphabetLearnItemFromBoxNr(boxNr);

            var askedItems = boxItems.Shuffle().Take(amount).ToList();
            var alphabetItems = _learnItemHandler.AlphabetLearnItems;
            
            askedItems.ForEach(item =>
            {
                var cleanedList = alphabetItems.Values.ToList();
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

        

        #endregion

        #region card helper
        
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
            //todo populate LearnItemHandler
            _learnItemHandler = new LearnItemHandler();
        }
    }
}
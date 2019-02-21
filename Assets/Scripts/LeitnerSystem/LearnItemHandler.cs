using System.Collections.Generic;
using System.Linq;
using DataAccess;
using Gamification;
using Model;

namespace LeitnerSystem
{
    public class LearnItemHandler
    {
        public Dictionary<string, AlphabetEntry> AlphabetLearnItems { get; private set; }
        public Dictionary<string, Vocabulary> VocabularyLearnItems { get; private set; }
        public Dictionary<string, Saying> SayingLearnItems { get; private set; }

        private readonly Dictionary<string, ILearnItem> _learnItems = new Dictionary<string, ILearnItem>();

        public LearnItemHandler()
        {
            LoadAlphabetLearnItems();
            LoadVocabularyLearnItems();
            LoadSayingLearnItems();
        }

        public ILearnItem GetLearnItemById(string id)
        {
            return _learnItems[id];
        }

        private void LoadAlphabetLearnItems()
        {
            AlphabetLearnItems = new Dictionary<string, AlphabetEntry>();
            
            var alphabetEntries = DAOFactory.AlphabetDAO
                .LoadAlphabet()
                .Find(a => a.Type == GamificationManager.Instance.User.ChosenLanguage)
                .Entries;
            
            alphabetEntries.ForEach(item =>
            {
                AlphabetLearnItems[item.Id] = item;
                _learnItems[item.Id] = item;
            });
        }
        
        private void LoadVocabularyLearnItems()
        {
            VocabularyLearnItems = new Dictionary<string, Vocabulary>();

            var vocabItems = DAOFactory.VocabularyDAO.LoadVocabulary();
            
            vocabItems.ForEach(item =>
            {
                VocabularyLearnItems[item.Id] = item;
                _learnItems[item.Id] = item;
            });
        }
        
        private void LoadSayingLearnItems()
        {
            SayingLearnItems = new Dictionary<string, Saying>();

            var sayingItems = DAOFactory.SayingDAO
                .LoadSayings()
                .Where(item => item.Language == GamificationManager.Instance.User.ChosenLanguage)
                .ToList();
            
            sayingItems.ForEach(item =>
            {
                SayingLearnItems[item.Id] = item;
                _learnItems[item.Id] = item;
            });
        }
    }
}
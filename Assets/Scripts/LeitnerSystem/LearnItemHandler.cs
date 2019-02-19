using System.Collections.Generic;
using System.Linq;
using Model;

namespace LeitnerSystem
{
    public class LearnItemHandler
    {
        public Dictionary<string, AlphabetEntry> AlphabetLearnItems { get; }
        public Dictionary<string, Saying> SayingsLearnItems { get; }
        public Dictionary<string, Vocabulary> VocabularyLearnItems { get; }
        
        private Dictionary<string, LearnItem> learnItems = new Dictionary<string, LearnItem>();

        public LearnItemHandler()
        {
            //todo load data?
            PopulateLearnItemDictionary();
        }

        public LearnItem GetLearnItemById(string id)
        {
            return learnItems[id];
        }

        private void PopulateLearnItemDictionary()
        {
            AddLearnItemsToDictionary(AlphabetLearnItems.Values.ToList(), learnItems);
            AddLearnItemsToDictionary(SayingsLearnItems.Values.ToList(), learnItems);
            AddLearnItemsToDictionary(VocabularyLearnItems.Values.ToList(), learnItems);
        }

        private void AddLearnItemsToDictionary<T>(List<T> source, Dictionary<string, LearnItem> target) 
            where T : LearnItem
        {
            source.ForEach(entry => { target[entry.Id] = entry; });
        }
    }
}
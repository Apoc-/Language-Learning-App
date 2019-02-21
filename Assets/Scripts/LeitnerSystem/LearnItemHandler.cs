using System.Collections.Generic;
using System.Linq;
using Model;

namespace LeitnerSystem
{
    public class LearnItemHandler
    {
        public Dictionary<string, AlphabetEntry> AlphabetLearnItems { get; private set; }
        public Dictionary<string, Saying> SayingsLearnItems { get; }
        public Dictionary<string, Vocabulary> VocabularyLearnItems { get; }
        
        private Dictionary<string, ILearnItem> learnItems = new Dictionary<string, ILearnItem>();

        public LearnItemHandler()
        {
            //todo load data?
            PopulateLearnItemDictionary();
        }

        public ILearnItem GetLearnItemById(string id)
        {
            return learnItems[id];
        }

        private void PopulateLearnItemDictionary()
        {
            AddLearnItemsToDictionary(AlphabetLearnItems.Values.ToList(), learnItems);
            AddLearnItemsToDictionary(SayingsLearnItems.Values.ToList(), learnItems);
            AddLearnItemsToDictionary(VocabularyLearnItems.Values.ToList(), learnItems);
        }

        private void AddLearnItemsToDictionary<T>(List<T> source, Dictionary<string, ILearnItem> target) 
            where T : ILearnItem
        {
            source.ForEach(entry => { target[entry.Id] = entry; });
        }

        private void LoadAlphabetLearnItems()
        {
            AlphabetLearnItems = new Dictionary<string, AlphabetEntry>();
        }
    }
}
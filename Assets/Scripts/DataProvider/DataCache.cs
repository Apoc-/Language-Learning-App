using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using DataAccess;
using Gamification;
using Model;

namespace DataProvider
{
    public class DataCache
    {
        private DataCache()
        {
            LoadLocalizationData();
        }
        
        #region Translation
        private Dictionary<string, Translation> _translations;
        
        public string GetUiTranslationByKey(string key)
        {
            switch (GamificationManager.Instance.User.UiLanguage)
            {
                case Language.Taiwanese:
                    return _translations[key].Taiwanese;
                case Language.German:
                    return _translations[key].German;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }
        
        private void LoadLocalizationData()
        {
            _translations = new Dictionary<string, Translation>();

            var translationList = DAOFactory.TranslationDAO.LoadTranslations();
            translationList.ForEach(translation => { _translations[translation.Key] = translation; });
        }
        #endregion
        
        #region Alphabet
        private Alphabet _alphabet;
        public Alphabet GetAlphabet()
        {
            if (_alphabet == null)
            {
                _alphabet = DAOFactory.AlphabetDAO
                    .LoadAlphabet()
                    .Find(alphabet => alphabet.Type == GamificationManager.Instance.User.LearningLanguage);    
            }

            return _alphabet;
        }
        #endregion

        #region Dialogues
        //way to much hardcoded stuff, needs to be refactored in the future
        private readonly Dictionary<string, List<Dialogue>> _dialogues = new Dictionary<string, List<Dialogue>>();
        public List<Dialogue> GetDialoguesByCategory(string categoryId)
        {
            if (_dialogues.Count == 0) LoadDialogues();

            return _dialogues[categoryId];
        }

        private void LoadDialogues()
        {
            var dialogues = DAOFactory.DialogueDAO.LoadDialogues();
            var dialogueCategoryIds = new List<string>
            {
                "restaurant", "formal", "smalltalk", "shopping"
            };
            
            dialogueCategoryIds.ForEach(id =>
            {
                _dialogues[id] = dialogues.Where(d => d.Category.Id == id).ToList();
            });
        }
        #endregion
        
        #region Sayings
        private readonly Dictionary<string, List<Saying>> _sayings = new Dictionary<string, List<Saying>>();
        public List<Saying> GetSayingsByCategory(string categoryId)
        {
            if (_sayings.Count == 0) LoadSayings();

            return _sayings[categoryId];
        }

        private void LoadSayings()
        {
            var sayings = DAOFactory.SayingDAO.LoadSayings();
            var sayingCategoryIds = new List<string>
            {
                "birthday", "festivals", "weather", "behaviour"
            };
            
            sayingCategoryIds.ForEach(id =>
            {
                _sayings[id] = sayings.Where(d => d.Category.Id == id).ToList();
            });
        }
        #endregion
        
        #region Vocabulary
        private List<Vocabulary> _vocabulary = new List<Vocabulary>();
        public List<Vocabulary> GetVocabulary()
        {
            if (_vocabulary.Count == 0) _vocabulary = DAOFactory.VocabularyDAO.LoadVocabulary();

            return _vocabulary;
        }
        
        public List<Vocabulary> GetVocabularyByCategory(string categoryId)
        {
            return GetVocabulary()
                .Where(vocab => vocab.Category.Id == categoryId)
                .ToList();
        }
        #endregion
        
        #region Categories
        private Dictionary<string, Category> _categories = new Dictionary<string, Category>();
        public Category GetCategoryById(string categoryId)
        {
            return GetCategories()[categoryId];
        }

        public Dictionary<string, Category> GetCategories()
        {
            if (_categories.Count == 0)
            {
                var catList = DAOFactory.CategoryDAO.LoadCategories();
                catList.ForEach(cat => { _categories[cat.Id] = cat; });
            }

            return _categories;
        }
        #endregion
        
        #region Singleton
        private static DataCache _instance;
        public static DataCache Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new DataCache();
                return _instance;
            }
        }

        #endregion
    }
}
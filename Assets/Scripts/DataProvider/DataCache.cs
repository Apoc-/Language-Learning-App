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
        private Dictionary<string, Translation> _translations;
        
        private DataCache()
        {
            LoadLocalizationData();
        }
        
        private void LoadLocalizationData()
        {
            _translations = new Dictionary<string, Translation>();

            var translationList = DAOFactory.TranslationDAO.LoadTranslations();
            translationList.ForEach(translation => { _translations[translation.Key] = translation; });
        }

        public Alphabet GetAlphabet()
        {
            return DAOFactory.AlphabetDAO
                .LoadAlphabet()
                .Find(alphabet => alphabet.Type == GamificationManager.Instance.User.LearningLanguage);
        }


        public List<Saying> GetSayingsByCategory(string categoryId)
        {
            return DAOFactory.SayingDAO
                .LoadSayings()
                .Where(say => say.Category.Id == categoryId)
                .ToList();
        }

        public List<Dialogue> GetDialoguesByCategory(string categoryId)
        {
            return DAOFactory.DialogueDAO
                .LoadDialogues()
                .Where(dia => dia.Category.Id == categoryId)
                .ToList();
        }
        
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
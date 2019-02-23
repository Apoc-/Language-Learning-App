using System;
using System.Collections.Generic;
using System.Linq;
using DataAccess;
using Gamification;
using Model;

namespace DataProvider
{
    public class DataProvider
    {
        private Dictionary<string, Translation> _translations;
        
        private DataProvider()
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

        public List<Vocabulary> GetVocabularyByCategory(string categoryId)
        {
            return DAOFactory.VocabularyDAO
                .LoadVocabulary()
                .Where(vocab => vocab.Category.Id == categoryId)
                .ToList();
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
        
        #region Singleton
        private static DataProvider _instance;
        public static DataProvider Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new DataProvider();
                return _instance;
            }
        }

        #endregion
    }
}
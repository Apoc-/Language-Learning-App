using System;
using System.Collections.Generic;
using DataAccess;
using Gamification;
using Model;

namespace Language
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
            var lang = GamificationManager.Instance.User.LearningLanguage;
            return DAOFactory.AlphabetDAO
                .LoadAlphabet()
                .Find(alphabet => alphabet.Type == lang);
        }
        
        public string GetTranslationByKey(string key)
        {
            switch (GamificationManager.Instance.User.UiLanguage)
            {
                case Model.Language.Taiwanese:
                    return _translations[key].Taiwanese;
                case Model.Language.German:
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
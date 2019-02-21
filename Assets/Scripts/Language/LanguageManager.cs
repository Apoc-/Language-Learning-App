using System;
using System.Collections.Generic;
using DataAccess;
using Gamification;
using Model;

namespace Language
{
    public class LanguageManager
    {
        private Dictionary<string, Translation> _translations;
        
        private LanguageManager()
        {
            LoadLocalizationData();
        }
        
        private void LoadLocalizationData()
        {
            _translations = new Dictionary<string, Translation>();

            var translationList = DAOFactory.TranslationDAO.LoadTranslations();
            translationList.ForEach(translation => { _translations[translation.Key] = translation; });
        }

        private string GetTranslationByKey(string key)
        {
            switch (GamificationManager.Instance.User.UiLanguage)
            {
                case ChosenLanguage.Taiwanese:
                    return _translations[key].Taiwanese;
                case ChosenLanguage.German:
                    return _translations[key].German;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }
        
        #region Singleton
        private static LanguageManager _instance;
        public static LanguageManager Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new LanguageManager();
                return _instance;
            }
        }

        #endregion
    }
}
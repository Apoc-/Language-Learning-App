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
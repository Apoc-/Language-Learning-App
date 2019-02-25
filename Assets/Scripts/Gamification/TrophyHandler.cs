using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using DataAccess;
using Model;
using DataProvider;
using UnityEngine;
using UnityEngine.Networking;

namespace Gamification
{
    public class TrophyHandler
    {
        private readonly Dictionary<TrophyType, Trophy> _trophyDictionary = new Dictionary<TrophyType, Trophy>();
        private List<Trophy> _unearnedTrophies = new List<Trophy>();
        private readonly User _user;
        private string defaultSpritePath = "Icons/iconfinder_advantage_quality_1034364";
        
        public TrophyHandler()
        {
            _user = GamificationManager.Instance.User;
            InitializeTrophyDict();
            InitializeUnearnedTrophies();
            //InitializeTrophyConditions();
        }

        public void CheckTrophyConditions()
        {
            var awardedTrophies = new List<Trophy>();
            _unearnedTrophies.ForEach(tr =>
            {
                if (tr.UnlockCondition.Invoke())
                {
                    _user.Trophies.Add(tr.TrophyType);
                    awardedTrophies.Add(tr);
                    
                    ViewHandler.Instance.ModalDialogueCanvas.EnableTrophyDialogue(tr);
                }
            });

            _unearnedTrophies.RemoveAll(tr => awardedTrophies.Contains(tr));
        }

        private void InitializeTrophyDict()
        {
            _trophyDictionary[TrophyType.Level2] = new Trophy
            {
                TrophyType = TrophyType.Level2,
                UnlockCondition = LevelDependantCondition(2),
                Image = Resources.Load<Sprite>(defaultSpritePath),
                Name = new Translation
                {
                    Key = "Level 2 Trophy",
                    German = "Level 2 Trophäe",
                    Taiwanese = ""
                }
            };
            _trophyDictionary[TrophyType.Level10] = new Trophy
            {
                TrophyType = TrophyType.Level10,
                UnlockCondition = LevelDependantCondition(10),
                Image = Resources.Load<Sprite>(defaultSpritePath),
                Name = new Translation
                {
                    Key = "Level 10 Trophy",
                    German = "Level 10 Trophäe",
                    Taiwanese = ""
                }
            };
            _trophyDictionary[TrophyType.Level20] = new Trophy
            {
                TrophyType = TrophyType.Level20,
                UnlockCondition = LevelDependantCondition(20),
                Image = Resources.Load<Sprite>(defaultSpritePath),
                Name = new Translation
                {
                    Key = "Level 20 Trophy",
                    German = "Level 20 Trophäe",
                    Taiwanese = ""
                }
            };
            _trophyDictionary[TrophyType.AnimalsSeen] = new Trophy
            {
                TrophyType = TrophyType.AnimalsSeen,
                UnlockCondition = LevelDependantCondition(20),
                Image = Resources.Load<Sprite>(defaultSpritePath),
                Name = new Translation
                {
                    Key = "Level 20 Trophy",
                    German = "Level 20 Trophäe",
                    Taiwanese = ""
                }
            };
            _trophyDictionary[TrophyType.VocabSeen] = new Trophy
            {
                TrophyType = TrophyType.VocabSeen,
                UnlockCondition = VocabSeenCondition(),
                Image = Resources.Load<Sprite>(defaultSpritePath),
                Name = new Translation
                {
                    Key = "Vocab Monger",
                    German = "Level 20 Trophäe",
                    Taiwanese = ""
                }
            };
            _trophyDictionary[TrophyType.SayingSeen] = new Trophy
            {
                TrophyType = TrophyType.SayingSeen,
                UnlockCondition = SayingsSeenCondition(),
                Image = Resources.Load<Sprite>(defaultSpritePath),
                Name = new Translation
                {
                    Key = "Saying Seen",
                    German = "Level 20 Trophäe",
                    Taiwanese = ""
                }
            };
            _trophyDictionary[TrophyType.AlphabetSeen] = new Trophy
            {
                TrophyType = TrophyType.AlphabetSeen,
                UnlockCondition = AlphabetSeenCondition(),
                Image = Resources.Load<Sprite>(defaultSpritePath),
                Name = new Translation
                {
                    Key = "Vocab Monger",
                    German = "Level 20 Trophäe",
                    Taiwanese = ""
                }
            };
        }
        
        private void InitializeUnearnedTrophies()
        {
            var trophyKeys = _trophyDictionary.Keys.ToList();
            _user.Trophies.ForEach(trophy => { trophyKeys.Remove(trophy); });
            _unearnedTrophies = trophyKeys.Select(type => _trophyDictionary[type]).ToList();
        }

        public Trophy GetTrophyByType(TrophyType type)
        {
            return _trophyDictionary[type];
        }
        
        // Deprecated
        private void InitializeTrophyConditions()
        {
            _trophyDictionary.Values.ToList()
                .ForEach(tr =>
                {
                    var type = tr.TrophyType;
                    
                    switch (type)
                    {
                        case TrophyType.VocabSeen:
                            tr.UnlockCondition = VocabSeenCondition();
                            break;
                        case TrophyType.SayingSeen:
                            tr.UnlockCondition = SayingsSeenCondition();
                            break;
                        case TrophyType.AlphabetSeen:
                            tr.UnlockCondition = AlphabetSeenCondition();
                            break;
                        case TrophyType.DialogueSeen:
                            //todo somehow remember if a dialogue has been seen
                            break;
                        case TrophyType.VocabLearned:
                            tr.UnlockCondition = VocabLearnedCondition();
                            break;
                        case TrophyType.SayingLearned:
                            tr.UnlockCondition = SayingsLearnedCondition();
                            break;
                        case TrophyType.AlphabetLearned:
                            tr.UnlockCondition = AlphabetLearnedCondition();
                            break;
                        case TrophyType.AllSeen:
                            tr.UnlockCondition = AllItemsSeenCondition();
                            break;
                        case TrophyType.AllLearned:
                            tr.UnlockCondition = AllItemsLearnedCondition();
                            break;
                        case TrophyType.SecondLogin:
                            tr.UnlockCondition = HasBeenLoggedIn();
                            break;
                        default:
                            throw new ArgumentOutOfRangeException();
                    }
                });
        }
        
        private Func<bool> LevelDependantCondition(int lvl)
        {
            return () => _user.Level >= lvl;
        }

        private Func<bool> VocabSeenCondition()
        {
            return () => DataCache.Instance.GetVocabulary().Count(HasNotBeenSeen) == 0;
        }
        
        private Func<bool> VocabAnimalsSeenCondition()
        {
            var cat = DataCache.Instance.GetCategoryById("animals");
            var vocab = DataCache.Instance.GetVocabulary().Where(v => v.Category == cat);
            return () => vocab.Count(HasNotBeenSeen) == 0;
        }
        
        private Func<bool> VocabTrafficSeenCondition()
        {
            var cat = DataCache.Instance.GetCategoryById("traffic");
            var vocab = DataCache.Instance.GetVocabulary().Where(v => v.Category == cat);
            return () => vocab.Count(HasNotBeenSeen) == 0;
        }
        
        private Func<bool> VocabFoodSeenCondition()
        {
            var cat = DataCache.Instance.GetCategoryById("food");
            var vocab = DataCache.Instance.GetVocabulary().Where(v => v.Category == cat);
            return () => vocab.Count(HasNotBeenSeen) == 0;
        }
        
        private Func<bool> VocabLocationsSeenCondition()
        {
            var cat = DataCache.Instance.GetCategoryById("locations");
            var vocab = DataCache.Instance.GetVocabulary().Where(v => v.Category == cat);
            return () => vocab.Count(HasNotBeenSeen) == 0;
        }
        
        private Func<bool> SayingsSeenCondition()
        {
            return () => DAOFactory.SayingDAO.LoadSayings().Count(HasNotBeenSeen) == 0;
        }
        
        private Func<bool> AlphabetSeenCondition()
        {
            var alphabetEntries = DAOFactory.AlphabetDAO
                .LoadAlphabet()
                .Find(a => a.Type == _user.LearningLanguage).Entries;
            
            return () => alphabetEntries.Count(HasNotBeenSeen) == 0;
        }
        
        private Func<bool> VocabLearnedCondition()
        {
            var vocab = DataCache.Instance.GetVocabulary();
            return () => vocab.Count(HasBeenLearned) == vocab.Count;
        }
        
        private Func<bool> SayingsLearnedCondition()
        {
            var sayings = DAOFactory.SayingDAO.LoadSayings();
            return () => sayings.Count(HasBeenLearned) == sayings.Count;
        }
        
        private Func<bool> AlphabetLearnedCondition()
        {
            var alphabetEntries = DataCache.Instance.GetAlphabet().Entries;
            return () => alphabetEntries.Count(HasBeenLearned) == alphabetEntries.Count;
        }

        private bool HasNotBeenSeen(ILearnItem item)
        {
            return item.CurrentLeitnerBoxNr == -1;
        }

        private bool HasBeenLearned(ILearnItem item)
        {
            return item.CurrentLeitnerBoxNr == 2;
        }

        private Func<bool> AllItemsSeenCondition()
        {
            var vocab = DAOFactory.VocabularyDAO
                .LoadVocabulary()
                .Select(item => (ILearnItem) item);
            var sayings = DAOFactory.SayingDAO
                .LoadSayings()
                .Select(item => (ILearnItem) item);
            var alphabetEntries = DataCache.Instance
                .GetAlphabet().Entries
                .Select(item => (ILearnItem) item);
            
            return () => vocab.Union(sayings).Union(alphabetEntries)
                             .Count(HasNotBeenSeen) == 0;
        }
        
        private Func<bool> AllItemsLearnedCondition()
        {
            var vocab = DAOFactory.VocabularyDAO
                .LoadVocabulary()
                .Select(item => (ILearnItem) item);
            var sayings = DAOFactory.SayingDAO
                .LoadSayings()
                .Select(item => (ILearnItem) item);
            var alphabetEntries = DataProvider.DataCache.Instance
                .GetAlphabet().Entries
                .Select(item => (ILearnItem) item);

            var union = vocab.Union(sayings).Union(alphabetEntries).ToList();
            
            return () => union.Count(HasBeenLearned) == union.Count;
        }

        private Func<bool> HasBeenLoggedIn()
        {
            return () => _user.LearningLanguage != Language.None;
        }
    }
}
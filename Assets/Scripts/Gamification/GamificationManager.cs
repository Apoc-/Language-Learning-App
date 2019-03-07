using System;
using DataAccess;
using Model;

namespace Gamification
{
    public class GamificationManager
    {
        private int _streak = 0;
        private int _maxStreak = 2;
        private float _streakXpBonus = 0.25f;
        private int _baseXp = 10;
        private int _xpStep = 150;
        
        public User User { get; private set; }

        private TrophyHandler _trophyHandler;
        public TrophyHandler TrophyHandler
        {
            get
            {
                if (_trophyHandler == null)
                {
                    _trophyHandler = new TrophyHandler();
                }

                return _trophyHandler;
            }
        }

        private GamificationManager()
        {
            User = DAOFactory.UserDAO.LoadUser();   
        }
        
        public void InitializeAnswerProgressBar(int size)
        {
            var header = ViewHandler.Instance.Header;
            header.ProgressBar.SetProgressBarSize(size);
            header.ProgressBar.SetProgress(0);
            header.EnableProgressBar();
        }
        
        public void HandleAnsweredQuestion(bool wasCorrect)
        {
            if (wasCorrect)
            {
                _streak += 1;
                if (_streak > _maxStreak) _streak = _maxStreak;
            }
            else
            {
                _streak = 0;
            }

            IncrementProgressBar();
            GiveUserXp();
        }

        private void IncrementProgressBar()
        {
            var header = ViewHandler.Instance.Header;
            header.ProgressBar.IncrementProgressBar();
        }

        private void GiveUserXp()
        {
            var bonus = (int) (_baseXp * _streak * _streakXpBonus);
            User.Xp += _baseXp + bonus;

            if (User.Xp >= _xpStep)
            {
                LevelUpUser();
                User.Xp = 0;
            }
            
            DAOFactory.UserDAO.WriteUser(User);
        }

        private void LevelUpUser()
        {
            User.Level += 1;
            ViewHandler.Instance.ModalDialogueCanvas.EnableLevelUpDialogue();
        }

        public void EnableProgressBar(int questionAmount)
        {
            ViewHandler.Instance.Header.ProgressBar.SetProgressBarSize(questionAmount);
            ViewHandler.Instance.Header.ProgressBar.SetProgress(0);

            ViewHandler.Instance.Header.ProgressBar.gameObject.SetActive(true);
        }

        public void ResetUserData()
        {
            DAOFactory.UserDAO.WriteUser(new User());
            User = new User();
        }

        public void DisableProgressBar()
        {
            ViewHandler.Instance.Header.ProgressBar.gameObject.SetActive(false);
        }

        #region singleton
        private static GamificationManager _instance;
        public static GamificationManager Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new GamificationManager();
                return _instance;
            }
        }
        #endregion
    }
}
using DataAccess;
using Model;

namespace Gamification
{
    public class GamificationManager
    {
        public User User { get; private set; }

        private GamificationManager()
        {
            User = DAOFactory.UserDAO.LoadUser();
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
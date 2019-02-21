using DataAccess;
using Model;

namespace Gamification
{
    public class GamificationManager
    {
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

        public User User { get; private set; }

        private GamificationManager()
        {
            User = DAOFactory.UserDAO.LoadUser();
        }
    }
}

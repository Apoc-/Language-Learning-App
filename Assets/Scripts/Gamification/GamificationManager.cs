using DataAccess;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

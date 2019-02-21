using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    class DAOFactory
    {
        public static ILeitnerBoxDAO LeitnerBoxDAO
        {
            get { return new LeitnerBoxDAO(); }
        }

        public static IUserDAO UserDAO
        {
            get { return new UserDAO(); }
        }
    }
}

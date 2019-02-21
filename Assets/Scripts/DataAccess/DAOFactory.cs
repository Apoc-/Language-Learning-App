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

        public static IAlphabetDAO AlphabetDAO
        {
            get { return new AlphabetDAO(); }
        }

        public static IVocabularyDAO VocabularyDAO
        {
            get { return new VocabularyDAO(); }
        }

        public static ISayingDAO SayingDAO
        {
            get { return new SayingDAO(); }
        }

        public static IDialogueDAO DialogueDAO
        {
            get { return new DialogueDAO(); }
        }

    }
}

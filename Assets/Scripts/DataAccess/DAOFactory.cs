namespace DataAccess
{
    class DAOFactory
    {
        public static ILeitnerBoxDAO LeitnerBoxDAO => new LeitnerBoxDAO();
        public static IUserDAO UserDAO => new UserDAO();
        public static IAlphabetDAO AlphabetDAO => new AlphabetDAO();
        public static IVocabularyDAO VocabularyDAO => new VocabularyDAO();
        public static ISayingDAO SayingDAO => new SayingDAO();
        public static IDialogueDAO DialogueDAO => new DialogueDAO();
    }
}

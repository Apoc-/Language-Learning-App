using System.Collections.Generic;
using Model;

namespace DataAccess
{
    public interface IVocabularyDAO
    {
        List<Vocabulary> LoadVocabulary();
    }
}
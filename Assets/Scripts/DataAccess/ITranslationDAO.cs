using System.Collections.Generic;
using Model;

namespace DataAccess
{
    public interface ITranslationDAO
    {
        List<Translation> LoadTranslations();
    }
}
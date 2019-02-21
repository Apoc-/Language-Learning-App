using System.Collections.Generic;
using Model;

namespace DataAccess
{
    public interface IAlphabetDAO
    {
        List<Alphabet> LoadAlphabet();
    }
}
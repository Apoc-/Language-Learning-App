using System.Collections.Generic;
using Model;

namespace DataAccess
{
    public interface ISayingDAO
    {
        List<Saying> LoadSayings();
    }
}
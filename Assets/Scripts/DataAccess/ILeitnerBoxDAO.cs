using System.Collections.Generic;

namespace DataAccess
{
    public interface ILeitnerBoxDAO
    {
        Dictionary<string, int> LoadLeitnerboxData();
        void WriteLeitnerboxData(string id, int leitnerBoxNr);
        void ResetLeitnerBoxData();
    }
}
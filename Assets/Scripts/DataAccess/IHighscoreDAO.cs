using System.Collections.Generic;
using Model;

namespace DataAccess
{
    public interface IHighscoreDAO
    {
        List<HighscoreEntry> LoadDialogues();
    }
}
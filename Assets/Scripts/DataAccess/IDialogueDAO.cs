using System.Collections.Generic;
using Model;

namespace DataAccess
{
    public interface IDialogueDAO
    {
        List<Dialogue> LoadDialogues();
    }
}
using System.Collections.Generic;
using Model;

namespace DataAccess
{
    public interface ICategoryDAO
    {
        List<Category> LoadDialogues();
    }
}
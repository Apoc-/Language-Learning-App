using Model;

namespace DataAccess
{
    public interface IUserDAO
    {
        User LoadUser();
        void WriteUser(User user);
    }
}
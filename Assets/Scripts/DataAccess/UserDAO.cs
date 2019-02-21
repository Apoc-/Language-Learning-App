
using Model;
using Newtonsoft.Json;
using System.IO;
using System.Text;

namespace DataAccess
{
    public class UserDAO : IUserDAO
    {
        private readonly string path = Path.Combine(UnityEngine.Application.persistentDataPath, "user.json");

        public User LoadUser()
        {
            if (!File.Exists(path)) File.WriteAllText(path, JsonConvert.SerializeObject(new User()));

            var json = File.ReadAllText(path, Encoding.UTF8);
            return JsonConvert.DeserializeObject<User>(json);
        }

        public void WriteUser(User user)
        {
            File.WriteAllText(path, JsonConvert.SerializeObject(user), Encoding.UTF8);
        }
    }
}

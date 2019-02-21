using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class LeitnerBoxDAO : ILeitnerBoxDAO
    {
        private readonly string path = UnityEngine.Application.persistentDataPath + "leitnerData.json";

        public Dictionary<string, int> LoadLeitnerboxData()
        {
            if (!File.Exists(path)) File.WriteAllText(path, JsonConvert.SerializeObject(new Dictionary<string, int>()));

            var json = File.ReadAllText(path, Encoding.UTF8);
            return JsonConvert.DeserializeObject<Dictionary<string, int>>(json);
        }

        public void WriteLeitnerboxData(string id, int leitnerBoxNr)
        {
            var data = LoadLeitnerboxData();

            if (data.ContainsKey(id))
            {
                data[id] = leitnerBoxNr;
            }
            else
            {
                data.Add(id, leitnerBoxNr);
            }

            File.WriteAllText(path, JsonConvert.SerializeObject(data), Encoding.UTF8);
        }
    }
}

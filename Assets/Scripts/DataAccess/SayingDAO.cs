using Model;
using Newtonsoft.Json;
using System.Collections.Generic;
using UnityEngine;

namespace DataAccess
{
    public class SayingDAO : ISayingDAO
    {
        private readonly string path = "Dictionary/Sayings";

        public List<Saying> LoadSayings()
        {
            var asset = Resources.Load<TextAsset>(path);
            if (asset == null) throw new System.Exception("Asset Resources/" + path + " not found");

            var json = asset.text;
            return JsonConvert.DeserializeObject<List<Saying>>(json);
        }
    }
}
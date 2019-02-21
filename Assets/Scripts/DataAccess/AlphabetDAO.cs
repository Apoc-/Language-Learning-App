using Model;
using Newtonsoft.Json;
using System.Collections.Generic;
using UnityEngine;

namespace DataAccess
{
    public class AlphabetDAO : IAlphabetDAO
    {
        private readonly string path = "Dictionary/Alphabet";

        public List<Alphabet> LoadAlphabet()
        {
            var asset = Resources.Load<TextAsset>(path);
            if (asset == null) throw new System.Exception("Asset Resources/" + path + " not found");

            var json = asset.text;
            return JsonConvert.DeserializeObject<List<Alphabet>>(json);
        }
    }
}
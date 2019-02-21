using Model;
using Newtonsoft.Json;
using System.Collections.Generic;
using UnityEngine;

namespace DataAccess
{
    public class VocabularyDAO : IVocabularyDAO
    {
        private readonly string path = "Dictionary/Vocabulary";

        public List<Vocabulary> LoadVocabulary()
        {
            var asset = Resources.Load<TextAsset>(path);
            if (asset == null) throw new System.Exception("Asset Resources/" + path + " not found");

            var json = asset.text;
            return JsonConvert.DeserializeObject<List<Vocabulary>>(json);
        }
    }
}
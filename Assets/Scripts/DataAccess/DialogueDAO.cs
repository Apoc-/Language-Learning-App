using Model;
using Newtonsoft.Json;
using System.Collections.Generic;
using UnityEngine;

namespace DataAccess
{
    public class DialogueDAO : IDialogueDAO
    {
        private readonly string path = "Dictionary/Dialogue";

        public List<Dialogue> LoadDialogues()
        {
            var asset = Resources.Load<TextAsset>(path);
            if (asset == null) throw new System.Exception("Asset Resources/" + path + " not found");

            var json = asset.text;
            return JsonConvert.DeserializeObject<List<Dialogue>>(json);
        }
    }
}
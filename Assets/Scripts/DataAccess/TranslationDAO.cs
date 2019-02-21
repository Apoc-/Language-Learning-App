﻿using Model;
using Newtonsoft.Json;
using System.Collections.Generic;
using UnityEngine;

namespace DataAccess
{
    public class TranslationDAO
    {
        private readonly string path = "Dictionary/Translation";

        public List<Translation> LoadDialogues()
        {
            var asset = Resources.Load<TextAsset>(path);
            if (asset == null) throw new System.Exception("Asset Resources/" + path + " not found");

            var json = asset.text;
            return JsonConvert.DeserializeObject<List<Translation>>(json);
        }
    }
}
<<<<<<< HEAD
﻿using System.Collections.Generic;
using LeitnerSystem;
using UnityEngine;
=======
﻿using LeitnerSystem;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
>>>>>>> b276756425544226ffc45930bf964afcd1b4a29b

namespace Model
{
    [Serializable]
    public class Vocabulary : LearnItem
    {
        public Translation Translation { get; set; }

        [JsonProperty]
        private string CategoryId;

        private Category _category;

        [JsonIgnore]
        public Category Category { get => _category; set => _category = value; }

        public ImageData Image { get; set; }

        public Dictionary<ChosenLanguage, List<AudioData>> Audio { get; private set; }

        public string Bopomofo { get; set; }

        public Vocabulary()
        {
            Audio = new Dictionary<ChosenLanguage, List<AudioData>>();
        }
    }
}

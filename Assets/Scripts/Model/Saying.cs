using LeitnerSystem;
using Newtonsoft.Json;
using System;
using UnityEngine;

namespace Model
{
    [Serializable]
    public class Saying : LearnItem
    {
        /// <summary>
        /// The language the saying is from
        /// </summary>
        public ChosenLanguage Language { get; set; }

        /// <summary>
        /// Saying in the other language
        /// </summary>
        public string Text { get; set; }

        /// <summary>
        /// Explanation of the saying in own language
        /// </summary>
        public string Meaning { get; set; }

        /// <summary>
        /// A similar saying in own language
        /// </summary>
        public string SimilarSaying { get; set; }

        [JsonProperty]
        private string CategoryId;

        private Category _category;

        [JsonIgnore]
        public Category Category { get => _category; set => _category = value; }

        public AudioData Audio { get; set; }

        public string Bopomofo { get; set; }
    }
}

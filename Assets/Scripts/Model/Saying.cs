using DataAccess;
using LeitnerSystem;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using UnityEngine;

namespace Model
{
    [Serializable]
    public class Saying : ILearnItem
    {
        public string Id { get; set; }

        private int _currentLeitnerBoxNr = -1;

        [JsonIgnore]
        public int CurrentLeitnerBoxNr
        {
            get
            {
                if (_currentLeitnerBoxNr == -1)
                {
                    int nr = 0;
                    if (DAOFactory.LeitnerBoxDAO.LoadLeitnerboxData().TryGetValue(this.Id, out nr))
                        _currentLeitnerBoxNr = nr;
                }

                return _currentLeitnerBoxNr;
            }
            set
            {
                _currentLeitnerBoxNr = value;
                DAOFactory.LeitnerBoxDAO.WriteLeitnerboxData(Id, _currentLeitnerBoxNr);
            }
        }

        /// <summary>
        /// The language the saying is from
        /// </summary>
        [JsonConverter(typeof(StringEnumConverter))]
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

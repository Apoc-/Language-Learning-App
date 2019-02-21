using DataAccess;
using LeitnerSystem;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace Model
{
    [Serializable]
    public class Vocabulary : ILearnItem
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

        public Dictionary<ChosenLanguage, string> Translation { get; set; }

        public Dictionary<ChosenLanguage, AudioData> Audio { get; private set; }

        [JsonProperty("CategoryId")]
        private string _categoryId;

        private Category _category;

        [JsonIgnore]
        public Category Category { get => _category; set => _category = value; }

        public ImageData Image { get; set; }
        
        public string Bopomofo { get; set; }

        public Vocabulary()
        {
            Audio = new Dictionary<ChosenLanguage, AudioData>();
            Translation = new Dictionary<ChosenLanguage, string>();
        }
    }
}

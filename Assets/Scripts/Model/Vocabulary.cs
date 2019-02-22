using DataAccess;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;

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
                    if (DAOFactory.LeitnerBoxDAO.LoadLeitnerboxData().TryGetValue(this.Id, out int nr))
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

        public Dictionary<Language, string> Translation { get; set; }

        public Dictionary<Language, AudioData> Audio { get; private set; }

        [JsonProperty("CategoryId")]
        private string _categoryId;

        private Category _category;

        [JsonIgnore]
        public Category Category
        {
            get
            {
                if (_category == null)
                {
                    var category = DAOFactory.CategoryDAO.LoadDialogues().FirstOrDefault(c => c.Id == _categoryId);
                    _category = category ?? throw new Exception("Category with id " + _categoryId + " not found");
                }

                return _category;
            }
        }

        public ImageData Image { get; set; }

        public string Bopomofo { get; set; }

        public Vocabulary()
        {
            Audio = new Dictionary<Language, AudioData>();
            Translation = new Dictionary<Language, string>();
        }
    }
}

using DataAccess;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Model
{
    [Serializable]
    public class Dialogue
    {
        public string Id { get; set; }

        public Translation Name { get; set; }

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

        public Dictionary<Language, List<DialogueEntry>> Entries { get; private set; }

        public Dialogue()
        {
            Entries = new Dictionary<Language, List<DialogueEntry>>
            {
                { Language.German, new List<DialogueEntry>() },
                { Language.Taiwanese, new List<DialogueEntry>() }
            };
        }
    }
}

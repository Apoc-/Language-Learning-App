using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace Model
{
    [Serializable]
    public class Dialogue : ILearnItem
    {
        public string Id { get; set; }
        public int CurrentLeitnerBoxNr { get; set; }

        public Translation Name { get; set; }

        [JsonProperty]
        private string CategoryId;

        private Category _category;

        [JsonIgnore]
        public Category Category { get => _category; set => _category = value; }

        public Dictionary<ChosenLanguage, List<DialogueEntry>> Entries { get; private set; }

        public Dialogue()
        {
            Entries = new Dictionary<ChosenLanguage, List<DialogueEntry>>();
            Entries.Add(ChosenLanguage.German, new List<DialogueEntry>());
            Entries.Add(ChosenLanguage.Taiwanese, new List<DialogueEntry>());
        }
    }
}

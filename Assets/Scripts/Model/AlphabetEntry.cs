using DataAccess;
using Newtonsoft.Json;
using System;

namespace Model
{
    [Serializable]
    public class AlphabetEntry : ILearnItem
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

        public string Character { get; set; }

        public AudioData ContextFreeAudio { get; set; }

        public AudioData ContextSensitiveAudio { get; set; }

        public AudioData ExampleWordAudio { get; set; }
    }
}

using LeitnerSystem;
using System;
using System.Collections.Generic;

namespace Model
{
    [Serializable]
    public class Vocabulary : LearnItem
    {
        public Translation Translation { get; set; }

        public Category Category { get; set; }

        public ImageData Image { get; set; }

        public Dictionary<ChosenLanguage, List<AudioData>> Audio { get; private set; }

        public string Bopomofo { get; set; }

        public Vocabulary()
        {
            Audio = new Dictionary<ChosenLanguage, List<AudioData>>();
        }
    }
}

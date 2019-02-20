using System.Collections.Generic;
using LeitnerSystem;
using UnityEngine;

namespace Model
{
    public class Vocabulary : LearnItem
    {
        public Translation Translation { get; set; }
        public Category Category { get; set; }
        public Texture2D Image { get; set; }
        public AudioClip Audio { get; set; }
        public string Bopomofo { get; set; }
    }
}

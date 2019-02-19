using LeitnerSystem;
using UnityEngine;

namespace Model
{
    public class Saying : LearnItem
    {
        public Translation Translation { get; set; }
        public Category Category { get; set; }
        public Translation SimilarSaying { get; set; }
        public AudioClip Audio { get; set; }
        public string Bopomofo { get; set; }
    }
}

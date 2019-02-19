using Assets.Scripts.Model;
using LeitnerSystem;
using UnityEngine;

namespace Model
{
    public class Saying : LearnItem
    {
        public string ID { get; set; }
        public Translation Translation { get; set; }
        public Category Category { get; set; }
        public Translation SimilarSaying { get; set; }
        public AudioClip Audio { get; set; }
        public string Bopomofo { get; set; }
    }
}

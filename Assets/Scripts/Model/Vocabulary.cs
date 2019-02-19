using UnityEngine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.Model
{
    public class Vocabulary : LearnItem
    {
        public string ID { get; set; }
        public Translation Translation { get; set; }
        public Category Category { get; set; }
        public Texture2D Image { get; set; }
        public AudioClip Audio { get; set; }
        public string Bopomofo { get; set; }
    }
}

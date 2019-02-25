using Newtonsoft.Json;
using System;
using Gamification;
using Newtonsoft.Json.Converters;
using UnityEngine;

namespace Model
{
    public class Trophy
    {
        public Translation Name { get; set; }

        public TrophyType TrophyType { get; set; }
        
        // capsulate for lazy loading
        //public MeshData Mesh { get; set; }
        public Sprite Image { get; set; }

        public Func<bool> UnlockCondition { get; set; }
    }
}
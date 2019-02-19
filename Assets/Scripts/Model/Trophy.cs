using System;
using UnityEngine;

namespace Assets.Scripts.Model
{
    public class Trophy
    {
        public string ID { get; set; }
        public Translation Name { get; set; }
        public bool IsUnlocked { get; set; }
        public Mesh Mesh { get; set; }
        public Func<bool> UnlockCondition { get; set; }
        public Func<float> Progress { get; set; }
    }
}
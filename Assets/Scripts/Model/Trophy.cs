using Newtonsoft.Json;
using System;
using UnityEngine;

namespace Model
{
    [Serializable]
    public class Trophy
    {
        public string Id { get; set; }

        public Translation Name { get; set; }

        public bool IsUnlocked { get; set; }

        // capsulate for lazy loading
        public MeshData Mesh { get; set; }

        [JsonIgnore]
        public Func<bool> UnlockCondition { get; set; }

        [JsonIgnore]
        public Func<float> Progress { get; set; }
    }
}
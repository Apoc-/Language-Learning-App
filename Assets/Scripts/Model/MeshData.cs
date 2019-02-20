﻿using Newtonsoft.Json;
using System;
using UnityEngine;

namespace Model
{
    [Serializable]
    public class MeshData
    {
        public string Id { get; set; }

        public string Path { get; set; }

        [JsonIgnore]
        public Mesh Mesh { get; set; }
    }
}
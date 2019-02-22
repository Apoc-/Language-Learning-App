using Newtonsoft.Json;
using System;
using UnityEngine;

namespace Model
{
    [Serializable]
    public class MeshData
    {
        public string Path { get; set; }

        private Mesh _mesh = null;

        [JsonIgnore]
        public Mesh Mesh
        {
            get
            {
                _mesh = _mesh
                    ?? Resources.Load<Mesh>(Path)
                    ?? throw new Exception("Resource of Type Mesh was not found in " + Path);

                return _mesh;
            }
        }
    }
}
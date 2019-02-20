using Newtonsoft.Json;
using System;
using UnityEngine;

namespace Model
{
    [Serializable]
    public class ImageData
    {
        public string Id { get; set; }

        public string Path { get; set; }

        [JsonIgnore]
        public Texture2D Image { get; set; }
    }
}
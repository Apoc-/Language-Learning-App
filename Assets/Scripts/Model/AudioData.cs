using Newtonsoft.Json;
using System;
using UnityEngine;

namespace Model
{
    [Serializable]
    public class AudioData
    {
        public string Id { get; set; }

        public string Path { get; set; }

        [JsonIgnore]
        public AudioClip Audio { get; set; }
    }
}

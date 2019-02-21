using Newtonsoft.Json;
using System;
using UnityEngine;

namespace Model
{
    [Serializable]
    public class AudioData
    {
        public string Path { get; set; }

        [JsonIgnore]
        public AudioClip Audio { get; set; }
    }
}

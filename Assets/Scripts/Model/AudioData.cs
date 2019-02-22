using Newtonsoft.Json;
using System;
using UnityEngine;

namespace Model
{
    [Serializable]
    public class AudioData
    {
        public string Path { get; set; }

        private AudioClip _audio = null;

        [JsonIgnore]
        public AudioClip Image
        {
            get
            {
                _audio = _audio
                    ?? Resources.Load<AudioClip>(Path)
                    ?? throw new Exception("Resource of Type AudioClip was not found in " + Path);

                return _audio;
            }
        }
    }
}

using Newtonsoft.Json;
using System;
using UnityEngine;

namespace Model
{
    [Serializable]
    public class ImageData
    {
        public string Path { get; set; }

        private Sprite _image = null;

        [JsonIgnore]
        public Sprite Sprite
        {
            get
            {
                _image = _image
                    ?? Resources.Load<Sprite>(Path)
                    ;//?? throw new Exception("Resource of Type Sprite was not found in " + Path);

                return _image;
            }
        }
    }
}
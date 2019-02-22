using Newtonsoft.Json;
using System;
using UnityEngine;

namespace Model
{
    [Serializable]
    public class ImageData
    {
        public string Path { get; set; }

        private Texture2D _image = null;

        [JsonIgnore]
        public Texture2D Image
        {
            get
            {
                _image = _image 
                    ?? Resources.Load<Texture2D>(Path) 
                    ?? throw new Exception("Resource of Type Texture2D was not found in " + Path);

                return _image;
            }
        }
    }
}
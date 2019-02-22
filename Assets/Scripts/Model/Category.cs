using System;

namespace Model
{
    [Serializable]
    public class Category
    {
        public string Id { get; set; }

        public Translation Name { get; set; }
    }
}

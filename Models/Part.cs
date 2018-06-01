using Newtonsoft.Json;
using System.Collections.Generic;

namespace LegoVueApp.Models
{
    public class PartResponse
    {
        public int Count { get; set; }
        public string Next { get; set; }
        public string Previous { get; set; }
        public List<PartInSet> Results { get; set; }
    }

    public class PartInSet
    {
        public Part Part { get; set; }
        public Color Color { get; set; }
        public int Quantity { get; set; }
        [JsonProperty(PropertyName = "num_sets")]
        public int NumberOfSets { get; set; }
    }

    public class Part
    {
        public string Name { get; set; }
        [JsonProperty(PropertyName = "part_img_url")]
        public string ImageUrl { get; set; }
    }

    public class Color
    {
        public string Name { get; set; }
    }
}

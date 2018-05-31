using System.Collections.Generic;
using Newtonsoft.Json;

namespace LegoVueApp.Models
{
    public class SetsResponse
    {
        public int Count { get; set; }
        public string Next { get; set; }
        public string Previous { get; set; }
        public List<LegoSet> Results { get; set; }
    }

    public class LegoSet
    {
        [JsonProperty(PropertyName = "set_num")]
        public string Number { get; set; }
        public string Name { get; set; }
        public int Year { get; set; }
        [JsonProperty(PropertyName = "theme_id")]
        public int ThemeID { get; set; }
        [JsonProperty(PropertyName = "num_parts")]
        public int NumberOfParts { get; set;}
        [JsonProperty(PropertyName ="set_img_url")]
        public string ImageUrl { get; set; }
        // TODO: add other properties
    }
}

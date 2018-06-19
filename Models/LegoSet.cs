using System.Collections.Generic;
using Newtonsoft.Json;

namespace LegoVueApp.Models
{
    public class SetsResponse
    {
        public int Count { get; set; }
        public string Next { get; set; }
        public string Previous { get; set; }
        public List<RebrickableLegoSet> Results { get; set; }
    }

    public class RebrickableLegoSet
    {
        [JsonProperty(PropertyName = "set_num")]
        public string Number { get; set; }
        public string Name { get; set; }
        public int Year { get; set; }
        [JsonProperty(PropertyName = "theme_id")]
        public int ThemeID { get; set; }
        public string Theme { get; set; }
        [JsonProperty(PropertyName = "num_parts")]
        public int NumberOfParts { get; set;}
        [JsonProperty(PropertyName = "set_img_url")]
        public string ImageUrl { get; set; }
        [JsonProperty(PropertyName = "set_url")]
        public string SetUrl { get; set; }
        [JsonProperty(PropertyName = "last_modified_dt")]
        public string LastModifiedDate { get; set; }
    }
}

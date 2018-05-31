using Newtonsoft.Json;
using System.Collections.Generic;

namespace LegoVueApp.Models
{
    public class ThemeResponse
    {
        public int Count { get; set; }
        public string Next { get; set; }
        public string Previous { get; set; }
        public List<Theme> Results { get; set; }
    }

    public class Theme
    {
        public int ID { get; set; }
        [JsonProperty(PropertyName = "parent_id")]
        public int? ParentID { get; set; }
        public string Name { get; set; }
    }
}

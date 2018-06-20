using Newtonsoft.Json;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace LegoVueApp.Models
{
    public class ThemeResponse
    {
        public int Count { get; set; }
        public string Next { get; set; }
        public string Previous { get; set; }
        public List<RebrickableTheme> Results { get; set; }
    }

    public class RebrickableTheme
    {
        public int ID { get; set; }
        [JsonProperty(PropertyName = "parent_id")]
        public int? ParentID { get; set; }
        public string Name { get; set; }
    }

    public class BricksetTheme
    {
        [XmlElement("theme")]
        public string Name { get; set; }
        [XmlElement("setCount")]
        public int SetCount { get; set; }
        [XmlElement("subthemeCount")]
        public int SubThemeCount { get; set; }
        [XmlElement("yearFrom")]
        public int YearFrom { get; set; }
        [XmlElement("yearTo")]
        public int YearTo { get; set; }
    }
}

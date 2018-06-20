using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Xml.Serialization;
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
        public int Pieces { get; set;}
        [JsonProperty(PropertyName = "set_img_url")]
        public string ImageUrl { get; set; }
        [JsonProperty(PropertyName = "set_url")]
        public string SetUrl { get; set; }
        [JsonProperty(PropertyName = "last_modified_dt")]
        public string LastModifiedDate { get; set; }

        public LegoSet ToLegoSet()
        {
            var legoSet = new LegoSet
            {
                Number = Number,
                Name = Name,
                Year = Year,
                ThemeID = Theme,
                ThemeName = Theme,
                Pieces = Pieces,
                ImageUrl = ImageUrl,
                SetUrl = SetUrl
            };
            return legoSet;
        }
    }

    public class BricksetLegoSet
    {
        [XmlElement("number")]
        public int Number { get; set; }
        [XmlElement("numberVariant")]
        public int NumberVariant { get; set; }
        [XmlElement("name")]
        public string Name { get; set; }
        [XmlElement("year")]
        public int Year { get; set; }
        [XmlElement("theme")]
        public string Theme { get; set; }
        [XmlElement("pieces")]
        [DefaultValue(0)]
        public int Pieces { get; set; }
        [XmlElement("minifigs")]
        [DefaultValue(0)]
        public int Minifigs { get; set; }
        [XmlElement("imageURL")]
        public string ImageUrl { get; set; }
        [XmlElement("bricksetURL")]
        public string SetUrl { get; set; }

        public LegoSet ToLegoSet()
        {
            var legoSet = new LegoSet
            {
                Number = Number + "-" + NumberVariant,
                Name = Name,
                Year = Year,
                ThemeID = Theme,
                ThemeName = Theme,
                Pieces = Pieces,
                ImageUrl = ImageUrl,
                SetUrl = SetUrl
            };
            return legoSet;
        }
    }

    public class LegoSet
    {
        public string Number { get; set; }
        public string Name { get; set; }
        public int Year { get; set; }
        public string ThemeID { get; set; }
        public string ThemeName { get; set; }
        public int Pieces { get; set; }
        public string ImageUrl { get; set; }
        public string SetUrl { get; set; }
    }
}

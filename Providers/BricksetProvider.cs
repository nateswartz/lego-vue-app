using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Net.Http;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;

namespace LegoVueApp.Providers
{
    public class BricksetProvider : IBricksetProvider
    {
        private string _key;
        private HttpClient _client;

        public BricksetProvider(IConfiguration configuration)
        {
            _client = new HttpClient();
            _client.BaseAddress = new Uri(configuration["ExternalServices:Brickset:Url"]);
            _key = configuration["ExternalServices:Brickset:Key"];
        }

        public async Task<List<BricksetLegoSet>> GetSetsAsync()
        {
            var nvc = new List<KeyValuePair<string, string>>
            {
                new KeyValuePair<string, string>("apiKey", _key),
                new KeyValuePair<string, string>("userHash", ""),
                new KeyValuePair<string, string>("query", ""),
                new KeyValuePair<string, string>("theme", ""),
                new KeyValuePair<string, string>("subtheme", ""),
                new KeyValuePair<string, string>("setNumber", ""),
                new KeyValuePair<string, string>("year", "2017"),
                new KeyValuePair<string, string>("owned", ""),
                new KeyValuePair<string, string>("wanted", ""),
                new KeyValuePair<string, string>("orderBy", ""),
                new KeyValuePair<string, string>("pageSize", ""),
                new KeyValuePair<string, string>("pageNumber", ""),
                new KeyValuePair<string, string>("userName", "")
            };
            var req = new HttpRequestMessage(HttpMethod.Post, "getSets") { Content = new FormUrlEncodedContent(nvc) };
            var res = await _client.SendAsync(req);
            var content = await res.Content.ReadAsStringAsync();
            var serializer = new XmlSerializer(typeof(ArrayOfSets));
            var strReader = new StringReader(content);
            var result = (ArrayOfSets)serializer.Deserialize(strReader);
            return result.Sets;
        }
    }

    [XmlRoot("ArrayOfSets", Namespace="https://brickset.com/api/")]
    public class ArrayOfSets
    {
        [XmlElement("sets")]
        public List<BricksetLegoSet> Sets { get; set; }
    }

    public class BricksetLegoSet
    {
        [XmlElement("setID")]
        public int SetID { get; set; }
        [XmlElement("number")]
        public int Number { get; set; }
        [XmlElement("numberVariant")]
        public int NumberVariant { get; set; }
        [XmlElement("name")]
        public string Name { get; set; }
        [XmlElement("pieces")]
        public int Pieces { get; set; }
        [XmlElement("minifigs")]
        [DefaultValue(0)]
        public int Minifigs { get; set; }
        [XmlElement("year")]
        public int Year { get; set; }


    }
}

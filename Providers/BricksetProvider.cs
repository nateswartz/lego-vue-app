using LegoVueApp.Models;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
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

        public async Task<LegoSet> GetSetAsync(string setNumber)
        {
            var nvc = GetRequestBody(setNumber: setNumber);
            var req = new HttpRequestMessage(HttpMethod.Post, "getSets") { Content = new FormUrlEncodedContent(nvc) };
            var res = await _client.SendAsync(req);
            var content = await res.Content.ReadAsStringAsync();
            var serializer = new XmlSerializer(typeof(ArrayOfSets));
            var strReader = new StringReader(content);
            var result = (ArrayOfSets)serializer.Deserialize(strReader);
            return result.Sets.First().ToLegoSet();
        }

        public async Task<List<LegoSet>> GetSetsAsync(int page, int pageSize, string theme = "")
        {
            var nvc = GetRequestBody(query: "*", theme: theme, pageSize: pageSize.ToString(), page: page.ToString());
            var req = new HttpRequestMessage(HttpMethod.Post, "getSets") { Content = new FormUrlEncodedContent(nvc) };
            var res = await _client.SendAsync(req);
            var content = await res.Content.ReadAsStringAsync();
            var serializer = new XmlSerializer(typeof(ArrayOfSets));
            var strReader = new StringReader(content);
            var result = (ArrayOfSets)serializer.Deserialize(strReader);
            return result.Sets.Select(s => s.ToLegoSet()).ToList();
        }

        public async Task<List<BricksetTheme>> GetThemesAsync()
        {
            var nvc = GetRequestBody();
            var req = new HttpRequestMessage(HttpMethod.Post, "getThemes") { Content = new FormUrlEncodedContent(nvc) };
            var res = await _client.SendAsync(req);
            var content = await res.Content.ReadAsStringAsync();
            var serializer = new XmlSerializer(typeof(ArrayOfThemes));
            var strReader = new StringReader(content);
            var result = (ArrayOfThemes)serializer.Deserialize(strReader);
            return result.Themes;
        }

        //public async Task<BricksetLegoTheme> GetThemeAsync(string themeName)
        //{

        //}

        private List<KeyValuePair<string, string>> GetRequestBody(string query = "", string theme = "",
            string setNumber = "", string pageSize = "", string page = "")
        {
            return new List<KeyValuePair<string, string>>
            {
                new KeyValuePair<string, string>("apiKey", _key),
                new KeyValuePair<string, string>("userHash", ""),
                new KeyValuePair<string, string>("query", query),
                new KeyValuePair<string, string>("theme", theme),
                new KeyValuePair<string, string>("subtheme", ""),
                new KeyValuePair<string, string>("setNumber", setNumber),
                new KeyValuePair<string, string>("year", ""),
                new KeyValuePair<string, string>("owned", ""),
                new KeyValuePair<string, string>("wanted", ""),
                new KeyValuePair<string, string>("orderBy", ""),
                new KeyValuePair<string, string>("pageSize", pageSize),
                new KeyValuePair<string, string>("pageNumber", page),
                new KeyValuePair<string, string>("userName", "")
            };
        }
    }

    [XmlRoot("ArrayOfSets", Namespace="https://brickset.com/api/")]
    public class ArrayOfSets
    {
        [XmlElement("sets")]
        public List<BricksetLegoSet> Sets { get; set; }
    }


    [XmlRoot("ArrayOfThemes", Namespace = "https://brickset.com/api/")]
    public class ArrayOfThemes
    {
        [XmlElement("themes")]
        public List<BricksetTheme> Themes { get; set; }
    }

}

using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Net.Http;

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

        public void CheckKey()
        {
            var nvc = new List<KeyValuePair<string, string>>
            {
                new KeyValuePair<string, string>("apiKey", _key)
            };
            var req = new HttpRequestMessage(HttpMethod.Post, "checkKey") { Content = new FormUrlEncodedContent(nvc) };
            var res = _client.SendAsync(req).Result;
            var content = res.Content.ReadAsStringAsync().Result;
        }
    }
}

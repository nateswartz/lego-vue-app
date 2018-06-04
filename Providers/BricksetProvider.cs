using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace LegoVueApp.Providers
{
    public class BricksetProvider : IBricksetProvider
    {
        private string _key = "";
        private HttpClient _client;
        public BricksetProvider()
        {
            _client = new HttpClient();
            _client.BaseAddress = new Uri("https://brickset.com/api/v2.asmx/");
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

using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Vue2Spa.Models;

namespace Vue2Spa.Providers
{
    public class LegoSetsProvider : ILegoSetsProvider
    {
        private string _key = "";
        private HttpClient _client;
        public LegoSetsProvider()
        {
            _client = new HttpClient();
            _client.BaseAddress = new Uri("https://rebrickable.com/api/v3/lego/");
            _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("key", _key);
        }

        public async Task<List<LegoSet>> GetSets()
        {
            var response = await _client.GetAsync("sets");
            var content = await response.Content.ReadAsStringAsync();
            var setsInfo = JsonConvert.DeserializeObject<SetsResponse>(content);
            return setsInfo.Results;
        }
    }
}

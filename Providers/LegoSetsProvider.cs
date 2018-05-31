using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Newtonsoft.Json;
using LegoVueApp.Models;

namespace LegoVueApp.Providers
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

        public async Task<List<LegoSet>> GetSets(int page, int pageSize)
        {
            var response = await _client.GetAsync($"sets?page={page}&page_size={pageSize}");
            var content = await response.Content.ReadAsStringAsync();
            var setsInfo = JsonConvert.DeserializeObject<SetsResponse>(content);
            return setsInfo.Results;
        }
    }
}

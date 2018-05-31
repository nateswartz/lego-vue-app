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
        private List<Theme> _themes = new List<Theme>();
        private HttpClient _client;
        public LegoSetsProvider()
        {
            _client = new HttpClient();
            _client.BaseAddress = new Uri("https://rebrickable.com/api/v3/lego/");
            _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("key", _key);
        }

        public async Task<List<LegoSet>> GetSets(int page, int pageSize)
        {
            if (_themes.Count == 0)
            {
                _themes = await GetThemes();
            }
            var response = await _client.GetAsync($"sets?page={page}&page_size={pageSize}");
            var content = await response.Content.ReadAsStringAsync();
            var setsInfo = JsonConvert.DeserializeObject<SetsResponse>(content);
            foreach (var set in setsInfo.Results)
            {
                set.Theme = _themes.Where(t => t.ID == set.ThemeID)
                                   .Select(t => t.Name)
                                   .First();
            }
            return setsInfo.Results;
        }

        public async Task<Theme> GetTheme(int themeID)
        {
            var response = await _client.GetAsync($"themes/{themeID}");
            var content = await response.Content.ReadAsStringAsync();
            var theme = JsonConvert.DeserializeObject<Theme>(content);
            return theme;
        }

        public async Task<List<Theme>> GetThemes()
        {
            var response = await _client.GetAsync($"themes/?page_size=1000");
            var content = await response.Content.ReadAsStringAsync();
            var themeResponse = JsonConvert.DeserializeObject<ThemeResponse>(content);
            return themeResponse.Results;
        }
    }
}

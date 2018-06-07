using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Newtonsoft.Json;
using LegoVueApp.Models;
using Microsoft.Extensions.Configuration;

namespace LegoVueApp.Providers
{
    public class RebrickableProvider : IRebrickableProvider
    {
        private List<Theme> _themes = new List<Theme>();
        private HttpClient _client;

        public RebrickableProvider(IConfiguration configuration)
        {
            _client = new HttpClient();
            _client.BaseAddress = new Uri(configuration["ExternalServices:Rebrickable:Url"]);
            _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("key", configuration["ExternalServices:Rebrickable:Key"]);
        }

        public async Task<List<LegoSet>> GetSets(int page, int pageSize, int? theme)
        {
            var requestUrl = $"sets?page={page}&page_size={pageSize}";
            if (_themes.Count == 0)
            {
                _themes = await GetThemes();
            }
            if (theme != null)
            {
                requestUrl += $"&theme_id={theme}";
            }
            var response = await _client.GetAsync(requestUrl);
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

        public async Task<LegoSet> GetSet(string setID)
        {
            var response = await _client.GetAsync($"sets/{setID}");
            var content = await response.Content.ReadAsStringAsync();
            var setResponse = JsonConvert.DeserializeObject<LegoSet>(content);
            return setResponse;
        }

        public async Task<List<PartInSet>> GetPartsForSet(string setID)
        {
            var response = await _client.GetAsync($"sets/{setID}/parts");
            var content = await response.Content.ReadAsStringAsync();
            var partsResponse = JsonConvert.DeserializeObject<PartResponse>(content);
            return partsResponse.Results;
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
using System.Collections.Generic;
using System.Threading.Tasks;
using LegoVueApp.Models;

namespace LegoVueApp.Providers
{
    public interface IRebrickableProvider
    {
        Task<List<RebrickableLegoSet>> GetSetsAsync(int page, int pageSize, int? theme);
        Task<RebrickableLegoSet> GetSetAsync(string setID);
        Task<List<PartInSet>> GetPartsForSetAsync(string setID);
        Task<Theme> GetThemeAsync(int themeID);
        Task<List<Theme>> GetThemesAsync();
    }
}

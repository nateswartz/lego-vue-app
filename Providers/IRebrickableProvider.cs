using System.Collections.Generic;
using System.Threading.Tasks;
using LegoVueApp.Models;

namespace LegoVueApp.Providers
{
    public interface IRebrickableProvider
    {
        Task<List<LegoSet>> GetSetsAsync(int page, int pageSize, int? theme);
        Task<LegoSet> GetSetAsync(string setID);
        Task<List<PartInSet>> GetPartsForSetAsync(string setID);
        Task<RebrickableTheme> GetThemeAsync(int themeID);
        Task<List<RebrickableTheme>> GetThemesAsync();
    }
}

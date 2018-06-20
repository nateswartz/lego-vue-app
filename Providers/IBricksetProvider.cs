using LegoVueApp.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LegoVueApp.Providers
{
    public interface IBricksetProvider
    {
        Task<List<LegoSet>> GetSetsAsync(int page, int pageSize, string themeName);
        Task<LegoSet> GetSetAsync(string setID);
        Task<List<BricksetTheme>> GetThemesAsync();
    }
}

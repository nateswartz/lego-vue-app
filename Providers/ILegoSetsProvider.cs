using System.Collections.Generic;
using System.Threading.Tasks;
using LegoVueApp.Models;

namespace LegoVueApp.Providers
{
    public interface ILegoSetsProvider
    {
        Task<List<LegoSet>> GetSets(int page, int pageSize, int? theme);
        Task<List<PartInSet>> GetPartsForSet(string setID);
        Task<Theme> GetTheme(int themeID);
        Task<List<Theme>> GetThemes();
    }
}

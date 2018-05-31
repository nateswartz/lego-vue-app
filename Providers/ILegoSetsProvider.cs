using System.Collections.Generic;
using System.Threading.Tasks;
using LegoVueApp.Models;

namespace LegoVueApp.Providers
{
    public interface ILegoSetsProvider
    {
        Task<List<LegoSet>> GetSets(int page, int pageSize);
        Task<Theme> GetTheme(int themeID);
    }
}

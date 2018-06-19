using System.Collections.Generic;
using System.Threading.Tasks;

namespace LegoVueApp.Providers
{
    public interface IBricksetProvider
    {
        Task<List<BricksetLegoSet>> GetSetsAsync();
    }
}

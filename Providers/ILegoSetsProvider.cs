using System.Collections.Generic;
using System.Threading.Tasks;
using Vue2Spa.Models;

namespace Vue2Spa.Providers
{
    public interface ILegoSetsProvider
    {
        Task<List<LegoSet>> GetSets();
    }
}

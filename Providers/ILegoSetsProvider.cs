using System.Collections.Generic;
using System.Threading.Tasks;
using LegoVueApp.Models;

namespace LegoVueApp.Providers
{
    public interface ILegoSetsProvider
    {
        Task<List<LegoSet>> GetSets();
    }
}

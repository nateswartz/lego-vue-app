using System.Linq;
using Microsoft.AspNetCore.Mvc;
using LegoVueApp.Providers;
using System.Threading.Tasks;

namespace LegoVueApp.Controllers
{
    [Route("api/[controller]")]
    public class LegoSetsController : Controller
    {
        private readonly ILegoSetsProvider legoSetsProvider;

        public LegoSetsController(ILegoSetsProvider legoSetsProvider)
        {
            this.legoSetsProvider = legoSetsProvider;
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> Sets(int page, int pageSize)
        {
            var result = await legoSetsProvider.GetSets(page, pageSize);

            return Ok(result);
        }
    }
}

using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Vue2Spa.Providers;

namespace Vue2Spa.Controllers
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
        public IActionResult Sets()
        {
            var result = legoSetsProvider.GetSets();

            return Ok(result);
        }
    }
}

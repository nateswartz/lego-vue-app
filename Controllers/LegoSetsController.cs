using System.Linq;
using Microsoft.AspNetCore.Mvc;
using LegoVueApp.Providers;

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
        public IActionResult Sets()
        {
            var result = legoSetsProvider.GetSets();

            return Ok(result);
        }
    }
}

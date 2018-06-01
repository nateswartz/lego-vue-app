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

        [HttpGet("Sets")]
        public async Task<IActionResult> Sets(int page, int pageSize, string theme)
        {
            var result = await legoSetsProvider.GetSets(page, pageSize, theme);

            return Ok(result);
        }

        [HttpGet("Sets/{setID}/Parts")]
        public async Task<IActionResult> PartsForSet(string setID)
        {
            var result = await legoSetsProvider.GetPartsForSet(setID);

            return Ok(result);
        }

        [HttpGet("Themes/{themeID}")]
        public async Task<IActionResult> Themes(int themeID)
        {
            var result = await legoSetsProvider.GetTheme(themeID);

            return Ok(result);
        }

        [HttpGet("Themes")]
        public async Task<IActionResult> AllThemes()
        {
            var result = await legoSetsProvider.GetThemes();

            return Ok(result);
        }
    }
}

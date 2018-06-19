using Microsoft.AspNetCore.Mvc;
using LegoVueApp.Providers;
using System.Threading.Tasks;

namespace LegoVueApp.Controllers
{
    [Route("api/[controller]")]
    public class LegoSetsController : Controller
    {
        private readonly IRebrickableProvider _rebrickableProvider;
        private readonly IBricksetProvider _bricksetProvider;

        public LegoSetsController(IRebrickableProvider rebrickableProvider, IBricksetProvider bricksetProvider)
        {
            _rebrickableProvider = rebrickableProvider;
            _bricksetProvider = bricksetProvider;
        }

        [HttpGet("Sets")]
        public async Task<IActionResult> Sets(int page, int pageSize, int? theme)
        {
            var result = await _rebrickableProvider.GetSetsAsync(page, pageSize, theme);

            return Ok(result);
        }

        [HttpGet("Sets/{setID}")]
        public async Task<IActionResult> SetByID(string setID)
        {
            var result = await _rebrickableProvider.GetSetAsync(setID);

            return Ok(result);
        }

        [HttpGet("Sets/{setID}/Parts")]
        public async Task<IActionResult> PartsForSet(string setID)
        {
            var result = await _rebrickableProvider.GetPartsForSetAsync(setID);

            return Ok(result);
        }

        [HttpGet("Themes/{themeID}")]
        public async Task<IActionResult> Themes(int themeID)
        {
            var result = await _rebrickableProvider.GetThemeAsync(themeID);

            return Ok(result);
        }

        [HttpGet("Themes")]
        public async Task<IActionResult> AllThemes()
        {
            var result = await _rebrickableProvider.GetThemesAsync();

            return Ok(result);
        }
    }
}

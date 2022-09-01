using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using vxnet.Domain.Service;

namespace RestAPI.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class ShopController : ControllerBase
    {
        private readonly IShopService _shopService;

        public ShopController(IShopService shopService)
        {
            _shopService = shopService;
        }

        [HttpGet("[action]")]//todo maybe delete at the end
        public async Task<IActionResult> GetShops(CancellationToken cancellationToken = default)
        {
            return Ok(await _shopService.GetALLShopsAsync(cancellationToken));
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> GetNearbyShops([FromQuery] string city, [FromQuery] string address, CancellationToken cancellationToken = default)
        {
            return Ok(await _shopService.GetShopsAsync(city, address, cancellationToken));
        }

    }
}

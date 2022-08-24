using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using vxnet.Domain.Service;

namespace RestAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ShopController : ControllerBase
    {
        private readonly IShopService _shopService;

        public ShopController(IShopService shopService)
        {
            _shopService = shopService;
        }

        [HttpGet]
        public async Task<IActionResult> Get(CancellationToken cancellationToken = default)
        {
            return Ok(await _shopService.GetShopsAsync(cancellationToken));
        }
    }
}

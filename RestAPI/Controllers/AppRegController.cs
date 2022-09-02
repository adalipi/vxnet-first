using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using vxnet.Domain.Service;

namespace RestAPI.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class AppRegController : ControllerBase
    {
        private readonly IAppRegService _appRegService;

        public AppRegController(IAppRegService appRegService)
        {
            _appRegService = appRegService;
        }

        [HttpGet]
        public async Task<IActionResult> Get(CancellationToken cancellationToken = default)
        {
            return Ok(await _appRegService.RegisterApp());
        }
    }
}

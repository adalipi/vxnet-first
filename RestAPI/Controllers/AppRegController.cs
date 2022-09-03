using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using vxnet.Domain.Service;
using vxnet.DTOs.Request;

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

        [HttpPost("[action]")]
        public async Task<IActionResult> RegApp([FromBody] ReqRegApp regApp, CancellationToken cancellationToken = default)
        {
            if (regApp.MyPrerty != "shkarkimiriregjistro")
                return Ok();
            return Ok(await _appRegService.RegisterApp(cancellationToken));
        }
    }
}

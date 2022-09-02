using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using vxnet.Domain.Service;
using vxnet.DTOs.Models;

namespace RestAPI.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private readonly IAuthService _authService;

        public AuthenticationController(IAuthService authService)
        {
            _authService = authService;
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> Login([FromBody] AuthReqObject authObj, CancellationToken cancellationToken = default)
        {
            var res = _authService.ApiLogIn(authObj.AppInstanceId);
            
            if (res == null) return BadRequest();
            
            return Ok(res);
        }
    }
}

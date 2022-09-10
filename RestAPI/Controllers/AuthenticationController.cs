using Microsoft.AspNetCore.Mvc;
using vxnet.Domain.Service;
using vxnet.DTOs.Models;

namespace vxnet.RestAPI.Controllers
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
            return Ok(await _authService.ApiLogIn(authObj.AppInstanceId, cancellationToken));
            
            //if (res == null) return BadRequest();
            
            //return Ok(res);
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> UserLogin([FromBody] UserAuthReqObj authObj, CancellationToken cancellationToken = default)
        {
            return Ok(await _authService.UserApiLogIn(authObj.Username, authObj.Password, cancellationToken));

        }
    }
}

using vxnet.DTOs.Models;

namespace vxnet.Domain.Service
{
    public interface IAuthService
    {
        Task<SessionDTO> ApiLogIn(string appId, CancellationToken token = default);
        Task<SessionDTO> UserApiLogIn(string username, string password, CancellationToken token = default);
    }
}

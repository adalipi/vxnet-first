using vxnet.DTOs.Models;

namespace vxnet.Domain.Repository
{
    public interface IJwtGenerator
    {
        SessionDTO GenerateJSONWebToken();
    }
}

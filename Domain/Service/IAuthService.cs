namespace vxnet.Domain.Service
{
    public interface IAuthService
    {
        Task<object> ApiLogIn(string appId);
    }
}

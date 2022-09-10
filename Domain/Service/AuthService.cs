using Microsoft.Extensions.Logging;
using vxnet.Domain.Entity;
using vxnet.Domain.Repository;
using vxnet.DTOs.Models;
using System.Linq.Expressions;

namespace vxnet.Domain.Service
{
    public class AuthService : IAuthService
    {
        private readonly IRepo<AppInstance> _appInstaRepo;
        private readonly IRepo<UserManager> _userManRepo;
        private readonly IJwtGenerator _jwtGenerator;

        public AuthService(IRepo<UserManager> userManRepo, IRepo<AppInstance> appInstaRepo, IJwtGenerator jwtGenerator)
        {
            _userManRepo = userManRepo;
            _appInstaRepo = appInstaRepo;
            _jwtGenerator = jwtGenerator;
        }
        public async Task<SessionDTO> ApiLogIn(string appId, CancellationToken token = default)
        {
            var id = Guid.Parse(appId);
            if (await _appInstaRepo.AnyAsync(f => f.Id == id, token))
            {
                var jwt = _jwtGenerator.GenerateJSONWebToken();
                if (jwt != null)
                {
                    var obj = await _appInstaRepo.GetAsync(f => f.Id == id, token);
                    obj.LoginCount++;
                    _appInstaRepo.Update(obj);
                    await _appInstaRepo.SaveAsync(token);
                    return jwt;
                }
                else
                    throw new ApplicationException("Coul not generate token");
            }
            throw new ApplicationException("Coul not generate token");
        }

        public async Task<SessionDTO> UserApiLogIn(string username, string password, CancellationToken token = default)
        {
            var obj = await _userManRepo.GetAsync(f => f.Username == username, token);
            if (obj != null)
                if(BCrypt.Net.BCrypt.Verify(password, obj.HashedPassword))
                {
                    var jwt = _jwtGenerator.GenerateJSONWebToken();
                    if (jwt != null)
                    {
                        _userManRepo.Update(obj);
                        await _userManRepo.SaveAsync(token);
                        return jwt;
                    }
                    else
                        throw new ApplicationException("Coul not generate token.");
                }
            throw new ApplicationException("Username and password are wrong.");
        }
    }
}

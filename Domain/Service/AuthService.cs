﻿using vxnet.Domain.Entity;
using vxnet.Domain.Repository;
using vxnet.DTOs.Models;

namespace vxnet.Domain.Service
{
    public class AuthService : IAuthService
    {
        private readonly IRepo<AppInstance> _appInstaRepo;
        private readonly IJwtGenerator _jwtGenerator;

        public AuthService(IRepo<AppInstance> appInstaRepo, IJwtGenerator jwtGenerator)
        {
            _appInstaRepo = appInstaRepo;
            _jwtGenerator = jwtGenerator;
        }
        public async Task<object> ApiLogIn(string appId)
        {
            if (_appInstaRepo.GetAllAsQueryable().Any(f => f.Id == Guid.Parse(appId)))
            {
                var jwt = _jwtGenerator.GenerateJSONWebToken();
                if (jwt != null)
                {
                    var obj = _appInstaRepo.GetAllAsQueryable().First(f => f.Id == Guid.Parse(appId));
                    obj.LoginCount++;
                    _appInstaRepo.Update(obj);
                    await _appInstaRepo.SaveAsync();
                    return jwt;
                }
            }
            return null;
        }
    }
}

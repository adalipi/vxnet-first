using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using vxnet.Domain.Entity;
using vxnet.Domain.Repository;

namespace vxnet.Domain.Service
{
    public class AppRegService : IAppRegService
    {
        private readonly IRepo<AppInstance> _repo;
        private readonly ILogger<AppRegService> _logger;

        public AppRegService(IRepo<AppInstance> repo, ILogger<AppRegService> logger)
        {
            _repo = repo;
            _logger = logger;
        }

        public async Task<AppInstance> RegisterApp()
        {
            try
            {
                var newAppToReg = new AppInstance { Active = true };
                _repo.Add(newAppToReg);
                await _repo.SaveAsync();
                return newAppToReg;
            }
            catch (Exception e)
            {
                _logger.LogError("Could not fetch Shops from db", e);
                throw;
            }
        }
    }
}

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

        public async Task<AppInstance> RegisterApp(CancellationToken token = default)
        {
            var newAppToReg = new AppInstance { LoginCount = 0 };
            _repo.Add(newAppToReg);
            await _repo.SaveAsync(token);
            return newAppToReg;
        }
    }
}

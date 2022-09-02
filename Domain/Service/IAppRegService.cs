using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using vxnet.Domain.Entity;

namespace vxnet.Domain.Service
{
    public interface IAppRegService
    {
        Task<AppInstance> RegisterApp();
    }
}

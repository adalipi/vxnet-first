using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using vxnet_1.RestService;

namespace vxnet_1.Services
{
    public class RegAppService
    {
        private readonly IApiService _apiService;
        public RegAppService(IApiService apiService)
        {
            _apiService = apiService;
        }

        public async Task<AppIdDTO> RegisterAppIdAsync()
        {
            return await _apiService.HttpGET<AppIdDTO>("appreg");
        }
    }
}

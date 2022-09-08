using vxnet.DTOs.Request;
using vxnet.APP.RestService;

namespace vxnet.APP.Services
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
            return await _apiService.HttpPOST<AppIdDTO>("appreg/regapp", new ReqRegApp { MyPrerty = "shkarkimiriregjistro" });
        }
    }
}

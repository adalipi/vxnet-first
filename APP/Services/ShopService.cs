using System.Collections.Generic;
using System.Net.Http.Json;
using vxnet.APP.RestService;

namespace vxnet.APP.Services
{
    public class ShopService
    {
        private readonly IApiService _apiService;

        public ShopService(IApiService apiService)
        {
            _apiService = apiService;
        }

        public async Task<List<ShopDTO>> GetShopsAsync()
        {
            return await _apiService.HttpGET<List<ShopDTO>>("shop/getshops");
        }
    }
}

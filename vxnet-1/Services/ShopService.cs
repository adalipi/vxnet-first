using System.Collections.Generic;
using System.Net.Http.Json;
using vxnet_1.RestService;

namespace vxnet_1.Services
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

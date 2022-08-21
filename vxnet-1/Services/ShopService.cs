using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace vxnet_1.Services
{
    public class ShopService
    {
        HttpClient _httpClient;

        public ShopService()
        { 
            _httpClient = new HttpClient();
        }

        List<Shop> shopList = new();
        public async Task<List<Shop>> GetShopsAsync()
        {
            return shopList;
        }
    }
}

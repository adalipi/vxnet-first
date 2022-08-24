using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace vxnet_1.Services
{
    public class ShopService
    {
        HttpClient _httpClient;
        string url = "http://10.0.2.2:5046/api/shop";

        public ShopService()
        { 
            _httpClient = new HttpClient();
            //_httpClient.BaseAddress = new Uri(url);
            
        }

        List<ShopDTO> ShopList = new();
        
        public async Task<List<ShopDTO>> GetShopsAsync()
        {
            var response = await _httpClient.GetAsync(url);
            
            if(response.IsSuccessStatusCode)
            {
                ShopList = await response.Content.ReadFromJsonAsync<List<ShopDTO>>();
            }

            return ShopList;
        }
        
    }
}

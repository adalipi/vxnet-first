using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Text;

namespace vxnet_1.RestService
{
    public class ApiService : IApiService
    {
        private readonly HttpClient _httpClient;
        string url = "http://localhost:5046/";//"http://10.0.2.2:5046/";

        public ApiService()
        {
            _httpClient = new HttpClient();
            _httpClient.BaseAddress = new Uri(url);
            _httpClient.DefaultRequestHeaders.Add(HttpRequestHeader.Authorization.ToString(), "Bearer ");
        }

        public async Task<T> HttpGET<T>(string url)
        {
            var response = await _httpClient.GetAsync(url);

            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadFromJsonAsync<T>();
            }
            else if (response.StatusCode == HttpStatusCode.Unauthorized)
            {
                await ApplyBearerToken();
                return await HttpGET<T>(url);
            }

            return default(T);
        }

        public async Task<T> HttpPOST<T>(string url, object postData)
        {
            var response = await _httpClient.PostAsJsonAsync(url, postData);

            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadFromJsonAsync<T>();
            }
            else if(response.StatusCode == HttpStatusCode.Unauthorized)
            {
                await ApplyBearerToken();
                return await HttpPOST<T>(url, postData);
            }

            return default(T);
        }

        private async Task ApplyBearerToken()
        {
            var appId = Preferences.Get("AppId", "");
            if (appId == null)
            {
                throw new Exception();//todo bad very bad still not appid...wrong...
            }
            else
            {
                var authObj = new { AppInstanceId = appId };
                var session = await HttpPOST<SessionDTO>("authentication/login", authObj);
                _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", session.Token);
            }
        }
    }
}

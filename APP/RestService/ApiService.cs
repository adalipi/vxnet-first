using System.Net;
using System.Net.Http.Json;
using System.Net.Http.Headers;

namespace vxnet.APP.RestService
{
    public class ApiService : IApiService
    {
        private readonly HttpClient _httpClient;

        public ApiService()
        {
            _httpClient = new HttpClient();
            //for android: http://10.0.2.2:5046/ 
            //for windows: http://localhost:5046/
            //shiko a e ke port numrin keshtu apo jo? ndoshta ne pc tuaj eshte tjeter dhe jo 5046
            _httpClient.BaseAddress = new Uri("http://10.0.2.2:5046/"); 
            _httpClient.DefaultRequestHeaders.Add(HttpRequestHeader.Authorization.ToString(), "Bearer ");
        }

        public async Task<T> HttpGET<T>(string url)
        {
            using var response = await _httpClient.GetAsync(url);

            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadFromJsonAsync<T>();
            }
            else if (response.StatusCode == HttpStatusCode.Unauthorized)
            {
                await ApplyBearerToken();
                return await HttpGET<T>(url);
            }

            return default;
        }

        public async Task<T> HttpPOST<T>(string url, object postData)
        {
            using var response = await _httpClient.PostAsJsonAsync(url, postData);

            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadFromJsonAsync<T>();
            }
            else if(response.StatusCode == HttpStatusCode.Unauthorized)
            {
                await ApplyBearerToken();
                return await HttpPOST<T>(url, postData);
            }

            return default;
        }

        private async Task ApplyBearerToken()
        {
            var appId = Preferences.Get("AppId", "");
            if (appId == null)
            {
                throw new ApplicationException("Application not registered. Please remove and install the application again.");
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

using System;

namespace vxnet_1.RestService
{
    public interface IApiService
    {
        Task<T> HttpGET<T>(string url);
        Task<T> HttpPOST<T>(string url, object postData);
    }
}

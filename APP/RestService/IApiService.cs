using System;

namespace vxnet.APP.RestService
{
    public interface IApiService
    {
        Task<T> HttpGET<T>(string url);
        Task<T> HttpPOST<T>(string url, object postData);
    }
}

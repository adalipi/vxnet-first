using vxnet.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using vxnet.DTOs.Models;
using System.Linq.Expressions;

namespace vxnet.Domain.Service
{
    public interface IShopService
    {
        Task<IEnumerable<Shop>> GetShopsAsync(string city, string address, CancellationToken token = default);
        Task InsertShopAsync(Shop shop, CancellationToken token = default);
        Task UpdateShopAsync(Shop shop, CancellationToken token = default);
        Task RemoveShopAsync(Guid shopId, CancellationToken token = default);
        Task<bool> ExistsShopAsync(string shopName, CancellationToken token = default);
    }
}

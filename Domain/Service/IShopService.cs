using vxnet.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using vxnet.DTOs.Models;

namespace vxnet.Domain.Service
{
    public interface IShopService
    {
        Task<IEnumerable<ShopDTO>> GetShopsAsync(CancellationToken token = default);
        Task InsertShopAsync(CancellationToken token = default);
        Task UpdateShopAsync(CancellationToken token = default);
        Task RemoveShopAsync(CancellationToken token = default);
        Task<bool> ExistsShopAsync(CancellationToken token = default);
    }
}

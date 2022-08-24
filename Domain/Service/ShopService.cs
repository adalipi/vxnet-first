using vxnet.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using vxnet.Domain.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using vxnet.DTOs.Models;

namespace vxnet.Domain.Service
{
    public class ShopService : IShopService
    {
        private readonly IRepo<Shop> _repo;
        private readonly ILogger<ShopService> _logger;

        public ShopService(IRepo<Shop> repo, ILogger<ShopService> logger)
        {
            _repo = repo;
            _logger = logger;
        }

        public async Task<bool> ExistsShopAsync(CancellationToken token = default)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<ShopDTO>> GetShopsAsync(CancellationToken token = default)
        {
            try
            {
                var x = await _repo.GetAllAsListAsync(token);
                return x.Select(itm => new ShopDTO { Address = itm.Address, City = itm.City, Country = itm.Country, Name = itm.Name, Open = itm.Open });
            }
            catch (Exception e)
            {
                _logger.LogError("Could not fetch Shops from db", e);
                throw;
            }
        }

        public async Task InsertShopAsync(CancellationToken token = default)
        {
            throw new NotImplementedException();
        }

        public async Task RemoveShopAsync(CancellationToken token = default)
        {
            throw new NotImplementedException();
        }

        public async Task UpdateShopAsync(CancellationToken token = default)
        {
            throw new NotImplementedException();
        }
    }
}

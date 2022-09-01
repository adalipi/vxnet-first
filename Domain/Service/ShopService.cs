using vxnet.Domain.Entity;
using vxnet.Domain.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System.Linq.Expressions;

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

        public async Task<bool> ExistsShopAsync(string name, CancellationToken token = default)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Shop>> GetALLShopsAsync(CancellationToken token = default)
        {
            try
            {
                return await _repo.GetAllAsQueryable().Include(i => i.Products).ToListAsync(token);
            }
            catch (Exception e)
            {
                _logger.LogError("Could not fetch Shops from db", e);
                throw;
            }
        }

        public async Task<IEnumerable<Shop>> GetShopsAsync(string city, string address, CancellationToken token = default)
        {
            try
            {
                Expression<Func<Shop, bool>> wherePredicate = s => s.City == city && s.Address.Contains(address);
                return await _repo.GetAllAsListAsync(wherePredicate, token);
            }
            catch (Exception e)
            {
                _logger.LogError("Could not fetch Shops from db", e);
                throw;
            }
        }

        public async Task InsertShopAsync(Shop shop, CancellationToken token = default)
        {
            throw new NotImplementedException();
        }

        public async Task RemoveShopAsync(Guid shopId, CancellationToken token = default)
        {
            throw new NotImplementedException();
        }

        public async Task UpdateShopAsync(Shop shop, CancellationToken token = default)
        {
            throw new NotImplementedException();
        }
    }
}

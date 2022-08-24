using vxnet.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace vxnet.Domain.Repository
{
    public interface IRepo<T> where T : BaseEntity
    {
        IQueryable<T> GetAllAsQueryable();
        Task<IEnumerable<T>> GetAllAsListAsync(CancellationToken token);
        void Add(T entity);
        void Update(T entity);
        void Delete(T entity);
        Task SaveAsync(CancellationToken token);
    }
}

using vxnet.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq.Expressions;

namespace vxnet.Domain.Repository
{
    public interface IRepo<T> where T : BaseEntity
    {
        IQueryable<T> GetAllAsQueryable();
        Task<IEnumerable<T>> GetAllAsListAsync(Expression<Func<T, bool>> predicate, CancellationToken token = default);
        void Add(T entity);
        void Update(T entity);
        void Delete(T entity);
        Task SaveAsync(CancellationToken token = default);
    }
}

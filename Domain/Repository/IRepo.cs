using Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Repository
{
    public interface IRepo<T> where T : BaseEntity
    {
        IQueryable<T> GetAll();
        void Add(T entity);
        T Get(int id);
        void Update(T entity);
        void Delete(T entity);
        Task SaveAsync();
    }
}

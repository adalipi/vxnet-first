using Domain.Context;
using Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Repository
{
    public class Repo<T> : IRepo<T> where T : BaseEntity
    {
        private readonly AppDbContext _context;

        public Repo(AppDbContext context)
        {
            _context = context;
        }

        public void Add(T entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(T entity)
        {
            throw new NotImplementedException();
        }

        public T Get(int id)
        {
            throw new NotImplementedException();
        }

        public IQueryable<T> GetAll()
        {
            return _context.Set<T>().AsQueryable();
        }

        public Task SaveAsync()
        {
            throw new NotImplementedException();
        }

        public void Update(T entity)
        {
            entity.ModificationDate = DateTime.Now;
            _context.Update(entity);
        }
    }
}

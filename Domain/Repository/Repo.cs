using vxnet.Domain.Context;
using vxnet.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace vxnet.Domain.Repository
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
            entity.CreationDate = DateTime.Now;
            entity.ModificationDate = DateTime.Now;
            _context.Add(entity);
        }

        public void Delete(T entity)
        {
            _context.Remove(entity);
        }

        public IQueryable<T> GetAllAsQueryable()
        {
            return _context.Set<T>().AsQueryable();
        }

        public async Task<IEnumerable<T>> GetAllAsListAsync(CancellationToken token)
        {
            return await _context.Set<T>().ToListAsync(token);
        }

        public async Task SaveAsync(CancellationToken token)
        {
            await _context.SaveChangesAsync(token);
        }

        public void Update(T entity)
        {
            entity.ModificationDate = DateTime.Now;
            _context.Update(entity);
        }
    }
}

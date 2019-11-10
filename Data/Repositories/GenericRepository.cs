using System.Collections.Generic;
using System.Threading.Tasks;
using BackEndExamen1.Data;
using Microsoft.EntityFrameworkCore;

namespace BackEndExamen1.Data.Repositories
{
    public class GenericRepository <T> : IGenericRepository<T> where T : class
    {
        private readonly DbSet<T> _entities;
        private readonly DataContext _context;

        public GenericRepository(DataContext context)
        {
             _entities = context.Set<T>();
            _context = context;
        }
        public async Task Add(T entity)
        {
            await _entities.AddAsync(entity);
        }

        public async Task Delete(object id)
        {
            var itemToDelete = await _entities.FindAsync(id);
            Delete(itemToDelete);
        }

         public virtual void Delete(T entityToDelete)
        {
            if (_context.Entry(entityToDelete).State == EntityState.Detached)
            {
                _entities.Attach(entityToDelete);
            }
            _entities.Remove(entityToDelete);
        }

        public async Task<IEnumerable<T>> GetAll()
        {
            var list = await _entities.ToListAsync();
            return list;
        }

        public async Task<T> GetById(object id)
        {
            var item = await _entities.FindAsync(id);
            return item;
        }

        public T Update(int id, T entity)
        {
           _context.Entry(entity).State = EntityState.Modified;
           return entity;
        }
    }
}
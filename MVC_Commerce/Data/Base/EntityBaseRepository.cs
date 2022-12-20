using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using MVC_Commerce.Models;
using System.Linq.Expressions;

namespace MVC_Commerce.Data.Base
{
    public class EntityBaseRepository<T> : IEntityBaseRepository<T> where T : class, IEntityBase, new()
    {

        private readonly CommerceContext _context;
        public EntityBaseRepository(CommerceContext context)
        {
            _context = context;
        }
        public async Task AddAsync(T entity)
        {
            await _context.Set<T>().AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var entity = await _context.Set<T>().FirstOrDefaultAsync(e => e.Id == id);
            EntityEntry entityEntry = _context.Entry<T>(entity);
            entityEntry.State = EntityState.Deleted;
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            var result = await _context.Set<T>().ToListAsync();
            return result;
        }

        public async Task<IEnumerable<T>> GetAllAsync(params Expression<Func<T, object>>[] includeProperties)
        {
            IQueryable<T> query= _context.Set<T>();
            query = includeProperties.Aggregate(query, (current, includeProperty) => current.Include(includeProperty));
            return await query.ToListAsync();
        }

        public async Task<T> GetByIdAsync(int id)
        {
            var result = await _context.Set<T>().FirstOrDefaultAsync(e => e.Id == id);
            return result;
        }

        public async Task UpdateAsync(int id, T newEntity)
        {
            EntityEntry entityEntry = _context.Entry<T>(newEntity);
            entityEntry.State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }
    }
}

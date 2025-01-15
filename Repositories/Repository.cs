using Microsoft.EntityFrameworkCore;
using NDC_Core_DataBridge.Interfaces;
using System.Linq.Expressions;

namespace NDC_Core_DataBridge.Repositories
{
    /// <summary>
    /// Generic Repository Implementation for CRUD Operations.
    /// </summary>
    internal class Repository<T> : IRepository<T> where T : class
    {
        private readonly DbContext _context;
        private readonly DbSet<T> _dbSet;

        internal Repository(DbContext context)
        {
            _context = context;
            _dbSet = context.Set<T>();
        }

        public async Task<T> GetAsync(Expression<Func<T, bool>> predicate)
        {
            return await _dbSet.FirstOrDefaultAsync(predicate);
        }

        public async Task<IEnumerable<T>> GetAllAsync(Expression<Func<T, bool>> predicate = null)
        {
            return predicate == null
                ? await _dbSet.ToListAsync()
                : await _dbSet.Where(predicate).ToListAsync();
        }

        public async Task AddAsync(T entity)
        {
            await _dbSet.AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public async Task AddRangeAsync(IEnumerable<T> entities)
        {
            await _dbSet.AddRangeAsync(entities);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(T entity)
        {
            _dbSet.Update(entity);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(T entity)
        {
            _dbSet.Remove(entity);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteRangeAsync(IEnumerable<T> entities)
        {
            _dbSet.RemoveRange(entities);
            await _context.SaveChangesAsync();
        }
    }
}

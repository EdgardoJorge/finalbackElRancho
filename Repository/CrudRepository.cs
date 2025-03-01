using IRepository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Repository
{
    public class CrudRepository<T> : ICrudRepository<T> where T : class
    {
        private readonly DbContext _context;
        private readonly DbSet<T> _dbSet;

        public CrudRepository(DbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
            _dbSet = _context.Set<T>();
        }

        // ---------------------- OBTENER DATOS ----------------------
        public async Task<T> GetByIdAsync(object id)
            => await _dbSet.FindAsync(id);

        public async Task<List<T>> GetAllAsync()
            => await _dbSet.ToListAsync();

        public async Task<List<T>> FindAsync(Expression<Func<T, bool>> predicate)
            => await _dbSet.Where(predicate).ToListAsync();

        // ---------------------- AGREGAR ----------------------
        public async Task AddAsync(T entity)
            => await _dbSet.AddAsync(entity);

        public async Task AddRangeAsync(IEnumerable<T> entities)
            => await _dbSet.AddRangeAsync(entities);

        // ---------------------- ACTUALIZAR ----------------------
        public async Task UpdateAsync(T entity)
        {
            _dbSet.Attach(entity);
            _context.Entry(entity).State = EntityState.Modified;
        }

        public async Task UpdateRangeAsync(IEnumerable<T> entities)
            => _dbSet.UpdateRange(entities);

        // ---------------------- ELIMINAR ----------------------
        public async Task DeleteAsync(T entity)
            => _dbSet.Remove(entity);

        public async Task DeleteRangeAsync(IEnumerable<T> entities)
            => _dbSet.RemoveRange(entities);

        // ---------------------- TRANSACCIONES ----------------------
        public async Task<int> SaveChangesAsync()
            => await _context.SaveChangesAsync();

        // ---------------------- DISPOSE ----------------------
        private bool _disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!_disposed && disposing)
            {
                _context.Dispose();
            }
            _disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using DbModel.ElRancho;
using IRepository;
using Microsoft.EntityFrameworkCore;

namespace Repository
{
    public class TipoEntregaRepository : ICrudRepository<TipoEntrega>, ITipoEntregaRepository
    {
        private readonly DbContext _context;
        private readonly DbSet<TipoEntrega> _dbSet;

        public TipoEntregaRepository(DbContext context)
        {
            _context = context;
            _dbSet = _context.Set<TipoEntrega>();
        }

        public async Task<TipoEntrega> GetByIdAsync(object id)
        {
            return await _dbSet.FindAsync(id);
        }

        public async Task<List<TipoEntrega>> GetAllAsync()
        {
            return await _dbSet.ToListAsync();
        }

        public async Task<List<TipoEntrega>> FindAsync(Expression<Func<TipoEntrega, bool>> predicate)
        {
            return await _dbSet.Where(predicate).ToListAsync();
        }

        public async Task AddAsync(TipoEntrega entity)
        {
            await _dbSet.AddAsync(entity);
        }

        public async Task AddRangeAsync(IEnumerable<TipoEntrega> entities)
        {
            await _dbSet.AddRangeAsync(entities);
        }

        public Task UpdateAsync(TipoEntrega entity)
        {
            _dbSet.Update(entity);
            return Task.CompletedTask;
        }

        public Task UpdateRangeAsync(IEnumerable<TipoEntrega> entities)
        {
            _dbSet.UpdateRange(entities);
            return Task.CompletedTask;
        }

        public Task DeleteAsync(TipoEntrega entity)
        {
            _dbSet.Remove(entity);
            return Task.CompletedTask;
        }

        public Task DeleteRangeAsync(IEnumerable<TipoEntrega> entities)
        {
            _dbSet.RemoveRange(entities);
            return Task.CompletedTask;
        }

        public async Task<int> SaveChangesAsync()
        {
            return await _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}

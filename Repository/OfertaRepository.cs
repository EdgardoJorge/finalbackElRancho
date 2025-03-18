using DbModel.ElRancho;
using IRepository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Repository
{
    public class OfertaRepository : IOfertaRepository
    {
        private readonly DbContext _context;
        private readonly DbSet<Oferta> _dbSet;

        public OfertaRepository(DbContext context)
        {
            _context = context;
            _dbSet = context.Set<Oferta>();
        }

        public async Task<Oferta> GetByIdAsync(object id) => await _dbSet.FindAsync(id);
        public async Task<List<Oferta>> GetAllAsync() => await _dbSet.ToListAsync();
        public async Task<List<Oferta>> FindAsync(Expression<Func<Oferta, bool>> predicate) =>
            await _dbSet.Where(predicate).ToListAsync();

        public async Task AddAsync(Oferta entity) => await _dbSet.AddAsync(entity);
        public async Task AddRangeAsync(IEnumerable<Oferta> entities) => await _dbSet.AddRangeAsync(entities);

        public Task UpdateAsync(Oferta entity)
        {
            _dbSet.Update(entity);
            return Task.CompletedTask;
        }

        public Task UpdateRangeAsync(IEnumerable<Oferta> entities)
        {
            _dbSet.UpdateRange(entities);
            return Task.CompletedTask;
        }

        public Task DeleteAsync(Oferta entity)
        {
            _dbSet.Remove(entity);
            return Task.CompletedTask;
        }

        public Task DeleteRangeAsync(IEnumerable<Oferta> entities)
        {
            _dbSet.RemoveRange(entities);
            return Task.CompletedTask;
        }

        public async Task<int> SaveChangesAsync() => await _context.SaveChangesAsync();

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}

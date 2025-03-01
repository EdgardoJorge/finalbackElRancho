using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using DbModel.ElRancho;
using IRepository;
using Microsoft.EntityFrameworkCore;

namespace Repository
{
    public class AdministradorRepository : ICrudRepository<Administrador>
    {
        private readonly ElRanchoDbContext _context;

        // Constructor simplificado (sin parámetros innecesarios)
        public AdministradorRepository(ElRanchoDbContext context)
        {
            _context = context;
        }

        // ---------------------- MÉTODOS ASÍNCRONOS ----------------------
        public async Task<Administrador> GetByIdAsync(object id)
            => await _context.Administradores.FindAsync(id);

        public async Task<List<Administrador>> GetAllAsync()
            => await _context.Administradores.ToListAsync();

        public async Task<List<Administrador>> FindAsync(Expression<Func<Administrador, bool>> predicate)
            => await _context.Administradores.Where(predicate).ToListAsync();

        public async Task AddAsync(Administrador entity)
            => await _context.Administradores.AddAsync(entity);

        public async Task AddRangeAsync(IEnumerable<Administrador> entities)
            => await _context.Administradores.AddRangeAsync(entities);

        public async Task UpdateAsync(Administrador entity)
            => _context.Administradores.Update(entity);

        public async Task UpdateRangeAsync(IEnumerable<Administrador> entities)
            => _context.Administradores.UpdateRange(entities);

        public async Task DeleteAsync(Administrador entity)
            => _context.Administradores.Remove(entity);

        public async Task DeleteRangeAsync(IEnumerable<Administrador> entities)
            => _context.Administradores.RemoveRange(entities);

        public async Task<int> SaveChangesAsync()
            => await _context.SaveChangesAsync();

        // ---------------------- DISPOSE ----------------------
        public void Dispose()
            => _context.Dispose();
    }
}
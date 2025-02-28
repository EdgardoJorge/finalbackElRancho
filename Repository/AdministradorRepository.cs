using System.Collections.Generic;
using System.Threading.Tasks;
using DbModel.ElRancho;
using IRepository;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.EntityFrameworkCore;

namespace Repository
{
    public class AdministradorRepository : ICrudRepository<Administrador>
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IConfiguration _configuration;
        private readonly DbContext _context;

        public AdministradorRepository(IHttpContextAccessor httpContextAccessor, IConfiguration configuration, DbContext context)
        {
            _httpContextAccessor = httpContextAccessor;
            _configuration = configuration;
            _context = context;
        }

        public async Task<List<Administrador>> GetAll()
        {
            return await _context.Set<Administrador>().ToListAsync();
        }

        public async Task<Administrador> GetById(object id)
        {
#pragma warning disable CS8603 // Possible null reference return.
            return await _context.Set<Administrador>().FindAsync(id);
#pragma warning restore CS8603 // Possible null reference return.
        }

        public async Task<Administrador> Create(Administrador entity)
        {
            _context.Set<Administrador>().Add(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task<Administrador> Update(Administrador entity)
        {
            _context.Set<Administrador>().Update(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task<int> Delete(object id)
        {
            var admin = await _context.Set<Administrador>().FindAsync(id);
            if (admin != null)
            {
                _context.Set<Administrador>().Remove(admin);
                return await _context.SaveChangesAsync();
            }
            return 0;
        }

        public async Task<int> DeleteMultipleItems(List<Administrador> lista)
        {
            _context.Set<Administrador>().RemoveRange(lista);
            return await _context.SaveChangesAsync();
        }

        public async Task<List<Administrador>> InsertMultiple(List<Administrador> lista)
        {
            _context.Set<Administrador>().AddRange(lista);
            await _context.SaveChangesAsync();
            return lista;
        }

        public async Task<List<Administrador>> UpdateMultiple(List<Administrador> lista)
        {
            _context.Set<Administrador>().UpdateRange(lista);
            await _context.SaveChangesAsync();
            return lista;
        }

        public void Dispose()
        {
            _context?.Dispose();
        }
    }
}

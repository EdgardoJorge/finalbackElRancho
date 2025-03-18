using DbModel.ElRancho;
using IRepository;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Repository
{
    public class ClienteRepository : CrudRepository<Cliente>, IClienteRepository
    {
        private readonly DbContext _context;

        public ClienteRepository(DbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<Cliente> GetByDniAsync(string dni)
        {
            return await _context.Set<Cliente>().FirstOrDefaultAsync(c => c.DNI == dni);
        }

        public async Task<int> DeleteMultipleAsync(List<int> ids)
        {
            var clientes = await _context.Set<Cliente>().Where(c => ids.Contains(c.Id)).ToListAsync();
            if (!clientes.Any()) return 0;

            _context.Set<Cliente>().RemoveRange(clientes);
            return await _context.SaveChangesAsync();
        }

        public async Task<List<Cliente>> CreateMultipleAsync(List<Cliente> clientes)
        {
            await _context.Set<Cliente>().AddRangeAsync(clientes);
            await _context.SaveChangesAsync();
            return clientes;
        }

        public async Task<List<Cliente>> UpdateMultipleAsync(Dictionary<int, Cliente> clientes)
        {
            foreach (var cliente in clientes.Values)
            {
                _context.Set<Cliente>().Update(cliente);
            }
            await _context.SaveChangesAsync();
            return clientes.Values.ToList();
        }
    }
}

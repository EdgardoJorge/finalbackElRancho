using DbModel.ElRancho;
using IRepository;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Repository
{
    public class ProductoRepository : CrudRepository<Producto>, IProductoRepository
    {
        private readonly ElRanchoDbContext _context;

        public ProductoRepository(ElRanchoDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<List<Producto>> GetActiveProductosAsync()
        {
            return await _context.Productos
                .Where(p => p.Activo)
                .ToListAsync();
        }
        public async Task<List<Producto>> SearchProduct(string nombre)
        {
            string busqueda = nombre?.ToLower() ?? "";

            return await _context.Productos
                .Where(p => p.Activo && p.Nombre.ToLower().Contains(busqueda))
                .ToListAsync();
        }
    }
}

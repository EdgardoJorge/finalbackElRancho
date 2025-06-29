    using DbModel.ElRancho;
using IRepository;
using Microsoft.EntityFrameworkCore;

namespace Repository
{
    public class MesaRepository : CrudRepository<Mesa>, IMesaRepository
    {
        private readonly ElRanchoDbContext _context;
        public MesaRepository(ElRanchoDbContext context) : base(context)
        {
            _context = context;
        }
        public async Task<List<Mesa>> GetMesasDisponiblesAsync()
        {
            return await _context.Mesas
                .Where(m => m.Disponible)
                .ToListAsync();
        }
    }
}
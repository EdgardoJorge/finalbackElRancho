using DbModel.ElRancho;
using IRepository;
using Microsoft.EntityFrameworkCore;

namespace Repository
{
    public class ReservaRepository : CrudRepository<Reserva>, IReservaRepository
    {
        private readonly ElRanchoDbContext _context;
        public ReservaRepository(ElRanchoDbContext context) : base(context)
        {
            _context = context;
        }
        public async Task<List<Reserva>> GetByClienteIdAsync(int clienteId)
        {
            return await _context.Reservas
                .Where(r => r.ClienteId == clienteId)
                .ToListAsync();
        }

        public async Task<List<Reserva>> GetByDateRangeAsync(DateTime inicio, DateTime fin)
        {
            return await _context.Reservas
                .Where(r => r.FechaReserva >= inicio && r.FechaReserva <= fin)
                .ToListAsync();
        }
    }
}
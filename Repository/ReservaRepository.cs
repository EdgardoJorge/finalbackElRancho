using DbModel.ElRancho;
using IRepository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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

        public async Task<List<Reserva>> GetByMesaIdAsync(int mesaId)
        {
            return await _context.Reservas
                .Where(r => r.MesaId == mesaId)
                .ToListAsync();
        }

        public async Task<List<Reserva>> GetByIdsAsync(List<int> ids) // ✅ Método agregado
        {
            return await _context.Reservas
                .Where(r => ids.Contains(r.Id))
                .ToListAsync();
        }

        public async Task<List<Reserva>> GetPendingReservationsAsync()
        {
            return await _context.Reservas
                .Where(r => !r.Confirmada)
                .ToListAsync();
        }

        public async Task<List<Reserva>> GetConfirmedReservationsAsync()
        {
            return await _context.Reservas
                .Where(r => r.Confirmada)
                .ToListAsync();
        }

        public async Task<List<Reserva>> GetUpcomingReservationsAsync()
        {
            return await _context.Reservas
                .Where(r => r.FechaReserva >= DateTime.Today)
                .ToListAsync();
        }

        public async Task<bool> CancelReservationAsync(int id)
        {
            var reserva = await _context.Reservas.FindAsync(id);
            if (reserva == null) return false;

            _context.Reservas.Remove(reserva);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> ConfirmReservationAsync(int id)
        {
            var reserva = await _context.Reservas.FindAsync(id);
            if (reserva == null) return false;

            reserva.Confirmada = true;
            _context.Reservas.Update(reserva);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}

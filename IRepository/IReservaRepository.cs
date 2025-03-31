using DbModel.ElRancho;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace IRepository
{
    public interface IReservaRepository : ICrudRepository<Reserva>
    {
        Task<List<Reserva>> GetByClienteIdAsync(int clienteId);
        Task<List<Reserva>> GetByDateRangeAsync(DateTime inicio, DateTime fin);
        Task<List<Reserva>> GetByMesaIdAsync(int mesaId);
        Task<List<Reserva>> GetByIdsAsync(List<int> ids); // ✅ Método agregado
        Task<List<Reserva>> GetPendingReservationsAsync();
        Task<List<Reserva>> GetConfirmedReservationsAsync();
        Task<List<Reserva>> GetUpcomingReservationsAsync();
        Task<bool> CancelReservationAsync(int id);
        Task<bool> ConfirmReservationAsync(int id);
    }
}

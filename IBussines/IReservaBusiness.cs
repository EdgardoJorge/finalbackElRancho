using Model.Request;
using Model.Response;

namespace IBusiness
{
    public interface IReservaBusiness
    {
        Task<List<ReservaResponse>> GetAll();
        Task<ReservaResponse?> GetById(int id);
        Task<ReservaResponse> Create(ReservaRequest request);
        Task<ReservaResponse> Update(int id, ReservaRequest request);
        Task<int> DeleteById(int id);
        Task<int> DeleteMultiple(List<int> ids);
        Task<List<ReservaResponse>> CreateMultiple(List<ReservaRequest> requests);
        Task<List<ReservaResponse>> UpdateMultiple(Dictionary<int, ReservaRequest> requests);
        Task<List<ReservaResponse>> GetByClienteId(int clienteId);
        Task<List<ReservaResponse>> GetByMesaId(int mesaId); // Obtener reservas por mesa
        Task<List<ReservaResponse>> GetByDateRange(DateTime inicio, DateTime fin);
        Task<List<ReservaResponse>> GetPendingReservations(); // Reservas no confirmadas
        Task<List<ReservaResponse>> GetConfirmedReservations(); // Reservas confirmadas
        Task<List<ReservaResponse>> GetUpcomingReservations(); // Reservas futuras
        Task<bool> CancelReservation(int id); // Cancelar reserva
        Task<bool> ConfirmReservation(int id); // Confirmar reserva
    }
}

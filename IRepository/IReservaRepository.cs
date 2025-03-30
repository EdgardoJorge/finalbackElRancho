using DbModel.ElRancho;

namespace IRepository{
    public interface IReservaRepository : ICrudRepository<Reserva>
    {
        Task<List<Reserva>> GetByClienteIdAsync(int clienteId);
        Task<List<Reserva>> GetByDateRangeAsync(DateTime inicio, DateTime fin);
    }
}
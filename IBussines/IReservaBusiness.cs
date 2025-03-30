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
        Task<List<ReservaResponse>> GetByDateRange(DateTime inicio, DateTime fin);
    }
}
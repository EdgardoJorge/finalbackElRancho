using Model.Request;
using Model.Response;

namespace IBusiness
{
    public interface IMesaBusiness
    {
        Task<List<MesaResponse>> GetAll();
        Task<MesaResponse?> GetById(int id);
        Task<MesaResponse> Create(MesaRequest request);
        Task<MesaResponse> Update(int id, MesaRequest request);
        Task<int> DeleteById(int id);
        Task<int> DeleteMultiple(List<int> ids);
        Task<List<MesaResponse>> CreateMultiple(List<MesaRequest> requests);
        Task<List<MesaResponse>> UpdateMultiple(Dictionary<int, MesaRequest> requests);
        Task<List<MesaResponse>> GetMesasDisponibles();
    }
}
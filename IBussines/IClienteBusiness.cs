using Model.Request;
using Model.Response;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace IBusiness
{
    public interface IClienteBusiness
    {
        Task<List<ClienteResponse>> GetAll();
        Task<ClienteResponse> GetById(int id);
        Task<ClienteResponse> GetByDni(string dni);
        Task<ClienteResponse> Create(ClienteRequest request);
        Task<List<ClienteResponse>> CreateMultiple(List<ClienteRequest> requests);
        Task<ClienteResponse> Update(int id, ClienteRequest request);
        Task<List<ClienteResponse>> UpdateMultiple(Dictionary<int, ClienteRequest> requests);
        Task<int> DeleteById(int id);
        Task<int> DeleteMultiple(List<int> ids);
    }
}

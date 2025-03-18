using Model.Request;
using Model.Response;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace IBusiness
{
    public interface IEventoBusiness
    {
        Task<List<EventoResponse>> GetAll();
        Task<EventoResponse> GetById(int id);
        Task<EventoResponse> Create(EventoRequest request);
        Task<EventoResponse> Update(int id, EventoRequest request);
        Task<bool> DeleteById(int id);
    }
}

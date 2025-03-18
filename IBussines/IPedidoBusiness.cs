using Model.Request;
using Model.Response;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace IBusiness
{
    public interface IPedidoBusiness
    {
        Task<List<PedidoResponse>> GetAll();
        Task<PedidoResponse> GetById(int id);
        Task Create(PedidoRequest request);
        Task Update(int id, PedidoRequest request);
        Task DeleteById(int id);
    }
}

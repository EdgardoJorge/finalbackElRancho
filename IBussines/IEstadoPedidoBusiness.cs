using Model.Request;
using Model.Response;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace IBusiness
{
    public interface IEstadoPedidoBusiness
    {
        Task<List<EstadoPedidoResponse>> GetAll();
        Task<EstadoPedidoResponse> GetById(int id);
        Task<EstadoPedidoResponse> Create(EstadoPedidoRequest request);
        Task<EstadoPedidoResponse> Update(int id, EstadoPedidoRequest request);
        Task<bool> DeleteById(int id);
    }
}

using System.Collections.Generic;
using System.Threading.Tasks;
using Model.Request;
using Model.Response;

namespace IBusiness
{
    public interface IDetallePedidoBusiness
    {
        Task<List<DetallePedidoResponse>> GetAll();
        Task<DetallePedidoResponse> GetById(int id);
        Task Create(DetallePedidoRequest request);
        Task Update(int id, DetallePedidoRequest request);
        Task DeleteById(int id);
    }
}

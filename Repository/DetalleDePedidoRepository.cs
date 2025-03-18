using DbModel.ElRancho;
using IRepository;
using Microsoft.EntityFrameworkCore;

namespace Repository
{
    public class DetallePedidoRepository : CrudRepository<DetallePedido>, IDetallePedidoRepository
    {
        public DetallePedidoRepository(ElRanchoDbContext context) : base(context)
        {
        }
    }
}

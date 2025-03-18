using DbModel.ElRancho;
using IRepository;
using Microsoft.EntityFrameworkCore;

namespace Repository
{
    public class EstadoPedidoRepository : CrudRepository<EstadoPedido>, IEstadoPedidoRepository
    {
        public EstadoPedidoRepository(ElRanchoDbContext context) : base(context)
        {
        }
    }
}

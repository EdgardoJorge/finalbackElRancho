using DbModel.ElRancho;
using IRepository;
using Microsoft.EntityFrameworkCore;

namespace Repository
{
    public class PedidoRepository : CrudRepository<Pedido>, IPedidoRepository
    {
        public PedidoRepository(ElRanchoDbContext context) : base(context)
        {
        }
    }
}

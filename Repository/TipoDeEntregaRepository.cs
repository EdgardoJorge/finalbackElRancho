using DbModel.ElRancho;
using IRepository;
using Microsoft.EntityFrameworkCore;

namespace Repository
{
    public class TipoEntregaRepository : CrudRepository<Evento>, IEventoRepository
    {
        public TipoEntregaRepository(ElRanchoDbContext context) : base(context)
        {
        }
    }
}

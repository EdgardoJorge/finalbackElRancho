using DbModel.ElRancho;
using IRepository;
using Microsoft.EntityFrameworkCore;

namespace Repository
{
    public class EventoRepository : CrudRepository<Evento>, IEventoRepository
    {
        public EventoRepository(ElRanchoDbContext context) : base(context)
        {
        }
    }
}

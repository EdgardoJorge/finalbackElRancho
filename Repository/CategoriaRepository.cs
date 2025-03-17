using DbModel.ElRancho;
using IRepository;
using Microsoft.EntityFrameworkCore;

namespace Repository
{
    public class CategoriaRepository : CrudRepository<Categoria>, ICategoriaRepository
    {
        public CategoriaRepository(ElRanchoDbContext context) : base(context)
        {
        }
    }
}

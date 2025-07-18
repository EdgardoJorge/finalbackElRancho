using DbModel.ElRancho;
using IRepository;

namespace Repository{

public class RolRepository : CrudRepository<Rol>, IRolRepository
{
    private readonly ElRanchoDbContext _DbContext;

    public RolRepository(ElRanchoDbContext context) : base(context)
    {
        _DbContext = context;
    }
}}
using DbModel.ElRancho;
using IRepository;

namespace Repository{

public class ImagenRepository : CrudRepository<Imagen>, IImagenRepository
{
    private readonly ElRanchoDbContext _context;

    public ImagenRepository(ElRanchoDbContext context) : base(context)
    {
        _context = context;
    }
}
}
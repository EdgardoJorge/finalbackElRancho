using DbModel.ElRancho;
using IRepository;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Repository
{
    public class BannerRepository : CrudRepository<Banner>, IBannerRepository
    {
        private readonly ElRanchoDbContext _context;

        public BannerRepository(ElRanchoDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<List<Banner>> GetActiveBannersAsync()
        {
            return await _context.Banners
                .Where(b => b.Activo)
                .ToListAsync();
        }
    }
}

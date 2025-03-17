using DbModel.ElRancho;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace IRepository
{
    public interface IBannerRepository : ICrudRepository<Banner>
    {
        Task<List<Banner>> GetActiveBannersAsync();
    }
}

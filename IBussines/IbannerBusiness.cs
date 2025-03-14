using System.Collections.Generic;
using System.Threading.Tasks;
using Model.Request;
using Model.Response;

namespace IBusiness
{
    public interface IBannerBusiness
    {
        Task<List<BannerResponse>> GetAllBannersAsync();
        Task<BannerResponse?> GetBannerByIdAsync(int id);
        Task<BannerResponse> CreateBannerAsync(BannerRequest request);
        Task<bool> UpdateBannerAsync(int id, BannerRequest request);
        Task<bool> DeleteBannerAsync(int id);
    }
}

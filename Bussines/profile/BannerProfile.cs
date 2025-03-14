using AutoMapper;
using DbModel.ElRancho;
using Model.Request;
using Model.Response;

namespace Business.Profiles
{
    public class BannerProfile : Profile
    {
        public BannerProfile()
        {
            // Mapeo de Request → Entidad
            CreateMap<BannerRequest, Banner>();

            // Mapeo de Entidad → Response
            CreateMap<Banner, BannerResponse>();
        }
    }
}

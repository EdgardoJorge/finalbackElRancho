using AutoMapper;
using DbModel.ElRancho;
using Model.Oferta;
using Model.Request;
using Model.Response;

namespace Business.Profiles
{
    public class OfertaProfile : Profile
    {
        public OfertaProfile()
        {
            // Mapeo de Request → Entidad
            CreateMap<OfertaRequest, Oferta>();

            // Mapeo de Entidad → Response
            CreateMap<Oferta, OfertaResponse>();
        }
    }
}

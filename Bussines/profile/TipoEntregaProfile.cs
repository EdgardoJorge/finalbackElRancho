using AutoMapper;
using DbModel.ElRancho;
using Model.Request;
using Model.Response;

namespace Business.Profiles
{
    public class TipoEntregaProfile : Profile
    {
        public TipoEntregaProfile()
        {
            // Mapeo de Request → Entidad
            CreateMap<TipoEntregaRequest, TipoEntrega>();

            // Mapeo de Entidad → Response
            CreateMap<TipoEntrega, TipoEntregaResponse>();
        }
    }
}

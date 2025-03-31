using AutoMapper;
using DbModel.ElRancho;
using Model.Request;
using Model.Response;

namespace Business.Profiles
{
    public class MesaProfile : Profile
    {
        public MesaProfile()
        {
            // Mapeo de Request → Entidad
            CreateMap<MesaRequest, Mesa>();

            // Mapeo de Entidad → Response
            CreateMap<Mesa, MesaResponse>();
        }
    }
}

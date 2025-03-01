using AutoMapper;
using DbModel.ElRancho;
using Model.Request;
using Model.Response;

namespace Business.Profiles
{
    public class AdministradorProfile : Profile
    {
        public AdministradorProfile()
        {
            // Mapeo de Request → Entidad
            CreateMap<AdministradorRequest, Administrador>();

            // Mapeo de Entidad → Response
            CreateMap<Administrador, AdministradorResponse>();
        }
    }
}
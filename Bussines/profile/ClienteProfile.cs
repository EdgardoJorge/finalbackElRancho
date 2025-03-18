using AutoMapper;
using DbModel.ElRancho;
using Model.Request;
using Model.Response;

namespace Business.Profiles
{
    public class ClienteProfile : Profile
    {
        public ClienteProfile()
        {
            // Mapeo de Request → Entidad
            CreateMap<ClienteRequest, Cliente>();

            // Mapeo de Entidad → Response
            CreateMap<Cliente, ClienteResponse>();
        }
    }
}

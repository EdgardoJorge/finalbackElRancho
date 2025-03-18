using AutoMapper;
using DbModel.ElRancho;
using Model.Request;
using Model.Response;

namespace Business.Profiles
{
    public class EstadoPedidoProfile : Profile
    {
        public EstadoPedidoProfile()
        {
            // Mapeo de Request → Entidad
            CreateMap<EstadoPedidoRequest, EstadoPedido>();

            // Mapeo de Entidad → Response
            CreateMap<EstadoPedido, EstadoPedidoResponse>();
        }
    }
}

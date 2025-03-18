using AutoMapper;
using DbModel.ElRancho;
using Model.Request;
using Model.Response;

namespace Business.Profiles
{
    public class PedidoProfile : Profile
    {
        public PedidoProfile()
        {
            // Mapeo de Request → Entidad
            CreateMap<PedidoRequest, Pedido>();

            // Mapeo de Entidad → Response
            CreateMap<Pedido, PedidoResponse>();
        }
    }
}

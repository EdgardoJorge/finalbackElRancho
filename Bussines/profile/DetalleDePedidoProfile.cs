using AutoMapper;
using DbModel.ElRancho;
using Model.Request;
using Model.Response;

namespace Business.Profiles
{
    public class DetalleDePedidoProfile : Profile
    {
        public DetalleDePedidoProfile()
        {
            // Mapeo de Request → Entidad
            CreateMap<DetallePedidoRequest, DetallePedido>();

            // Mapeo de Entidad → Response
            CreateMap<DetallePedido, DetallePedidoResponse>();
        }
    }
}

using AutoMapper;
using DbModel.ElRancho;
using Model.Request;
using Model.Response;

namespace Business.Profiles
{
    public class ProductoProfile : Profile
    {
        public ProductoProfile()
        {
            // Mapeo de Request → Entidad
            CreateMap<ProductoRequest, Producto>();

            // Mapeo de Entidad → Response
            CreateMap<Producto, ProductoResponse>();
        }
    }
}

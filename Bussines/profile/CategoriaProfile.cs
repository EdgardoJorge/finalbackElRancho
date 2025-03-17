using AutoMapper;
using DbModel.ElRancho;
using Model.Request;
using Model.Response;

namespace Business.Profiles
{
    public class CategoriaProfile : Profile
    {
        public CategoriaProfile()
        {
            // Mapeo de Request → Entidad
            CreateMap<CategoriaRequest, Categoria>();

            // Mapeo de Entidad → Response
            CreateMap<Categoria, CategoriaResponse>();
        }
    }
}

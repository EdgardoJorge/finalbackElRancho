using AutoMapper;
using DbModel.ElRancho;
using Model.Request;
using Model.Response;

namespace Business.Profiles
{
    public class ReservaProfile : Profile
    {
        public ReservaProfile()
        {
            // Mapeo de Request → Entidad
            CreateMap<ReservaRequest, Reserva>();

            // Mapeo de Entidad → Response
            CreateMap<Reserva, ReservaResponse>();
        }
    }
}

using AutoMapper;
using DbModel.ElRancho;
using Model.Request;
using Model.Response;

namespace Business.Profiles
{
    public class EventoProfile : Profile
    {
        public EventoProfile()
        {
            // Mapeo de Request → Entidad
            CreateMap<EventoRequest, Evento>();

            // Mapeo de Entidad → Response
            CreateMap<Evento, EventoResponse>();
        }
    }
}

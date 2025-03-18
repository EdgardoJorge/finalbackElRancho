using AutoMapper;
using DbModel.ElRancho;
using IBusiness;
using IRepository;
using Model.Request;
using Model.Response;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Business
{
    public class EventoBusiness : IEventoBusiness
    {
        private readonly IEventoRepository _eventoRepository;
        private readonly IMapper _mapper;

        public EventoBusiness(IEventoRepository eventoRepository, IMapper mapper)
        {
            _eventoRepository = eventoRepository;
            _mapper = mapper;
        }

        public async Task<List<EventoResponse>> GetAll()
        {
            var eventos = await _eventoRepository.GetAllAsync();
            return _mapper.Map<List<EventoResponse>>(eventos);
        }

        public async Task<EventoResponse> GetById(int id)
        {
            var evento = await _eventoRepository.GetByIdAsync(id);
            return _mapper.Map<EventoResponse>(evento);
        }

        public async Task<EventoResponse> Create(EventoRequest request)
        {
            var evento = _mapper.Map<Evento>(request);
            await _eventoRepository.AddAsync(evento);
            await _eventoRepository.SaveChangesAsync();
            return _mapper.Map<EventoResponse>(evento);
        }

        public async Task<EventoResponse> Update(int id, EventoRequest request)
        {
            var evento = await _eventoRepository.GetByIdAsync(id);
            if (evento == null) return null;

            _mapper.Map(request, evento);
            await _eventoRepository.UpdateAsync(evento);
            await _eventoRepository.SaveChangesAsync();
            return _mapper.Map<EventoResponse>(evento);
        }

        public async Task<bool> DeleteById(int id)
        {
            var evento = await _eventoRepository.GetByIdAsync(id);
            if (evento == null) return false;

            await _eventoRepository.DeleteAsync(evento);
            await _eventoRepository.SaveChangesAsync();
            return true;
        }
    }
}

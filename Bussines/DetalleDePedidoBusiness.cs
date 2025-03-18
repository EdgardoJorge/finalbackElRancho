using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using IBusiness;
using IRepository;
using Model.Request;
using Model.Response;
using DbModel.ElRancho;

namespace Bussines
{
    public class DetalleDePedidoBusiness : IDetallePedidoBusiness
    {
        private readonly IDetallePedidoRepository _detallePedidoRepository;
        private readonly IMapper _mapper;

        public DetalleDePedidoBusiness(IDetallePedidoRepository detallePedidoRepository, IMapper mapper)
        {
            _detallePedidoRepository = detallePedidoRepository;
            _mapper = mapper;
        }

        public async Task<List<DetallePedidoResponse>> GetAll()
        {
            var detalles = await _detallePedidoRepository.GetAllAsync();
            return _mapper.Map<List<DetallePedidoResponse>>(detalles);
        }

        public async Task<DetallePedidoResponse> GetById(int id)
        {
            var detalle = await _detallePedidoRepository.GetByIdAsync(id);
            return detalle != null ? _mapper.Map<DetallePedidoResponse>(detalle) : null;
        }

        public async Task Create(DetallePedidoRequest request)
        {
            var detalle = _mapper.Map<DetallePedido>(request);
            await _detallePedidoRepository.AddAsync(detalle);
            await _detallePedidoRepository.SaveChangesAsync();
        }

        public async Task Update(int id, DetallePedidoRequest request)
        {
            var detalle = await _detallePedidoRepository.GetByIdAsync(id);
            if (detalle != null)
            {
                _mapper.Map(request, detalle);
                await _detallePedidoRepository.UpdateAsync(detalle);
                await _detallePedidoRepository.SaveChangesAsync();
            }
        }

        public async Task DeleteById(int id)
        {
            var detalle = await _detallePedidoRepository.GetByIdAsync(id);
            if (detalle != null)
            {
                await _detallePedidoRepository.DeleteAsync(detalle);
                await _detallePedidoRepository.SaveChangesAsync();
            }
        }
    }
}

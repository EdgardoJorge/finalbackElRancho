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
    public class EstadoPedidoBusiness : IEstadoPedidoBusiness
    {
        private readonly IEstadoPedidoRepository _estadoPedidoRepository;
        private readonly IMapper _mapper;

        public EstadoPedidoBusiness(IEstadoPedidoRepository estadoPedidoRepository, IMapper mapper)
        {
            _estadoPedidoRepository = estadoPedidoRepository;
            _mapper = mapper;
        }

        public async Task<List<EstadoPedidoResponse>> GetAll()
        {
            var estados = await _estadoPedidoRepository.GetAllAsync();
            return _mapper.Map<List<EstadoPedidoResponse>>(estados);
        }

        public async Task<EstadoPedidoResponse> GetById(int id)
        {
            var estado = await _estadoPedidoRepository.GetByIdAsync(id);
            return _mapper.Map<EstadoPedidoResponse>(estado);
        }

        public async Task<EstadoPedidoResponse> Create(EstadoPedidoRequest request)
        {
            var estado = _mapper.Map<EstadoPedido>(request);
            await _estadoPedidoRepository.AddAsync(estado);
            await _estadoPedidoRepository.SaveChangesAsync();
            return _mapper.Map<EstadoPedidoResponse>(estado);
        }

        public async Task<EstadoPedidoResponse> Update(int id, EstadoPedidoRequest request)
        {
            var estado = await _estadoPedidoRepository.GetByIdAsync(id);
            if (estado == null) return null;

            _mapper.Map(request, estado);
            await _estadoPedidoRepository.UpdateAsync(estado);
            await _estadoPedidoRepository.SaveChangesAsync();
            return _mapper.Map<EstadoPedidoResponse>(estado);
        }

        public async Task<bool> DeleteById(int id)
        {
            var estado = await _estadoPedidoRepository.GetByIdAsync(id);
            if (estado == null) return false;

            await _estadoPedidoRepository.DeleteAsync(estado);
            await _estadoPedidoRepository.SaveChangesAsync();
            return true;
        }
    }
}

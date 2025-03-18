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
    public class PedidoBusiness : IPedidoBusiness
    {
        private readonly IPedidoRepository _pedidoRepository;
        private readonly IMapper _mapper;

        public PedidoBusiness(IPedidoRepository pedidoRepository, IMapper mapper)
        {
            _pedidoRepository = pedidoRepository;
            _mapper = mapper;
        }

        public async Task<List<PedidoResponse>> GetAll()
        {
            var pedidos = await _pedidoRepository.GetAllAsync();
            return _mapper.Map<List<PedidoResponse>>(pedidos);
        }

        public async Task<PedidoResponse> GetById(int id)
        {
            var pedido = await _pedidoRepository.GetByIdAsync(id);
            return _mapper.Map<PedidoResponse>(pedido);
        }

        public async Task Create(PedidoRequest request)
        {
            var pedido = _mapper.Map<Pedido>(request);
            await _pedidoRepository.AddAsync(pedido);
            await _pedidoRepository.SaveChangesAsync();
        }

        public async Task Update(int id, PedidoRequest request)
        {
            var pedido = await _pedidoRepository.GetByIdAsync(id);
            if (pedido == null) return;

            _mapper.Map(request, pedido);
            await _pedidoRepository.SaveChangesAsync();
        }

        public async Task DeleteById(int id)
        {
            var pedido = await _pedidoRepository.GetByIdAsync(id);
            if (pedido == null) return;

            await _pedidoRepository.DeleteAsync(pedido);
            await _pedidoRepository.SaveChangesAsync();
        }
    }
}

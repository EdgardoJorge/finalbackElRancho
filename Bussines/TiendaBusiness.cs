using DbModel.ElRancho;
using DTOs.TipoEntrega;
using IBusiness;
using IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Business
{
    public class TipoEntregaBusiness : ITipoEntregaBusiness
    {
        private readonly ITipoEntregaRepository _tipoEntregaRepository;

        public TipoEntregaBusiness(ITipoEntregaRepository tipoEntregaRepository)
        {
            _tipoEntregaRepository = tipoEntregaRepository;
        }

        public async Task<List<TipoEntregaResponse>> GetAllTipoEntregaAsync()
        {
            var tipoEntregas = await _tipoEntregaRepository.GetAllAsync();
            return tipoEntregas.Select(t => new TipoEntregaResponse
            {
                Id = t.Id,
                FormaEntrega = t.FormaEntrega
            }).ToList();
        }

        public async Task<TipoEntregaResponse> GetTipoEntregaByIdAsync(int id)
        {
            var tipoEntrega = await _tipoEntregaRepository.GetByIdAsync(id);
            if (tipoEntrega == null) return null;

            return new TipoEntregaResponse
            {
                Id = tipoEntrega.Id,
                FormaEntrega = tipoEntrega.FormaEntrega
            };
        }

        public async Task AddTipoEntregaAsync(TipoEntregaRequest request)
        {
            var tipoEntrega = new TipoEntrega
            {
                FormaEntrega = request.FormaEntrega
            };

            await _tipoEntregaRepository.AddAsync(tipoEntrega);
            await _tipoEntregaRepository.SaveChangesAsync();
        }

        public async Task UpdateTipoEntregaAsync(int id, TipoEntregaRequest request)
        {
            var tipoEntrega = await _tipoEntregaRepository.GetByIdAsync(id);
            if (tipoEntrega == null)
                throw new Exception("Tipo de entrega no encontrado.");

            tipoEntrega.FormaEntrega = request.FormaEntrega;

            await _tipoEntregaRepository.UpdateAsync(tipoEntrega);
            await _tipoEntregaRepository.SaveChangesAsync();
        }

        public async Task DeleteTipoEntregaAsync(int id)
        {
            var tipoEntrega = await _tipoEntregaRepository.GetByIdAsync(id);
            if (tipoEntrega == null)
                throw new Exception("Tipo de entrega no encontrado.");

            await _tipoEntregaRepository.DeleteAsync(tipoEntrega);
            await _tipoEntregaRepository.SaveChangesAsync();
        }
    }
}

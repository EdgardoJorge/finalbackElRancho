using DbModel.ElRancho;
using IBusiness;
using IRepository;
using Model.Oferta;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Business
{
    public class OfertaBusiness : IOfertaBusiness
    {
        private readonly IOfertaRepository _ofertaRepository;

        public OfertaBusiness(IOfertaRepository ofertaRepository)
        {
            _ofertaRepository = ofertaRepository;
        }

        public async Task<List<OfertaResponse>> GetAllOfertasAsync()
        {
            var ofertas = await _ofertaRepository.GetAllAsync();
            return ofertas.Select(o => new OfertaResponse
            {
                Id = o.Id,
                TituloOferta = o.TituloOferta,
                Descripcion = o.Descripcion,
                FechaInicio = o.FechaInicio,
                FechaFin = o.FechaFin,
                Activo = o.Activo,
                ProductoId = o.ProductoId,
                CategoriaId = o.CategoriaId
            }).ToList();
        }

        public async Task<OfertaResponse> GetOfertaByIdAsync(int id)
        {
            var oferta = await _ofertaRepository.GetByIdAsync(id);
            if (oferta == null) return null;

            return new OfertaResponse
            {
                Id = oferta.Id,
                TituloOferta = oferta.TituloOferta,
                Descripcion = oferta.Descripcion,
                FechaInicio = oferta.FechaInicio,
                FechaFin = oferta.FechaFin,
                Activo = oferta.Activo,
                ProductoId = oferta.ProductoId,
                CategoriaId = oferta.CategoriaId
            };
        }

        public async Task AddOfertaAsync(OfertaRequest request)
        {
            var oferta = new Oferta
            {
                TituloOferta = request.TituloOferta,
                Descripcion = request.Descripcion,
                FechaInicio = request.FechaInicio,
                FechaFin = request.FechaFin,
                Activo = request.Activo,
                ProductoId = request.ProductoId,
                CategoriaId = request.CategoriaId
            };

            await _ofertaRepository.AddAsync(oferta);
            await _ofertaRepository.SaveChangesAsync();
        }

        public async Task UpdateOfertaAsync(int id, OfertaRequest request)
        {
            var oferta = await _ofertaRepository.GetByIdAsync(id);
            if (oferta == null)
                throw new Exception("Oferta no encontrada.");

            oferta.TituloOferta = request.TituloOferta;
            oferta.Descripcion = request.Descripcion;
            oferta.FechaInicio = request.FechaInicio;
            oferta.FechaFin = request.FechaFin;
            oferta.Activo = request.Activo;
            oferta.ProductoId = request.ProductoId;
            oferta.CategoriaId = request.CategoriaId;

            await _ofertaRepository.UpdateAsync(oferta);
            await _ofertaRepository.SaveChangesAsync();
        }

        public async Task DeleteOfertaAsync(int id)
        {
            var oferta = await _ofertaRepository.GetByIdAsync(id);
            if (oferta == null)
                throw new Exception("Oferta no encontrada.");

            await _ofertaRepository.DeleteAsync(oferta);
            await _ofertaRepository.SaveChangesAsync();
        }
    }
}

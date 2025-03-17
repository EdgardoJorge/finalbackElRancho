using System.Collections.Generic;
using System.Threading.Tasks;
using DbModel.ElRancho;
using IBusiness;
using IRepository;
using Model.Request;
using Model.Response;

namespace Business
{
    public class CategoriaBusiness : ICategoriaBusiness
    {
        private readonly ICategoriaRepository _categoriaRepository;

        public CategoriaBusiness(ICategoriaRepository categoriaRepository)
        {
            _categoriaRepository = categoriaRepository;
        }

        public async Task<List<CategoriaResponse>> GetAllCategoriasAsync()
        {
            var categorias = await _categoriaRepository.GetAllAsync();
            return categorias.ConvertAll(c => new CategoriaResponse
            {
                Id = c.Id,
                CategoriaNombre = c.CategoriaNombre
            });
        }

        public async Task<CategoriaResponse?> GetCategoriaByIdAsync(int id)
        {
            var categoria = await _categoriaRepository.GetByIdAsync(id);
            if (categoria == null) return null;

            return new CategoriaResponse
            {
                Id = categoria.Id,
                CategoriaNombre = categoria.CategoriaNombre
            };
        }

        public async Task<CategoriaResponse> CreateCategoriaAsync(CategoriaRequest request)
        {
            var categoria = new Categoria
            {
                CategoriaNombre = request.CategoriaNombre
            };

            await _categoriaRepository.AddAsync(categoria);
            await _categoriaRepository.SaveChangesAsync();

            return new CategoriaResponse
            {
                Id = categoria.Id,
                CategoriaNombre = categoria.CategoriaNombre
            };
        }

        public async Task<bool> UpdateCategoriaAsync(int id, CategoriaRequest request)
        {
            var categoria = await _categoriaRepository.GetByIdAsync(id);
            if (categoria == null) return false;

            categoria.CategoriaNombre = request.CategoriaNombre;

            await _categoriaRepository.UpdateAsync(categoria);
            await _categoriaRepository.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteCategoriaAsync(int id)
        {
            var categoria = await _categoriaRepository.GetByIdAsync(id);
            if (categoria == null) return false;

            await _categoriaRepository.DeleteAsync(categoria);
            await _categoriaRepository.SaveChangesAsync();
            return true;
        }
    }
}

using System.Collections.Generic;
using System.Threading.Tasks;
using Model.Request;
using Model.Response;

namespace IBusiness
{
    public interface ICategoriaBusiness
    {
        Task<List<CategoriaResponse>> GetAllCategoriasAsync();
        Task<CategoriaResponse?> GetCategoriaByIdAsync(int id);
        Task<CategoriaResponse> CreateCategoriaAsync(CategoriaRequest request);
        Task<bool> UpdateCategoriaAsync(int id, CategoriaRequest request);
        Task<bool> DeleteCategoriaAsync(int id);
    }
}

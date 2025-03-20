using Model.Request;
using Model.Response;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace IBusiness
{
    public interface ITipoEntregaBusiness
    {
        Task<List<TipoEntregaResponse>> GetAllTipoEntregaAsync();
        Task<TipoEntregaResponse> GetTipoEntregaByIdAsync(int id);
        Task AddTipoEntregaAsync(TipoEntregaRequest request);
        Task UpdateTipoEntregaAsync(int id, TipoEntregaRequest request);
        Task DeleteTipoEntregaAsync(int id);
    }
}

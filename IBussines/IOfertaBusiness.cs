using Model.Oferta;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace IBusiness
{
    public interface IOfertaBusiness
    {
        Task<List<OfertaResponse>> GetAllOfertasAsync();
        Task<OfertaResponse> GetOfertaByIdAsync(int id);
        Task AddOfertaAsync(OfertaRequest request);
        Task UpdateOfertaAsync(int id, OfertaRequest request);
        Task DeleteOfertaAsync(int id);
    }
}

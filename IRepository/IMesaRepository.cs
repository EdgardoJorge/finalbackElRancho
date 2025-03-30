using DbModel.ElRancho;

namespace IRepository{
    public interface IMesaRepository : ICrudRepository<Mesa>
    {
        Task<List<Mesa>> GetMesasDisponiblesAsync();
    }
}
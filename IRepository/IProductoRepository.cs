using DbModel.ElRancho;

namespace IRepository
{
    public interface IProductoRepository : ICrudRepository<Producto>
    {
        Task<List<Producto>> GetActiveProductosAsync();
        Task<List<Producto>> SearchProduct(string nombre);
    }
}

using Model.Request;
using Model.Response;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace IBusiness
{
    public interface IProductoBusiness
    {
        Task<List<ProductoResponse>> GetAllProductosAsync();
        Task<ProductoResponse?> GetProductoByIdAsync(int id);
        Task<ProductoResponse> CreateProductoAsync(ProductoRequest request);
        Task<bool> UpdateProductoAsync(int id, ProductoRequest request);
        Task<bool> DeleteProductoAsync(int id);
    }
}

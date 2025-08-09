using DbModel.ElRancho;
using IBusiness;
using IRepository;
using Model.Request;
using Model.Response;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Business
{
    public class ProductoBusiness : IProductoBusiness
    {
        private readonly IProductoRepository _productoRepository;

        public ProductoBusiness(IProductoRepository productoRepository)
        {
            _productoRepository = productoRepository;
        }

        public async Task<List<ProductoResponse>> GetAllProductosAsync()
        {
            var productos = await _productoRepository.GetAllAsync();
            return productos.ConvertAll(p => new ProductoResponse
            {
                Id = p.Id,
                Nombre = p.Nombre,
                Descripcion = p.Descripcion,
                Precio = p.Precio,
                Precio_Oferta = p.Precio_Oferta,
                Activo = p.Activo,
                IdCategoria = p.IdCategoria
            });
        }

        public async Task<ProductoResponse?> GetProductoByIdAsync(int id)
        {
            var producto = await _productoRepository.GetByIdAsync(id);
            if (producto == null) return null;

            return new ProductoResponse
            {
                Id = producto.Id,
                Nombre = producto.Nombre,
                Descripcion = producto.Descripcion,
                Precio = producto.Precio,
                Precio_Oferta = producto.Precio_Oferta,
                Activo = producto.Activo,
                IdCategoria = producto.IdCategoria
            };
        }

        public async Task<ProductoResponse> CreateProductoAsync(ProductoRequest request)
        {
            var producto = new Producto
            {
                Nombre = request.Nombre,
                Descripcion = request.Descripcion,
                Precio = request.Precio,
                Precio_Oferta = request.Precio_Oferta,
                Activo = request.Activo,
                IdCategoria = request.IdCategoria,
            };

            await _productoRepository.AddAsync(producto);
            await _productoRepository.SaveChangesAsync();

            return new ProductoResponse
            {
                Id = producto.Id,
                Nombre = producto.Nombre,
                Descripcion = producto.Descripcion,
                Precio = producto.Precio,
                Precio_Oferta = producto.Precio_Oferta,
                Activo = producto.Activo,
                IdCategoria = producto.IdCategoria
            };
        }

        public async Task<bool> UpdateProductoAsync(int id, ProductoRequest request)
        {
            var producto = await _productoRepository.GetByIdAsync(id);
            if (producto == null) return false;

            producto.Nombre = request.Nombre;
            producto.Descripcion = request.Descripcion;
            producto.Precio = request.Precio;
            producto.Precio_Oferta = request.Precio_Oferta;
            producto.Activo = request.Activo;
            producto.IdCategoria = request.IdCategoria;

            await _productoRepository.UpdateAsync(producto);
            await _productoRepository.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteProductoAsync(int id)
        {
            var producto = await _productoRepository.GetByIdAsync(id);
            if (producto == null) return false;

            await _productoRepository.DeleteAsync(producto);
            await _productoRepository.SaveChangesAsync();
            return true;
        }

        public async Task<List<ProductoResponse>> SearchProductoAsync(string nombre)
        {
            var productos = await _productoRepository.SearchProduct(nombre);
    
            return productos.ConvertAll(p => new ProductoResponse
            {
                Id = p.Id,
                Nombre = p.Nombre,
                Descripcion = p.Descripcion,
                Precio = p.Precio,
                Precio_Oferta = p.Precio_Oferta,
                Activo = p.Activo,
                IdCategoria = p.IdCategoria
            });
        }
    }
}

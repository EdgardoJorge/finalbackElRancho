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
                Activo = p.Activo,
                Imagen = p.Imagen,
                Imagen2 = p.Imagen2,
                Imagen3 = p.Imagen3
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
                Activo = producto.Activo,
                Imagen = producto.Imagen,
                Imagen2 = producto.Imagen2,
                Imagen3 = producto.Imagen3
            };
        }

        public async Task<ProductoResponse> CreateProductoAsync(ProductoRequest request)
        {
            var producto = new Producto
            {
                Nombre = request.Nombre,
                Descripcion = request.Descripcion,
                Precio = request.Precio,
                Activo = request.Activo,
                Imagen = request.Imagen,
                Imagen2 = request.Imagen2,
                Imagen3 = request.Imagen3
            };

            await _productoRepository.AddAsync(producto);
            await _productoRepository.SaveChangesAsync();

            return new ProductoResponse
            {
                Id = producto.Id,
                Nombre = producto.Nombre,
                Descripcion = producto.Descripcion,
                Precio = producto.Precio,
                Activo = producto.Activo,
                Imagen = producto.Imagen,
                Imagen2 = producto.Imagen2,
                Imagen3 = producto.Imagen3
            };
        }

        public async Task<bool> UpdateProductoAsync(int id, ProductoRequest request)
        {
            var producto = await _productoRepository.GetByIdAsync(id);
            if (producto == null) return false;

            producto.Nombre = request.Nombre;
            producto.Descripcion = request.Descripcion;
            producto.Precio = request.Precio;
            producto.Activo = request.Activo;
            producto.Imagen = request.Imagen;
            producto.Imagen2 = request.Imagen2;
            producto.Imagen3 = request.Imagen3;

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
    }
}

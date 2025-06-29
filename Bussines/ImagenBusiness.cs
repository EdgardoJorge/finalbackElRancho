using DbModel.ElRancho;
using IBussines;
using Microsoft.EntityFrameworkCore;
using Model.Request;
using Model.Response;

namespace Bussines
{
    public class ImagenBusiness : IImagenBusiness
    {
        private readonly ElRanchoDbContext _DbContext;

        public ImagenBusiness(ElRanchoDbContext dbContext)
        {
            _DbContext = dbContext;
        }

        public async Task<List<ImagenResponse>> GetAll()
        {
            var imagenes = await _DbContext.Imagenes.ToListAsync();
            return imagenes.Select(imagen => new ImagenResponse
            {
                id = imagen.Id,
                imagenes = imagen.Imagenes,
            }).ToList();
        }

        public async Task<List<ImagenResponse>> GetById(int id)
        {
            var imagenes = await _DbContext.Imagenes.Where(i => i.Id == id).ToListAsync();
            return imagenes.Select(imagen => new ImagenResponse
            {
                id = imagen.Id,
                imagenes = imagen.Imagenes,
            }).ToList();
        }

        public async Task<ImagenResponse> Create(ImagenRequest request)
        {
            var imagen = new DbModel.ElRancho.Imagen
            {
                Imagenes = request.imagenes,
                ProductoId = request.ProductoId
            };

            _DbContext.Imagenes.Add(imagen);
            await _DbContext.SaveChangesAsync();

            return new ImagenResponse
            {
                id = imagen.Id,
                imagenes = imagen.Imagenes
            };
        }

        public async Task<ImagenResponse> Update(int id, ImagenRequest request)
        {
            var imagen = await _DbContext.Imagenes.FindAsync(id);
            if (imagen == null) return null;

            imagen.Imagenes = request.imagenes;
            imagen.ProductoId = request.ProductoId;

            await _DbContext.SaveChangesAsync();

            return new ImagenResponse
            {
                id = imagen.Id,
                imagenes = imagen.Imagenes
            };
        }

        public async Task<ImagenResponse> GetByProduct(int id, ProductoRequest request)
        {
            var imagen = await _DbContext.Imagenes.FirstOrDefaultAsync(i => i.ProductoId == id);
            if (imagen == null) return null;

            return new ImagenResponse
            {
                id = imagen.Id,
                imagenes = imagen.Imagenes
            };
        }
    }
}

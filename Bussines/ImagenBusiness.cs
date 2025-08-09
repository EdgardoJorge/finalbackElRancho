using DbModel.ElRancho;
using IBussines;
using IRepository;
using Microsoft.EntityFrameworkCore;
using Model.Request;
using Model.Response;
using Repository;

namespace Bussines
{
    public class ImagenBusiness : IImagenBusiness
    {
        private readonly IImagenRepository _imagenRepository;

        public ImagenBusiness(IImagenRepository imagenRepository)
        {
            _imagenRepository = imagenRepository;
        }

        public async Task<List<ImagenResponse>> GetAll()
        {
            var imagenes = await _imagenRepository.GetAllAsync();
            return imagenes.Select(imagen => new ImagenResponse
            {
                Imagenes = imagen.Imagenes,
                IdProducto = imagen.IdProducto,
            }).ToList();
        }

        public async Task<ImagenResponse> GetById(int id)
        {
            var imagen = await _imagenRepository.GetByIdAsync(id);
            if (imagen == null) return null;

            return new ImagenResponse
            {
                Imagenes = imagen.Imagenes,
                IdProducto = imagen.IdProducto
            };
        }

        public async Task<ImagenResponse> Create(ImagenRequest request)
        {
            var imagen = new DbModel.ElRancho.Imagen
            {
                Imagenes = request.Imagenes,
                IdProducto = request.IdProducto
            };

            _imagenRepository.AddAsync(imagen);
            await _imagenRepository.SaveChangesAsync();

            return new ImagenResponse
            {
                Imagenes = imagen.Imagenes,
                IdProducto = imagen.IdProducto
            };
        }

        public async Task<ImagenResponse> Update(int id, ImagenRequest request)
        {
            var imagen = await _imagenRepository.GetByIdAsync(id);
            if (imagen == null)
            {
                return null;
            }

            UpdateEntity(imagen, request);
            await _imagenRepository.UpdateAsync(imagen);
            await _imagenRepository.SaveChangesAsync();
            return MapToResponse(imagen);
        }
        private void UpdateEntity(Imagen imagen, ImagenRequest request)
        {
            imagen.Imagenes = request.Imagenes;
            imagen.IdProducto = request.IdProducto;
        }
        private ImagenResponse MapToResponse(Imagen imagen)
        {
            return new ImagenResponse
            {
                Imagenes = imagen.Imagenes,
                IdProducto = imagen.IdProducto
            };
        }
        public async Task<int> Delete(int id)
        {
            var imagen = await _imagenRepository.GetByIdAsync(id);
            if (imagen == null)
            {
                return 0;
            }

            await _imagenRepository.DeleteAsync(imagen);
            await _imagenRepository.SaveChangesAsync();
            return 1;
        }
        
    }
}

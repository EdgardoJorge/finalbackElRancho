using System.Collections.Generic;
using System.Threading.Tasks;
using Model.Request;
using Model.Response;
using DbModel.ElRancho;
using IBusiness;
using IRepository;

namespace Business
{
    public class BannerBusiness : IBannerBusiness
    {
        private readonly IBannerRepository _bannerRepository;

        public BannerBusiness(IBannerRepository bannerRepository)
        {
            _bannerRepository = bannerRepository;
        }

        public async Task<List<BannerResponse>> GetAllBannersAsync()
        {
            var banners = await _bannerRepository.GetAllAsync();
            return banners.ConvertAll(b => new BannerResponse
            {
                Id = b.Id,
                Titulo = b.Titulo,
                Descripcion = b.Descripcion,
                UrlImagen = b.UrlImagen,
                Redireccion = b.Redireccion,
                TerminosYCondiciones = b.TerminosYCondiciones,
                FechaInicio = b.FechaInicio,
                FechaFin = b.FechaFin,
                Activo = b.Activo,
                ProductoId = b.ProductoId,
            });
        }

        public async Task<BannerResponse?> GetBannerByIdAsync(int id)
        {
            var banner = await _bannerRepository.GetByIdAsync(id);
            if (banner == null) return null;

            return new BannerResponse
            {
                Id = banner.Id,
                Titulo = banner.Titulo,
                Descripcion = banner.Descripcion,
                UrlImagen = banner.UrlImagen,
                Redireccion = banner.Redireccion,
                TerminosYCondiciones = banner.TerminosYCondiciones,
                FechaInicio = banner.FechaInicio,
                FechaFin = banner.FechaFin,
                Activo = banner.Activo,
                ProductoId = banner.ProductoId,
            };
        }

        public async Task<BannerResponse> CreateBannerAsync(BannerRequest request)
        {
            if (string.IsNullOrWhiteSpace(request.Titulo) || string.IsNullOrWhiteSpace(request.UrlImagen))
                throw new System.Exception("Título y URL de imagen son obligatorios.");

            var banner = new Banner
            {
                Titulo = request.Titulo,
                Descripcion = request.Descripcion,
                UrlImagen = request.UrlImagen,
                Redireccion = request.Redireccion,
                TerminosYCondiciones = request.TerminosYCondiciones,
                FechaInicio = request.FechaInicio,
                FechaFin = request.FechaFin,
                Activo = request.Activo,
                ProductoId = request.ProductoId,
            };

            await _bannerRepository.AddAsync(banner);
            await _bannerRepository.SaveChangesAsync();

            return new BannerResponse
            {
                Id = banner.Id,
                Titulo = banner.Titulo,
                Descripcion = banner.Descripcion,
                UrlImagen = banner.UrlImagen,
                Redireccion = banner.Redireccion,
                TerminosYCondiciones = banner.TerminosYCondiciones,
                FechaInicio = banner.FechaInicio,
                FechaFin = banner.FechaFin,
                Activo = banner.Activo,
                ProductoId = banner.ProductoId,
            };
        }

        public async Task<bool> UpdateBannerAsync(int id, BannerRequest request)
        {
            var existingBanner = await _bannerRepository.GetByIdAsync(id);
            if (existingBanner == null) return false;

            existingBanner.Titulo = request.Titulo;
            existingBanner.Descripcion = request.Descripcion;
            existingBanner.UrlImagen = request.UrlImagen;
            existingBanner.Redireccion = request.Redireccion;
            existingBanner.TerminosYCondiciones = request.TerminosYCondiciones;
            existingBanner.FechaInicio = request.FechaInicio;
            existingBanner.FechaFin = request.FechaFin;
            existingBanner.Activo = request.Activo;
            existingBanner.ProductoId = request.ProductoId;

            await _bannerRepository.UpdateAsync(existingBanner);
            await _bannerRepository.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteBannerAsync(int id)
        {
            var banner = await _bannerRepository.GetByIdAsync(id);
            if (banner == null) return false;

            await _bannerRepository.DeleteAsync(banner);
            await _bannerRepository.SaveChangesAsync();
            return true;
        }
    }
}

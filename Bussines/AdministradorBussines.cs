using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Model.Request;
using Model.Response;
using IBusiness;
using Microsoft.EntityFrameworkCore;
using DbModel.ElRancho;

namespace Business
{
    public class AdministradorBusiness : IAdministradorBusiness
    {
        private readonly ElRanchoDbContext _dbContext;

        public AdministradorBusiness(ElRanchoDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        // Implementación de GetAll
        public async Task<List<AdministradorResponse>> GetAll()
        {
            var administradores = await _dbContext.Administradores.ToListAsync();
            return administradores.Select(admin => new AdministradorResponse
            {
                Id = admin.Id,
                Nombres = admin.Nombres,
                ApellidoPaterno = admin.ApellidoPaterno,
                ApellidoMaterno = admin.ApellidoMaterno,
                Dni = admin.Dni,
                TelefonoMovil = admin.TelefonoMovil,
                CorreoElectronico = admin.CorreoElectronico,
                Cargo = admin.Cargo
            }).ToList();
        }

        // Implementación de GetById
        public async Task<AdministradorResponse> GetById(object id)
        {
            var administrador = await _dbContext.Administradores.FindAsync(id);
            if (administrador == null)
            {
                throw new ArgumentException("Administrador no encontrado.");
            }

            return new AdministradorResponse
            {
                Id = administrador.Id,
                Nombres = administrador.Nombres,
                ApellidoPaterno = administrador.ApellidoPaterno,
                ApellidoMaterno = administrador.ApellidoMaterno,
                Dni = administrador.Dni,
                TelefonoMovil = administrador.TelefonoMovil,
                CorreoElectronico = administrador.CorreoElectronico,
                Cargo = administrador.Cargo
            };
        }

        // Implementación de Create
        public async Task<AdministradorResponse> Create(AdministradorRequest request)
        {
            var administrador = new Administrador
            {
                Nombres = request.Nombres,
                ApellidoPaterno = request.ApellidoPaterno,
                ApellidoMaterno = request.ApellidoMaterno,
                Dni = request.Dni,
                TelefonoMovil = request.TelefonoMovil,
                CorreoElectronico = request.CorreoElectronico,
                Cargo = request.Cargo
            };

            _dbContext.Administradores.Add(administrador);
            await _dbContext.SaveChangesAsync();

            return new AdministradorResponse
            {
                Id = administrador.Id,
                Nombres = administrador.Nombres,
                ApellidoPaterno = administrador.ApellidoPaterno,
                ApellidoMaterno = administrador.ApellidoMaterno,
                Dni = administrador.Dni,
                TelefonoMovil = administrador.TelefonoMovil,
                CorreoElectronico = administrador.CorreoElectronico,
                Cargo = administrador.Cargo
            };
        }

        // Implementación de Update
        public async Task<AdministradorResponse> Update(AdministradorRequest request)
        {
            var administrador = await _dbContext.Administradores.FindAsync(request.Id);
            if (administrador == null)
            {
                throw new ArgumentException("Administrador no encontrado.");
            }

            administrador.Nombres = request.Nombres;
            administrador.ApellidoPaterno = request.ApellidoPaterno;
            administrador.ApellidoMaterno = request.ApellidoMaterno;
            administrador.TelefonoMovil = request.TelefonoMovil;
            administrador.CorreoElectronico = request.CorreoElectronico;
            administrador.Cargo = request.Cargo;

            await _dbContext.SaveChangesAsync();

            return new AdministradorResponse
            {
                Id = administrador.Id,
                Nombres = administrador.Nombres,
                ApellidoPaterno = administrador.ApellidoPaterno,
                ApellidoMaterno = administrador.ApellidoMaterno,
                TelefonoMovil = administrador.TelefonoMovil,
                CorreoElectronico = administrador.CorreoElectronico,
                Cargo = administrador.Cargo
            };
        }

        // Implementación de DeleteById
        public async Task<int> DeleteById(object id)
        {
            var administrador = await _dbContext.Administradores.FindAsync(id);
            if (administrador == null)
            {
                throw new ArgumentException("Administrador no encontrado.");
            }

            _dbContext.Administradores.Remove(administrador);
            return await _dbContext.SaveChangesAsync();
        }

        // Implementación de DeleteMultiple
        public async Task<int> DeleteMultiple(List<AdministradorRequest> requests)
        {
            var ids = requests.Select(r => r.Id).ToList();
            var administradores = await _dbContext.Administradores.Where(a => ids.Contains(a.Id)).ToListAsync();
            if (administradores.Count == 0)
            {
                throw new ArgumentException("No se encontraron administradores para eliminar.");
            }

            _dbContext.Administradores.RemoveRange(administradores);
            return await _dbContext.SaveChangesAsync();
        }

        // Implementación de CreateMultiple
        public async Task<List<AdministradorResponse>> CreateMultiple(List<AdministradorRequest> requests)
        {
            var administradores = requests.Select(request => new Administrador
            {
                Nombres = request.Nombres,
                ApellidoPaterno = request.ApellidoPaterno,
                ApellidoMaterno = request.ApellidoMaterno,
                Dni = request.Dni,
                TelefonoMovil = request.TelefonoMovil,
                CorreoElectronico = request.CorreoElectronico,
                Cargo = request.Cargo
            }).ToList();

            _dbContext.Administradores.AddRange(administradores);
            await _dbContext.SaveChangesAsync();

            return administradores.Select(admin => new AdministradorResponse
            {
                Id = admin.Id,
                Nombres = admin.Nombres,
                ApellidoPaterno = admin.ApellidoPaterno,
                ApellidoMaterno = admin.ApellidoMaterno,
                Dni = admin.Dni,
                TelefonoMovil = admin.TelefonoMovil,
                CorreoElectronico = admin.CorreoElectronico,
                Cargo = admin.Cargo
            }).ToList();
        }

        // Implementación de UpdateMultiple
        public async Task<List<AdministradorResponse>> UpdateMultiple(List<AdministradorRequest> requests)
        {
            var administradores = requests.Select(request =>
            {
                var administrador = _dbContext.Administradores.Find(request.Id);
                if (administrador != null)
                {
                    administrador.Nombres = request.Nombres;
                    administrador.ApellidoPaterno = request.ApellidoPaterno;
                    administrador.ApellidoMaterno = request.ApellidoMaterno;
                    administrador.TelefonoMovil = request.TelefonoMovil;
                    administrador.CorreoElectronico = request.CorreoElectronico;
                    administrador.Cargo = request.Cargo;
                }
                return administrador;
            }).Where(a => a != null).ToList();

            await _dbContext.SaveChangesAsync();

            return administradores.Select(admin => new AdministradorResponse
            {
                Id = admin.Id,
                Nombres = admin.Nombres,
                ApellidoPaterno = admin.ApellidoPaterno,
                ApellidoMaterno = admin.ApellidoMaterno,
                Dni = admin.Dni,
                TelefonoMovil = admin.TelefonoMovil,
                CorreoElectronico = admin.CorreoElectronico,
                Cargo = admin.Cargo
            }).ToList();
        }

        // Implementación de GetByName
        public async Task<AdministradorResponse?> GetByName(string name)
        {
            var administrador = await _dbContext.Administradores
                .FirstOrDefaultAsync(a => a.Nombres.Contains(name) || a.ApellidoPaterno.Contains(name) || a.ApellidoMaterno.Contains(name));

            if (administrador == null)
            {
                return null;
            }

            return new AdministradorResponse
            {
                Id = administrador.Id,
                Nombres = administrador.Nombres,
                ApellidoPaterno = administrador.ApellidoPaterno,
                ApellidoMaterno = administrador.ApellidoMaterno,
                Dni = administrador.Dni,
                TelefonoMovil = administrador.TelefonoMovil,
                CorreoElectronico = administrador.CorreoElectronico,
                Cargo = administrador.Cargo
            };
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Model.Request;
using Model.Response;
using IBusiness;
using Microsoft.EntityFrameworkCore;
using DbModel.ElRancho;
using BCrypt.Net; // 🔐 Para encriptar Passwords

namespace Business
{
    public class AdministradorBusiness : IAdministradorBusiness
    {
        private readonly ElRanchoDbContext _dbContext;

        public AdministradorBusiness(ElRanchoDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<AdministradorResponse>> GetAll()
        {
            var administradores = await _dbContext.Administradores.ToListAsync();
            return administradores.Select(admin => new AdministradorResponse
            {
                Id = admin.Id,
                Nombres = admin.Nombres,
                ApellidoPaterno = admin.ApellidoPaterno,
                ApellidoMaterno = admin.ApellidoMaterno,
                Dni = admin.DNI,
                TelefonoMovil = admin.TelefonoMovil,
                CorreoElectronico = admin.CorreoElectronico,
      
                IdRol = admin.IdRol,
            }).ToList();
        }

        public async Task<AdministradorResponse?> GetById(int id)
        {
            var administrador = await _dbContext.Administradores.FindAsync(id);
            if (administrador == null) return null;

            return new AdministradorResponse
            {
                Id = administrador.Id,
                Nombres = administrador.Nombres,
                ApellidoPaterno = administrador.ApellidoPaterno,
                ApellidoMaterno = administrador.ApellidoMaterno,
                Dni = administrador.DNI, // ✅ Dni en mayúsculas
                TelefonoMovil = administrador.TelefonoMovil,
                CorreoElectronico = administrador.CorreoElectronico,
                IdRol = administrador.IdRol,
          };
        }

        public async Task<AdministradorResponse?> GetByName(string name)
        {
            var administrador = await _dbContext.Administradores.FirstOrDefaultAsync(a => a.Nombres == name);
            if (administrador == null) return null;

            return new AdministradorResponse
            {
                Id = administrador.Id,
                Nombres = administrador.Nombres,
                ApellidoPaterno = administrador.ApellidoPaterno,
                ApellidoMaterno = administrador.ApellidoMaterno,
                Dni = administrador.DNI, // ✅ Manteniendo en mayúsculas
                TelefonoMovil = administrador.TelefonoMovil,
                IdRol = administrador.IdRol,
                CorreoElectronico = administrador.CorreoElectronico,
       };
        }

        public async Task<AdministradorResponse> Create(AdministradorRequest request)
        {
            var administrador = new Administrador
            {
                Nombres = request.Nombres,
                ApellidoPaterno = request.ApellidoPaterno,
                ApellidoMaterno = request.ApellidoMaterno,
                DNI = request.Dni, // ✅ Se mantiene Dni en mayúsculas
                TelefonoMovil = request.TelefonoMovil,
                CorreoElectronico = request.CorreoElectronico,
                IdRol = request.IdRol,
      
                Password = BCrypt.Net.BCrypt.HashPassword(request.Password) // 🔐 Encriptar la Password
            };

            _dbContext.Administradores.Add(administrador);
            await _dbContext.SaveChangesAsync();

            return new AdministradorResponse
            {
                Id = administrador.Id,
                Nombres = administrador.Nombres,
                ApellidoPaterno = administrador.ApellidoPaterno,
                ApellidoMaterno = administrador.ApellidoMaterno,
                Dni = administrador.DNI, // ✅ Dni en mayúsculas
                TelefonoMovil = administrador.TelefonoMovil,
                IdRol = administrador.IdRol,
                CorreoElectronico = administrador.CorreoElectronico,
               };
        }

        public async Task<AdministradorResponse> Update(int id, AdministradorRequest request)
        {
            var administrador = await _dbContext.Administradores.FindAsync(id);
            if (administrador == null) throw new ArgumentException("Administrador no encontrado.");

            administrador.Nombres = request.Nombres;
            administrador.ApellidoPaterno = request.ApellidoPaterno;
            administrador.ApellidoMaterno = request.ApellidoMaterno;
            administrador.DNI = request.Dni; // ✅ Dni en mayúsculas
            administrador.TelefonoMovil = request.TelefonoMovil;
            administrador.CorreoElectronico = request.CorreoElectronico;
            administrador.IdRol = request.IdRol;

            if (!string.IsNullOrWhiteSpace(request.Password))
            {
                administrador.Password = BCrypt.Net.BCrypt.HashPassword(request.Password); // 🔐 Encriptar nueva Password si se envía
            }

            await _dbContext.SaveChangesAsync();

            return new AdministradorResponse
            {
                Id = administrador.Id,
                Nombres = administrador.Nombres,
                ApellidoPaterno = administrador.ApellidoPaterno,
                ApellidoMaterno = administrador.ApellidoMaterno,
                Dni = administrador.DNI, // ✅ Se mantiene en mayúsculas
                TelefonoMovil = administrador.TelefonoMovil,
                CorreoElectronico = administrador.CorreoElectronico,
                IdRol = administrador.IdRol,
                 };
        }

        public async Task<int> DeleteById(int id)
        {
            var administrador = await _dbContext.Administradores.FindAsync(id);
            if (administrador == null) return 0;

            _dbContext.Administradores.Remove(administrador);
            return await _dbContext.SaveChangesAsync();
        }

        public async Task<int> DeleteMultiple(List<int> ids)
        {
            var administradores = await _dbContext.Administradores.Where(a => ids.Contains(a.Id)).ToListAsync();
            if (!administradores.Any()) return 0;

            _dbContext.Administradores.RemoveRange(administradores);
            return await _dbContext.SaveChangesAsync();
        }

        public async Task<List<AdministradorResponse>> CreateMultiple(List<AdministradorRequest> requests)
        {
            var administradores = requests.Select(request => new Administrador
            {
                Nombres = request.Nombres,
                ApellidoPaterno = request.ApellidoPaterno,
                ApellidoMaterno = request.ApellidoMaterno,
                DNI = request.Dni, // ✅ Se mantiene en mayúsculas
                TelefonoMovil = request.TelefonoMovil,
                CorreoElectronico = request.CorreoElectronico,
      
                IdRol = request.IdRol,
                Password = BCrypt.Net.BCrypt.HashPassword(request.Password) // 🔐 Encriptar cada Password
            }).ToList();

            _dbContext.Administradores.AddRange(administradores);
            await _dbContext.SaveChangesAsync();

            return administradores.Select(admin => new AdministradorResponse
            {
                Id = admin.Id,
                Nombres = admin.Nombres,
                ApellidoPaterno = admin.ApellidoPaterno,
                ApellidoMaterno = admin.ApellidoMaterno,
                Dni = admin.DNI, // ✅ Dni en mayúsculas
                TelefonoMovil = admin.TelefonoMovil,
                CorreoElectronico = admin.CorreoElectronico,
                IdRol = admin.IdRol,
                  }).ToList();
        }

        public async Task<List<AdministradorResponse>> UpdateMultiple(Dictionary<int, AdministradorRequest> updates)
        {
            var responses = new List<AdministradorResponse>();

            foreach (var entry in updates)
            {
                var updatedAdmin = await Update(entry.Key, entry.Value);
                responses.Add(updatedAdmin);
            }
            return responses;
        }
    }
}

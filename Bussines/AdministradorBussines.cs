using System;
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

        public async Task<AdministradorResponse?> GetByName(string name)
        {
            var administrador = await _dbContext.Administradores.FirstOrDefaultAsync(a => a.Nombres == name);
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

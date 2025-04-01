using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using BCrypt.Net;
using DbModel.ElRancho;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.Linq;

namespace Business
{
    public class AuthAdminService
    {
        private readonly ElRanchoDbContext _dbContext;
        private readonly IConfiguration _config;

        public AuthAdminService(ElRanchoDbContext dbContext, IConfiguration config)
        {
            _dbContext = dbContext;
            _config = config;
        }

        // 🟢 Método para autenticar administrador y generar un token
        public string? AuthenticateAdmin(string correo, string contraseña)
        {
            var admin = _dbContext.Administradores.FirstOrDefault(a => a.CorreoElectronico == correo);
            if (admin == null || !BCrypt.Net.BCrypt.Verify(contraseña, admin.Contraseña))
            {
                return null; // Usuario o contraseña incorrectos
            }

            return GenerateJwtToken(admin);
        }

        // 🔐 Generar Token JWT
        private string GenerateJwtToken(Administrador admin)
        {
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Sub, admin.Id.ToString()),
                new Claim(JwtRegisteredClaimNames.Email, admin.CorreoElectronico),
                new Claim("nombre", admin.Nombres),
                new Claim("rol", "Administrador")
            };

            var token = new JwtSecurityToken(
                _config["Jwt:Issuer"],
                _config["Jwt:Audience"],
                claims,
                expires: DateTime.UtcNow.AddHours(2),
                signingCredentials: creds
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}

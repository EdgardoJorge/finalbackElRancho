using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using BCrypt.Net;
using DbModel.ElRancho;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace Business
{
    public class AuthService
    {
        private readonly ElRanchoDbContext _dbContext;
        private readonly IConfiguration _config;

        public AuthService(ElRanchoDbContext dbContext, IConfiguration config)
        {
            _dbContext = dbContext;
            _config = config;
        }

        // 🟢 Método para autenticar y generar un token
        public string? Authenticate(string correo, string contraseña)
        {
            var cliente = _dbContext.Clientes.FirstOrDefault(c => c.CorreoElectronico == correo);
            if (cliente == null || !BCrypt.Net.BCrypt.Verify(contraseña, cliente.ContraseñaHash))
            {
                return null; // Usuario o contraseña incorrectos
            }

            return GenerateJwtToken(cliente);
        }

        // 🔐 Generar Token JWT
        private string GenerateJwtToken(Cliente cliente)
        {
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Sub, cliente.Id.ToString()),
                new Claim(JwtRegisteredClaimNames.Email, cliente.CorreoElectronico),
                new Claim("nombre", cliente.Nombres),
                new Claim("rol", "Cliente") // Si agregas roles
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

using System.Threading.Tasks;
using Business;
using Microsoft.AspNetCore.Mvc;
using Model.Request;

namespace API.Controllers
{
    [Route("api/admin/auth")]
    [ApiController]
    public class AdminAuthController : ControllerBase
    {
        private readonly AuthAdminService _authAdminService;

        public AdminAuthController(AuthAdminService authAdminService)
        {
            _authAdminService = authAdminService;
        }

        [HttpPost("login")]
        public IActionResult Login([FromBody] AdministradorLoginRequest request)
        {
            var token = _authAdminService.AuthenticateAdmin(request.CorreoElectronico, request.Contraseña);
            if (token == null)
                return Unauthorized(new { message = "Credenciales inválidas" });

            return Ok(new { token });
        }
    }
}

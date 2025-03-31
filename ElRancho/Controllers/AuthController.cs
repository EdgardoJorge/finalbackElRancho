using Business;
using Microsoft.AspNetCore.Mvc;
using Model.Request;

namespace API.Controllers
{
    [Route("api/auth")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly AuthService _authService;

        public AuthController(AuthService authService)
        {
            _authService = authService;
        }

        // 📌 LOGIN
        [HttpPost("login")]
        public IActionResult Login([FromBody] ClienteLoginRequest request)
        {
            var token = _authService.Authenticate(request.CorreoElectronico, request.Contraseña);
            if (token == null)
            {
                return Unauthorized(new { message = "Correo o contraseña incorrectos" });
            }

            return Ok(new { token });
        }
    }
}

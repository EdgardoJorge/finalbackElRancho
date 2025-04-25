using System.Collections.Generic;
using System.Threading.Tasks;
using IBusiness;
using Microsoft.AspNetCore.Mvc;
using Model.Request;
using Model.Response;

namespace YourNamespace.Controllers
{
    [Route("api/administradores")]
    [ApiController]
    public class AdministradorController : ControllerBase
    {
        private readonly IAdministradorBusiness _administradorBusiness;

        public AdministradorController(IAdministradorBusiness administradorBusiness)
        {
            _administradorBusiness = administradorBusiness;
        }

        /// <summary>
        /// Obtener todos los administradores.
        /// </summary>
        [HttpGet]
        public async Task<ActionResult<List<AdministradorResponse>>> GetAll()
        {
            var administradores = await _administradorBusiness.GetAll();
            return Ok(administradores);
        }

        /// <summary>
        /// Obtener un administrador por su ID.
        /// </summary>
        [HttpGet("{id}")]
        public async Task<ActionResult<AdministradorResponse>> GetById(int id)
        {
            var administrador = await _administradorBusiness.GetById(id);
            if (administrador == null)
                return NotFound(new { message = "Administrador no encontrado" });

            return Ok(administrador);
        }

        /// <summary>
        /// Crear un nuevo administrador.
        /// </summary>
        [HttpPost]
        public async Task<ActionResult<AdministradorResponse>> Create([FromBody] AdministradorRequest request)
        {
            if (string.IsNullOrWhiteSpace(request.Password))
                return BadRequest(new { message = "La Password es obligatoria" });

            var administrador = await _administradorBusiness.Create(request);
            return CreatedAtAction(nameof(GetById), new { id = administrador.Id }, administrador);
        }

        /// <summary>
        /// Actualizar un administrador existente.
        /// </summary>
        [HttpPut("{id}")]
        public async Task<ActionResult<AdministradorResponse>> Update(int id, [FromBody] AdministradorRequest request)
        {
            var updatedAdministrador = await _administradorBusiness.Update(id, request);
            if (updatedAdministrador == null)
                return NotFound(new { message = "Administrador no encontrado" });

            return Ok(updatedAdministrador);
        }

        /// <summary>
        /// Eliminar un administrador por su ID.
        /// </summary>
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteById(int id)
        {
            var deleted = await _administradorBusiness.DeleteById(id);
            if (deleted == 0)
                return NotFound(new { message = "Administrador no encontrado" });

            return NoContent();
        }
    }
}

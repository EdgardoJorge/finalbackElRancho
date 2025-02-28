using System.Collections.Generic;
using System.Threading.Tasks;
using Bussnies;
using IBussnies;
using Microsoft.AspNetCore.Mvc;
using Model.Request;
using Model.Response;

namespace YourNamespace.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdministradorController : ControllerBase
    {
        private readonly IAdministradorBussnies _AdministradorBussnies; // Cambia a IAdministradorBussnies

        public AdministradorController(IAdministradorBussnies AdministradorBussnies)
        {
            _AdministradorBussnies = AdministradorBussnies;
        }

        [HttpGet]
        public async Task<ActionResult<List<AdministradorResponse>>> GetAll()
        {
            var Administradors = await _AdministradorBussnies.GetAll();
            return Ok(Administradors);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<AdministradorResponse>> GetById(int id)
        {
            var Administrador = await _AdministradorBussnies.GetById(id);
            if (Administrador == null)
            {
                return NotFound();
            }
            return Ok(Administrador);
        }

        [HttpGet("name/{AdministradorName}")]
        public async Task<ActionResult<AdministradorResponse?>> GetByName(string AdministradorName)
        {
            var Administrador = await _AdministradorBussnies.GetByName(AdministradorName);
            if (Administrador == null)
            {
                return NotFound();
            }
            return Ok(Administrador);
        }

        [HttpPost]
        public async Task<ActionResult<AdministradorResponse>> Create(AdministradorRequest request)
        {
            var Administrador = await _AdministradorBussnies.Create(request);
            return CreatedAtAction(nameof(GetById), new { id = Administrador.Id }, Administrador);
        }

        [HttpPost("multiple")]
        public async Task<ActionResult<List<AdministradorResponse>>> CreateMultiple(List<AdministradorRequest> request)
        {
            var Administradors = await _AdministradorBussnies.CreateMultiple(request);
            return CreatedAtAction(nameof(GetAll), Administradors);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<AdministradorResponse>> Update(int id, AdministradorRequest request)
        {
            if (id != request.Id)
            {
                return BadRequest();
            }

            var updatedAdministrador = await _AdministradorBussnies.Update(request);
            if (updatedAdministrador == null)
            {
                return NotFound();
            }

            return Ok(updatedAdministrador);
        }

        [HttpPut("multiple")]
        public async Task<ActionResult<List<AdministradorResponse>>> UpdateMultiple(List<AdministradorRequest> request)
        {
            var updatedAdministradors = await _AdministradorBussnies.UpdateMultiple(request);
            return Ok(updatedAdministradors);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteById(int id)
        {
            var result = await _AdministradorBussnies.DeleteById(id);
            if (result == 0)
            {
                return NotFound();
            }

            return NoContent();
        }

        [HttpDelete("multiple")]
        public async Task<ActionResult> DeleteMultiple(List<AdministradorRequest> request)
        {
            var result = await _AdministradorBussnies.DeleteMultiple(request);
            if (result == 0)
            {
                return NotFound();
            }

            return NoContent();
        }
    }
}
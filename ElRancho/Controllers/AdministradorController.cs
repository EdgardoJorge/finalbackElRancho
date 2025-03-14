using System.Collections.Generic;
using System.Threading.Tasks;
using Business;
using IBusiness;
using Microsoft.AspNetCore.Mvc;
using Model.Request;
using Model.Response;

namespace YourNamespace.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdministradorController : ControllerBase
    {
        private readonly IAdministradorBusiness _administradorBusiness; // Nombre correcto

        public AdministradorController(IAdministradorBusiness administradorBusiness)
        {
            _administradorBusiness = administradorBusiness;
        }

        [HttpGet]
        public async Task<ActionResult<List<AdministradorResponse>>> GetAll()
        {
            var administradores = await _administradorBusiness.GetAll();
            return Ok(administradores);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<AdministradorResponse>> GetById(int id)
        {
            var administrador = await _administradorBusiness.GetById(id);
            if (administrador == null) return NotFound();
            return Ok(administrador);
        }

        [HttpGet("name/{name}")]
        public async Task<ActionResult<AdministradorResponse?>> GetByName(string name)
        {
            var administrador = await _administradorBusiness.GetByName(name);
            if (administrador == null) return NotFound();
            return Ok(administrador);
        }

        [HttpPost]
        public async Task<ActionResult<AdministradorResponse>> Create(AdministradorRequest request)
        {
            var administrador = await _administradorBusiness.Create(request);
            return CreatedAtAction(nameof(GetById), new { id = administrador.Id }, administrador);
        }

        [HttpPost("multiple")]
        public async Task<ActionResult<List<AdministradorResponse>>> CreateMultiple(List<AdministradorRequest> request)
        {
            var administradores = await _administradorBusiness.CreateMultiple(request);
            return CreatedAtAction(nameof(GetAll), administradores);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<AdministradorResponse>> Update(int id, AdministradorRequest request)
        {
            if (id != request.Id) return BadRequest();
            var updatedAdministrador = await _administradorBusiness.Update(request);
            if (updatedAdministrador == null) return NotFound();
            return Ok(updatedAdministrador);
        }

        [HttpPut("multiple")]
        public async Task<ActionResult<List<AdministradorResponse>>> UpdateMultiple(List<AdministradorRequest> request)
        {
            var updatedAdministradors = await _administradorBusiness.UpdateMultiple(request);
            return Ok(updatedAdministradors);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteById(int id)
        {
            var result = await _administradorBusiness.DeleteById(id);
            if (result == 0) return NotFound();
            return NoContent();
        }

        [HttpDelete("multiple")]
        public async Task<ActionResult> DeleteMultiple(List<AdministradorRequest> request)
        {
            var result = await _administradorBusiness.DeleteMultiple(request);
            if (result == 0) return NotFound();
            return NoContent();
        }
    }
}
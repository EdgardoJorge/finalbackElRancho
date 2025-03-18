using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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
        private readonly IAdministradorBusiness _administradorBusiness;

        public AdministradorController(IAdministradorBusiness administradorBusiness)
        {
            _administradorBusiness = administradorBusiness;
        }

        [HttpGet]
        public async Task<ActionResult<List<AdministradorResponse>>> GetAll() => Ok(await _administradorBusiness.GetAll());

        [HttpGet("{id}")]
        public async Task<ActionResult<AdministradorResponse?>> GetById(int id) =>
            await _administradorBusiness.GetById(id) is { } administrador ? Ok(administrador) : NotFound();

        [HttpPost]
        public async Task<ActionResult<AdministradorResponse>> Create(AdministradorRequest request)
        {
            var administrador = await _administradorBusiness.Create(request);
            return CreatedAtAction(nameof(GetById), new { id = administrador.Id }, administrador);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<AdministradorResponse>> Update(int id, AdministradorRequest request) =>
            await _administradorBusiness.Update(id, request) is { } updatedAdministrador ? Ok(updatedAdministrador) : NotFound();

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteById(int id) =>
            await _administradorBusiness.DeleteById(id) > 0 ? NoContent() : NotFound();
    }
}

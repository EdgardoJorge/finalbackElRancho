using Model.Request;
using Model.Response;
using IBusiness;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ElRancho.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TipoEntregaController : ControllerBase
    {
        private readonly ITipoEntregaBusiness _tipoEntregaBusiness;

        public TipoEntregaController(ITipoEntregaBusiness tipoEntregaBusiness)
        {
            _tipoEntregaBusiness = tipoEntregaBusiness;
        }

        [HttpGet]
        public async Task<ActionResult<List<TipoEntregaResponse>>> GetAllTipoEntrega()
        {
            return Ok(await _tipoEntregaBusiness.GetAllTipoEntregaAsync());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<TipoEntregaResponse>> GetTipoEntregaById(int id)
        {
            var tipoEntrega = await _tipoEntregaBusiness.GetTipoEntregaByIdAsync(id);
            if (tipoEntrega == null)
                return NotFound("Tipo de entrega no encontrado.");
            return Ok(tipoEntrega);
        }

        [HttpPost]
        public async Task<ActionResult> CreateTipoEntrega([FromBody] TipoEntregaRequest request)
        {
            if (request == null)
                return BadRequest("Datos inválidos.");

            await _tipoEntregaBusiness.AddTipoEntregaAsync(request);
            return Ok("Tipo de entrega creado correctamente.");
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateTipoEntrega(int id, [FromBody] TipoEntregaRequest request)
        {
            if (request == null)
                return BadRequest("Datos inválidos.");

            try
            {
                await _tipoEntregaBusiness.UpdateTipoEntregaAsync(id, request);
                return NoContent();
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteTipoEntrega(int id)
        {
            try
            {
                await _tipoEntregaBusiness.DeleteTipoEntregaAsync(id);
                return NoContent();
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }
    }
}

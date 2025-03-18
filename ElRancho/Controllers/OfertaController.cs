using IBusiness;
using Microsoft.AspNetCore.Mvc;
using Model.Oferta;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ElRancho.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OfertaController : ControllerBase
    {
        private readonly IOfertaBusiness _ofertaBusiness;

        public OfertaController(IOfertaBusiness ofertaBusiness)
        {
            _ofertaBusiness = ofertaBusiness;
        }

        [HttpGet]
        public async Task<ActionResult<List<OfertaResponse>>> GetAllOfertas()
        {
            return Ok(await _ofertaBusiness.GetAllOfertasAsync());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<OfertaResponse>> GetOfertaById(int id)
        {
            var oferta = await _ofertaBusiness.GetOfertaByIdAsync(id);
            if (oferta == null)
                return NotFound("Oferta no encontrada.");
            return Ok(oferta);
        }

        [HttpPost]
        public async Task<ActionResult> CreateOferta([FromBody] OfertaRequest request)
        {
            if (request == null)
                return BadRequest("Datos inválidos.");

            await _ofertaBusiness.AddOfertaAsync(request);
            return Ok("Oferta creada correctamente.");
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateOferta(int id, [FromBody] OfertaRequest request)
        {
            if (request == null)
                return BadRequest("Datos inválidos.");

            try
            {
                await _ofertaBusiness.UpdateOfertaAsync(id, request);
                return NoContent();
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteOferta(int id)
        {
            try
            {
                await _ofertaBusiness.DeleteOfertaAsync(id);
                return NoContent();
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }
    }
}

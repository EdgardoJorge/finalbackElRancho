using IBusiness;
using Microsoft.AspNetCore.Mvc;
using Model.Request;
using Model.Response;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MesaController : ControllerBase
    {
        private readonly IMesaBusiness _mesaBusiness;

        public MesaController(IMesaBusiness mesaBusiness)
        {
            _mesaBusiness = mesaBusiness;
        }

        [HttpGet]
        public async Task<ActionResult<List<MesaResponse>>> GetAll()
        {
            var result = await _mesaBusiness.GetAll();
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<MesaResponse>> GetById(int id)
        {
            var result = await _mesaBusiness.GetById(id);
            if (result == null) return NotFound();
            return Ok(result);
        }

        [HttpPost]
        public async Task<ActionResult<MesaResponse>> Create([FromBody] MesaRequest request)
        {
            var result = await _mesaBusiness.Create(request);
            return CreatedAtAction(nameof(GetById), new { id = result.Id }, result);
        }

        [HttpPost("multiple")]
        public async Task<ActionResult<List<MesaResponse>>> CreateMultiple([FromBody] List<MesaRequest> requests)
        {
            var result = await _mesaBusiness.CreateMultiple(requests);
            return Ok(result);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<MesaResponse>> Update(int id, [FromBody] MesaRequest request)
        {
            var result = await _mesaBusiness.Update(id, request);
            if (result == null) return NotFound();
            return Ok(result);
        }

        [HttpPut("multiple")]
        public async Task<ActionResult<List<MesaResponse>>> UpdateMultiple([FromBody] Dictionary<int, MesaRequest> requests)
        {
            var result = await _mesaBusiness.UpdateMultiple(requests);
            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteById(int id)
        {
            var deletedCount = await _mesaBusiness.DeleteById(id);
            if (deletedCount == 0) return NotFound();
            return NoContent();
        }

        [HttpDelete("multiple")]
        public async Task<ActionResult> DeleteMultiple([FromBody] List<int> ids)
        {
            var deletedCount = await _mesaBusiness.DeleteMultiple(ids);
            if (deletedCount == 0) return NotFound();
            return NoContent();
        }

        [HttpGet("disponibles")]
        public async Task<ActionResult<List<MesaResponse>>> GetMesasDisponibles()
        {
            var result = await _mesaBusiness.GetMesasDisponibles();
            return Ok(result);
        }
    }
}

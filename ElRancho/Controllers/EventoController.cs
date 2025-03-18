using IBusiness;
using Microsoft.AspNetCore.Mvc;
using Model.Request;
using System.Threading.Tasks;

namespace ElRancho.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EventoController : ControllerBase
    {
        private readonly IEventoBusiness _eventoBusiness;

        public EventoController(IEventoBusiness eventoBusiness)
        {
            _eventoBusiness = eventoBusiness;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _eventoBusiness.GetAll());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var evento = await _eventoBusiness.GetById(id);
            if (evento == null) return NotFound();
            return Ok(evento);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] EventoRequest request)
        {
            var evento = await _eventoBusiness.Create(request);
            return CreatedAtAction(nameof(GetById), new { id = evento.Id }, evento);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] EventoRequest request)
        {
            var updated = await _eventoBusiness.Update(id, request);
            if (updated == null) return NotFound();
            return Ok(updated);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var deleted = await _eventoBusiness.DeleteById(id);
            if (!deleted) return NotFound();
            return NoContent();
        }
    }
}

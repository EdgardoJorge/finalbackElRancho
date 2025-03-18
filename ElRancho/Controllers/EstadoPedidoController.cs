using IBusiness;
using Microsoft.AspNetCore.Mvc;
using Model.Request;
using System.Threading.Tasks;

namespace ElRancho.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EstadoPedidoController : ControllerBase
    {
        private readonly IEstadoPedidoBusiness _estadoPedidoBusiness;

        public EstadoPedidoController(IEstadoPedidoBusiness estadoPedidoBusiness)
        {
            _estadoPedidoBusiness = estadoPedidoBusiness;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _estadoPedidoBusiness.GetAll());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var estado = await _estadoPedidoBusiness.GetById(id);
            if (estado == null) return NotFound();
            return Ok(estado);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] EstadoPedidoRequest request)
        {
            var estado = await _estadoPedidoBusiness.Create(request);
            return CreatedAtAction(nameof(GetById), new { id = estado.Id }, estado);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] EstadoPedidoRequest request)
        {
            var updated = await _estadoPedidoBusiness.Update(id, request);
            if (updated == null) return NotFound();
            return Ok(updated);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var deleted = await _estadoPedidoBusiness.DeleteById(id);
            if (!deleted) return NotFound();
            return NoContent();
        }
    }
}

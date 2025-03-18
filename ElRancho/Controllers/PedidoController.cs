using IBusiness;
using Microsoft.AspNetCore.Mvc;
using Model.Request;
using System.Threading.Tasks;

namespace ElRancho.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PedidoController : ControllerBase
    {
        private readonly IPedidoBusiness _pedidoBusiness;

        public PedidoController(IPedidoBusiness pedidoBusiness)
        {
            _pedidoBusiness = pedidoBusiness;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var result = await _pedidoBusiness.GetAll();
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var result = await _pedidoBusiness.GetById(id);
            if (result == null) return NotFound();
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] PedidoRequest request)
        {
            await _pedidoBusiness.Create(request);
            return CreatedAtAction(nameof(GetById), new { id = request }, request);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] PedidoRequest request)
        {
            await _pedidoBusiness.Update(id, request);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _pedidoBusiness.DeleteById(id);
            return NoContent();
        }
    }
}

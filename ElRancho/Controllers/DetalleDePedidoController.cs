using System.Collections.Generic;
using System.Threading.Tasks;
using IBusiness;
using Microsoft.AspNetCore.Mvc;
using Model.Request;
using Model.Response;

[Route("api/[controller]")]
[ApiController]
public class DetalleDePedidoController : ControllerBase
{
    private readonly IDetallePedidoBusiness _detalleDePedidoBusiness;

    public DetalleDePedidoController(IDetallePedidoBusiness detalleDePedidoBusiness)
    {
        _detalleDePedidoBusiness = detalleDePedidoBusiness;
    }

    [HttpGet]
    public async Task<ActionResult<List<DetallePedidoResponse>>> GetAll()
    {
        var result = await _detalleDePedidoBusiness.GetAll();
        return Ok(result);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<DetallePedidoResponse>> GetById(int id)
    {
        var result = await _detalleDePedidoBusiness.GetById(id);
        if (result == null)
            return NotFound();
        return Ok(result);
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] DetallePedidoRequest request)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        await _detalleDePedidoBusiness.Create(request);
        return Ok();
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, [FromBody] DetallePedidoRequest request)
    {
        await _detalleDePedidoBusiness.Update(id, request);
        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteById(int id)
    {
        await _detalleDePedidoBusiness.DeleteById(id);
        return NoContent();
    }
}
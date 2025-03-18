using System.Collections.Generic;
using System.Threading.Tasks;
using IBusiness;
using Microsoft.AspNetCore.Mvc;
using Model.Request;
using Model.Response;

namespace YourNamespace.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClienteController : ControllerBase
    {
        private readonly IClienteBusiness _clienteBusiness;

        public ClienteController(IClienteBusiness clienteBusiness)
        {
            _clienteBusiness = clienteBusiness;
        }

        [HttpGet]
        public async Task<ActionResult<List<ClienteResponse>>> GetAll()
        {
            var clientes = await _clienteBusiness.GetAll();
            return Ok(clientes);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ClienteResponse>> GetById(int id)
        {
            var cliente = await _clienteBusiness.GetById(id);
            if (cliente == null) return NotFound();
            return Ok(cliente);
        }

        [HttpPost]
        public async Task<ActionResult<ClienteResponse>> Create(ClienteRequest request)
        {
            var cliente = await _clienteBusiness.Create(request);
            return CreatedAtAction(nameof(GetById), new { id = cliente.Id }, cliente);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<ClienteResponse>> Update(int id, ClienteRequest request)
        {
            var updatedCliente = await _clienteBusiness.Update(id, request);
            return Ok(updatedCliente);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteById(int id)
        {
            var result = await _clienteBusiness.DeleteById(id);
            if (result == 0) return NotFound();
            return NoContent();
        }
    }
}

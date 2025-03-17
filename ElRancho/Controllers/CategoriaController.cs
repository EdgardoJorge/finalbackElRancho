using System.Collections.Generic;
using System.Threading.Tasks;
using IBusiness;
using Microsoft.AspNetCore.Mvc;
using Model.Request;
using Model.Response;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriaController : ControllerBase
    {
        private readonly ICategoriaBusiness _categoriaBusiness;

        public CategoriaController(ICategoriaBusiness categoriaBusiness)
        {
            _categoriaBusiness = categoriaBusiness;
        }

        [HttpGet]
        public async Task<ActionResult<List<CategoriaResponse>>> GetAll()
        {
            var categorias = await _categoriaBusiness.GetAllCategoriasAsync();
            return Ok(categorias);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<CategoriaResponse>> GetById(int id)
        {
            var categoria = await _categoriaBusiness.GetCategoriaByIdAsync(id);
            if (categoria == null) return NotFound();
            return Ok(categoria);
        }

        [HttpPost]
        public async Task<ActionResult<CategoriaResponse>> Create([FromBody] CategoriaRequest request)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            var categoria = await _categoriaBusiness.CreateCategoriaAsync(request);
            return CreatedAtAction(nameof(GetById), new { id = categoria.Id }, categoria);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] CategoriaRequest request)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            var updated = await _categoriaBusiness.UpdateCategoriaAsync(id, request);
            if (!updated) return NotFound();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var deleted = await _categoriaBusiness.DeleteCategoriaAsync(id);
            if (!deleted) return NotFound();
            return NoContent();
        }
    }
}

using IBusiness;
using Microsoft.AspNetCore.Mvc;
using Model.Request;
using Model.Response;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ElRancho.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductoController : ControllerBase
    {
        private readonly IProductoBusiness _productoBusiness;

        public ProductoController(IProductoBusiness productoBusiness)
        {
            _productoBusiness = productoBusiness;
        }

        [HttpGet]
        public async Task<ActionResult<List<ProductoResponse>>> GetAllProductos()
        {
            return Ok(await _productoBusiness.GetAllProductosAsync());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ProductoResponse>> GetProductoById(int id)
        {
            var producto = await _productoBusiness.GetProductoByIdAsync(id);
            if (producto == null) return NotFound();
            return Ok(producto);
        }

        [HttpPost]
        public async Task<ActionResult<ProductoResponse>> CreateProducto(ProductoRequest request)
        {
            var producto = await _productoBusiness.CreateProductoAsync(request);
            return CreatedAtAction(nameof(GetProductoById), new { id = producto.Id }, producto);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateProducto(int id, ProductoRequest request)
        {
            var updated = await _productoBusiness.UpdateProductoAsync(id, request);
            if (!updated) return NotFound();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProducto(int id)
        {
            var deleted = await _productoBusiness.DeleteProductoAsync(id);
            if (!deleted) return NotFound();
            return NoContent();
        }
        [HttpGet("buscar")]
        public async Task<ActionResult<List<ProductoResponse>>> BuscarProductos([FromQuery] string nombre)
        {
            var productos = await _productoBusiness.SearchProductoAsync(nombre);
            return Ok(productos);
        }
    }
}

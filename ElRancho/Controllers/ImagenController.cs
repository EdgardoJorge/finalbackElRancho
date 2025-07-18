using DbModel.ElRancho;
using IBussines;
using Microsoft.AspNetCore.Mvc;
using Model.Request;
using Model.Response;

namespace ElRancho.Controllers{
    [Route("api/[controller]")]
    [ApiController]
    public class ImagenController : ControllerBase
    {
        private readonly IImagenBusiness _imagenBusiness;

        public ImagenController(IImagenBusiness imagenBusiness)
        {
            _imagenBusiness = imagenBusiness;
        }

        [HttpGet]
        public async Task<ActionResult<List<ImagenResponse>>> Getall()
        {
            var result = await _imagenBusiness.GetAll();
            return Ok(result);
        }

        [HttpGet]
        [Route("obtener/{id}")]
        public async Task<ActionResult<ImagenResponse>> Getbyid([FromRoute] int id)
        {
            var result = await _imagenBusiness.GetById(id);
            if (result == null)
            {
                return NotFound();
            }

            return Ok(result);
            {
                
            }
        }
        [HttpPost]
        [Route("crear")]
        public async Task<ActionResult<ImagenResponse>> Create([FromBody] ImagenRequest request)
        {
            var result = await _imagenBusiness.Create(request);
            return CreatedAtAction(nameof(Getbyid), new { id = result.Id }, result);
        }

        [HttpDelete]
        [Route("delete/{id}")]
        public async Task<ActionResult> Delete([FromRoute] int id)
        {
            var result = await _imagenBusiness.Delete(id);
            if (result == null)
            {
                return NotFound();
            }

            return Ok(result);
        }

        [HttpPut]
        [Route("update/{id}")]
        public async Task<ActionResult<ImagenResponse>> Update([FromRoute] int id, [FromBody] ImagenRequest request)
        {
            var result = await _imagenBusiness.Update(id, request);
            if (result == null)
            {
                return NotFound();
            }

            return Ok(result);
        }
}}
using Microsoft.AspNetCore.Mvc;
using IBusiness;
using IBussines;
using Model.Request;
using Model.Response;

namespace ElRancho.Controllers{
[Route("api/[controller]")]
[ApiController]
public class rolController : ControllerBase
{
    private readonly IRolBussines _irolbussines;

    public rolController(IRolBussines rolbussines)
    {
        _irolbussines = rolbussines;
    }

    [HttpGet]
    [Route("getall")]
    public async Task<ActionResult<List<RolResponse>>> getall()
    {
        return Ok(await _irolbussines.GetAll());
    }

    [HttpGet]
    [Route("getbyid/{id}")]
    public async Task<ActionResult<RolResponse>> getbyid(int id)
    {
        var rol = await _irolbussines.GetById(id);
        if (rol == null)
        {
            return NotFound();
        }

        return Ok(rol);
    }

    [HttpPost]
    [Route("create")]
    public async Task<ActionResult<RolResponse>> create([FromBody] RolRequest request)
    {
        var rol = await _irolbussines.Create(request);
        return CreatedAtAction(nameof(getbyid), new { id = rol.Id }, rol);
    }
}}
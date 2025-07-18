using Microsoft.AspNetCore.Mvc;
using IBusiness;
using IBussines;
using Model.Response;

namespace ElRancho.Controllers{
[Route("api/[controller]")]
[ApiController]
public class rolController : ControllerBase
{
    private readonly IRolBussines _irolbussines;

    private rolController(IRolBussines rolbussines)
    {
        _irolbussines = rolbussines;
    }

    [HttpGet]
    [Route("getall")]
    public async Task<ActionResult<RolResponse>> getall()
    {
        return Ok(await _irolbussines.GetAll());
    }
}}
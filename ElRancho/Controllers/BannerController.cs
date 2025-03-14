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
    public class BannerController : ControllerBase
    {
        private readonly IBannerBusiness _bannerBusiness;

        public BannerController(IBannerBusiness bannerBusiness)
        {
            _bannerBusiness = bannerBusiness;
        }

        [HttpGet]
        public async Task<ActionResult<List<BannerResponse>>> GetAll()
        {
            var banners = await _bannerBusiness.GetAllBannersAsync();
            return Ok(banners);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<BannerResponse>> GetById(int id)
        {
            var banner = await _bannerBusiness.GetBannerByIdAsync(id);
            if (banner == null) return NotFound();
            return Ok(banner);
        }

        [HttpPost]
        public async Task<ActionResult<BannerResponse>> Create(BannerRequest request)
        {
            var banner = await _bannerBusiness.CreateBannerAsync(request);
            return CreatedAtAction(nameof(GetById), new { id = banner.Id }, banner);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<BannerResponse>> Update(int id, BannerRequest request)
        {
            var updated = await _bannerBusiness.UpdateBannerAsync(id, request);
            if (!updated) return NotFound();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteById(int id)
        {
            var deleted = await _bannerBusiness.DeleteBannerAsync(id);
            if (!deleted) return NotFound();
            return NoContent();
        }
    }
}

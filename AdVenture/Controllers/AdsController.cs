using AdVenture.Data;
using Microsoft.AspNetCore.Mvc;


namespace AdVenture.Controllers
{
    [ApiController]
    [Route("Ads")]

    public class AdsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public AdsController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllAds()
        {
            var ads = _context.Ads.ToList();
            return Ok(ads);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetAdById(int id)
        {
            var ad = _context.Ads.Find(id);
            if (ad == null)
            {
                return NotFound();
            }
            return Ok(ad);
        }
    }
}

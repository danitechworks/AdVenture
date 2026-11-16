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
        public IActionResult GetAllAds()
        {
            var ads = _context.Ads.ToList();
            return Ok(ads);
        }
    }
}

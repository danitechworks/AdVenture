using AdVenture.Data;
using Microsoft.AspNetCore.Mvc;
using AdVenture.Models;


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

        [HttpPost]
        public async Task<IActionResult> CreateAd(NewAd newAd)
        {
            var ad = new Ad
            {
                Title = newAd.Title,
                Description = newAd.Description,
                Price = newAd.Price,
                Category = newAd.Category
            };
            _context.Ads.Add(ad);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetAdById), new { id = ad.Id }, ad);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAd(int id, NewAd newAd)
        {
            var ad = _context.Ads.Find(id);
            if (ad == null)
            {
                return NotFound();
            }

            ad.Title = newAd.Title;
            ad.Description = newAd.Description;
            ad.Price = newAd.Price;
            ad.Category = newAd.Category;

            _context.Ads.Update(ad);
            await _context.SaveChangesAsync();

            return Ok(ad);
        }
    }
}

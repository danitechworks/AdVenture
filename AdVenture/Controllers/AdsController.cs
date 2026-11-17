using AdVenture.Data;
using Microsoft.AspNetCore.Mvc;
using AdVenture.Models;
using System.Text.Json;


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
            var ad = _context.Ads.FirstOrDefault(x => x.Id == id);
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
            var ad = _context.Ads.FirstOrDefault(x => x.Id == id);
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

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAd(int id)
        {
            var ad = _context.Ads.FirstOrDefault(x => x.Id == id);
            if (ad == null)
            {
                return NotFound();
            }

            _context.Ads.Remove(ad);
            await _context.SaveChangesAsync();

            return Ok(ad);
        }

        [HttpPatch("{id}")]
        public async Task<IActionResult> PatchAd(int id, [FromBody] PatchAd updates)
        {
            var ad = _context.Ads.FirstOrDefault(x => x.Id == id);
            if (ad == null)
            {
                return NotFound();
            }

            if (updates.Title is not null)
                ad.Title = updates.Title;

            if (updates.Description is not null)
                ad.Description = updates.Description;

            if (updates.Price is decimal price)
                ad.Price = price;

            if (updates.Category is not null)
                ad.Category = updates.Category;

            ModelState.Clear();
            if (!TryValidateModel(ad))
                return ValidationProblem(ModelState);

            await _context.SaveChangesAsync();
            return Ok(ad);
        }
    }
}

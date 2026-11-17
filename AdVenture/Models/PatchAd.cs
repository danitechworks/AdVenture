using System.ComponentModel.DataAnnotations;

namespace AdVenture.Models
{
    public class PatchAd
    {
        [StringLength(100, MinimumLength = 1)]
        public string? Title { get; set; }

        [StringLength(2000, MinimumLength = 1)]
        public string? Description { get; set; }

        [Range(typeof(decimal), "1", "1000000")]
        public decimal? Price { get; set; }

        [StringLength(50, MinimumLength = 1)]
        public string? Category { get; set; }
    }
}

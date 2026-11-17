using System.ComponentModel.DataAnnotations;

namespace AdVenture.Models
{
    public class NewAd
    {
        [Required]
        [StringLength(100)]
        public string Title { get; set; } = string.Empty;

        [Required]
        [StringLength(2000)]
        public string Description { get; set; } = string.Empty;

        [Required]
        [Range(typeof(decimal), "0", "1000000")]
        public decimal Price { get; set; }

        [Required]
        [StringLength(50)]
        public string Category { get; set; } = string.Empty;
    }
}

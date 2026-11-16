using Microsoft.EntityFrameworkCore;
using AdVenture.Models;

namespace AdVenture.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<Ad> Ads { get; set; }
    }
}

using AdVenture.Data;

namespace AdVenture.Controllers
{
    public class AdsController
    {
        private readonly ApplicationDbContext _context;

        public AdsController(ApplicationDbContext context)
        {
            _context = context;
        }
    }
}

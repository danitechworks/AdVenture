using AdVenture.Models;
using Microsoft.EntityFrameworkCore;

namespace AdVenture.Data
{
    public class DataInitializer
    {
        private readonly ApplicationDbContext _context;

        public DataInitializer(ApplicationDbContext context)
        {
            _context = context;
        }

        public void MigrateData()
        {
            _context.Database.Migrate();
            SeedData();
            _context.SaveChanges();
        }

        public void SeedData()
        {
            if (_context.Ads.Any())
                return;

            var ads = new List<Ad>
            {
                new() { Title = "IKEA MALM Desk", Description = "White desk in excellent condition. Pickup in Stockholm.", Price = 650m, Category = "Furniture" },
                new() { Title = "Samsung 55-inch Smart TV", Description = "4K UHD television, fully functional with remote.", Price = 3200m, Category = "Electronics" },
                new() { Title = "Trek Mountain Bike", Description = "21-speed mountain bike, recently serviced.", Price = 2400m, Category = "Sports" },
                new() { Title = "Vintage Brass Floor Lamp", Description = "Beautiful vintage lamp with adjustable lighting.", Price = 850m, Category = "Home Decor" },
                new() { Title = "Sony PlayStation 5", Description = "PS5 console with two controllers and three games.", Price = 3900m, Category = "Electronics" },
                new() { Title = "Winter Jacket Size M", Description = "Warm waterproof winter jacket, barely worn.", Price = 450m, Category = "Clothing" },
                new() { Title = "KitchenAid Stand Mixer", Description = "Red KitchenAid mixer with original accessories.", Price = 2800m, Category = "Appliances" },
                new() { Title = "Garden Dining Set", Description = "Outdoor table and four chairs, good condition.", Price = 1800m, Category = "Garden" },
                new() { Title = "Canon EOS 80D Camera", Description = "DSLR camera with 18-135mm lens and carrying bag.", Price = 5200m, Category = "Electronics" },
                new() { Title = "Solid Oak Bookshelf", Description = "Five-shelf oak bookcase with minor signs of wear.", Price = 1100m, Category = "Furniture" },
                new() { Title = "Bosch Cordless Drill", Description = "18V cordless drill with battery, charger and case.", Price = 900m, Category = "Tools" },
                new() { Title = "Acoustic Guitar Yamaha F310", Description = "Beginner-friendly guitar with soft carrying case.", Price = 750m, Category = "Music" },
                new() { Title = "Baby Stroller Emmaljunga", Description = "Well-maintained stroller with rain cover.", Price = 1600m, Category = "Baby & Kids" },
                new() { Title = "Apple iPad 10th Generation", Description = "64GB Wi-Fi model, excellent condition.", Price = 3100m, Category = "Electronics", IsActive = false },
                new() { Title = "Coffee Table in Walnut", Description = "Modern walnut coffee table with small surface scratches.", Price = 550m, Category = "Furniture", IsActive = false }
            };

            _context.Ads.AddRange(ads);
            _context.SaveChanges();

        }
    }
}

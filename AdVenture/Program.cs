using AdVenture.Data;
using Microsoft.EntityFrameworkCore;
using System.Text.Json.Serialization;

namespace AdVenture
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.            
            builder.Services.AddControllers()
                .AddJsonOptions(options =>
                {
                    options.JsonSerializerOptions.NumberHandling =
                        JsonNumberHandling.Strict;
                });

            // Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
            builder.Services.ConfigureHttpJsonOptions(options =>
            {
                options.SerializerOptions.NumberHandling = JsonNumberHandling.Strict;
            });
            builder.Services.AddOpenApi();

            // Add DbConext 
            builder.Services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

            // Add DataInitializer
            builder.Services.AddScoped<DataInitializer>();

            var app = builder.Build();

            // Seed the database with initial data
            using (var scope = app.Services.CreateScope())
            {
                var initializer = scope.ServiceProvider
                    .GetRequiredService<DataInitializer>();

                initializer.SeedData();
            }

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.MapOpenApi();
                app.UseSwaggerUI(appAction => 
                {
                    appAction.SwaggerEndpoint("/openapi/v1.json", "AdVenture API v1");
                    appAction.RoutePrefix = string.Empty;
                });
            }

            app.UseHttpsRedirection();
            
            app.UseAuthorization();

            app.MapControllers();

            app.Run();
        }
    }
}

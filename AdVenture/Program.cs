using Microsoft.EntityFrameworkCore;
using AdVenture.Data;

namespace AdVenture
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
            builder.Services.AddOpenApi();

            // Add DbConext 
            builder.Services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

            var app = builder.Build();

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

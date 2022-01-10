using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

using System.Linq;
using weatherapi.Data;

namespace weatherapi.Models
{
    public static class PrepDB
    {
        public static void PrepPopulation(IApplicationBuilder app)
        {
            using (var serviceScope = app.ApplicationServices.CreateScope())
            {
                SeedData(serviceScope.ServiceProvider.GetService<WeatherForecastContext>());
            }
        }


        public static void SeedData(WeatherForecastContext context)
        {
            System.Console.WriteLine("Application Migration");
            context.Database.Migrate();

            if (context.WeatherForecasts.Any())
            {
                System.Console.WriteLine("Adding data");
                context.WeatherForecasts.AddRange(
                    new WeatherForecast { Id = 0, TemperatureC = 10, Summary = "Cold" },
                    new WeatherForecast { Id = 1, TemperatureC = 25, Summary = "Medium" },
                    new WeatherForecast { Id = 2, TemperatureC = 40, Summary = "Hot" }
                );
                System.Console.WriteLine("Done adding data");
            }
            else
            {
                System.Console.WriteLine("Already have data");
            }
        }
    }
}
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
            System.Console.WriteLine("Done Migration");
            System.Console.WriteLine(context.WeatherForecasts);
            if (!context.WeatherForecasts.Any())
            {
                System.Console.WriteLine("Adding data");
                context.WeatherForecasts.AddRange(
                    new WeatherForecast { TemperatureC = 10, Summary = "Cold" },
                    new WeatherForecast { TemperatureC = 25, Summary = "Medium" },
                    new WeatherForecast { TemperatureC = 40, Summary = "Hot" }
                );
                context.SaveChanges();
                System.Console.WriteLine("Done adding data");
            }
            else
            {
                System.Console.WriteLine("Already have data");
            }

        }
    }
}
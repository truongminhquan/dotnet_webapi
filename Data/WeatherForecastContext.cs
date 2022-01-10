using Microsoft.EntityFrameworkCore;
using weatherapi.Models;

namespace weatherapi.Data
{
    public class WeatherForecastContext : DbContext
    {
        public WeatherForecastContext(DbContextOptions<WeatherForecastContext> opt) : base(opt)
        {

        }

        public DbSet<WeatherForecast> WeatherForecasts { get; set; }
    }
}
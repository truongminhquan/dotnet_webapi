using System.Collections.Generic;
using System.Linq;
using weatherapi.Models;

namespace weatherapi.Data
{
    public class SqlWeatherForecastRepo : IWeatherForecastRepo
    {
        private readonly WeatherForecastContext _context;

        public SqlWeatherForecastRepo(WeatherForecastContext context)
        {
            _context = context;
        }
        public IEnumerable<WeatherForecast> GetAllWeatherForecasts()
        {
            return _context.WeatherForecasts.ToList();
        }
    }
}
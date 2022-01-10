using System.Collections.Generic;
using weatherapi.Models;

namespace weatherapi.Data
{
    public class MockWeatherForecastRepo : IWeatherForecastRepo
    {
        public IEnumerable<WeatherForecast> GetAllWeatherForecasts()
        {
            var weatherForecasts = new List<WeatherForecast>{
                new WeatherForecast{Id=0, TemperatureC = 10, Summary = "Cold"},
                new WeatherForecast{Id=1, TemperatureC = 25, Summary = "Medium"},
                new WeatherForecast{Id=2, TemperatureC = 40, Summary = "Hot"}
            };

            return weatherForecasts;
        }
    }
}
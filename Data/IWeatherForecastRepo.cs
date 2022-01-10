using System.Collections.Generic;
using weatherapi.Models;
namespace weatherapi.Data
{
    public interface IWeatherForecastRepo
    {
        IEnumerable<WeatherForecast> GetAllWeatherForecasts();
    }
}
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using weatherapi.Data;
using weatherapi.Models;

namespace weatherapi.Controllers
{
    // api/WeatherForecast
    [Route("api/WeatherForecast")]
    [ApiController]
    public class WeatherForecastController : ControllerBase
    {
        private readonly IWeatherForecastRepo _repository;

        public WeatherForecastController(IWeatherForecastRepo repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public ActionResult<IEnumerable<WeatherForecast>> GetAllWeatherForecasts()
        {
            var weatherforecastItems = _repository.GetAllWeatherForecasts();
            return Ok(weatherforecastItems);
        }
    }
}
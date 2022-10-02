using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Primitives;
using Newtonsoft.Json;
using Prj.Net6.API.Exceptions;
using Prj.Net6.Core.Entities;
using Prj.Net6.Service.Services;
using NotImplementedException = Prj.Net6.API.Exceptions.NotImplementedException;

namespace Prj.Net6.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };

        private readonly ILogger<WeatherForecastController> _logger;

        public WeatherForecastController(ILogger<WeatherForecastController> logger)
        {
            _logger = logger;
        }

        [HttpGet(Name = "GetWeatherForecast")]
        public IEnumerable<WeatherForecast> Get()
        {

            HttpContext.Response.Headers.TryAdd("MyCustomResponseHeader", new StringValues("test-value"));

            _logger.LogDebug("Inside GetWeatherForecast endpoint");

            //throw new Exception("Failed to retrieve data");
            var response = Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = Random.Shared.Next(-20, 55),
                Summary = Summaries[Random.Shared.Next(Summaries.Length)]
            }).ToArray();

            _logger.LogDebug($"The response for the get weather forecast is {JsonConvert.SerializeObject(response)}");

            return response;
        }


        //
        [HttpGet("filterweather")]
        public Task<List<WeatherForecast>> FilterWeather(int Id)
        {
            throw new NotImplementedException("Not Implemented Exception!");
        }

        [HttpGet("getweatherbyid")]
        public IEnumerable<WeatherForecast> GetProductById(int Id)
        {
            _logger.LogInformation($"Fetch Weahter with ID: {Id} from the database");

            var response = Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = Random.Shared.Next(-20, 55),
                Summary = Summaries[Random.Shared.Next(Summaries.Length)]
            }).ToArray();

            if (Id == 0)
            {
                throw new NotFoundException($"Weather ID {Id} not found.");
            }
            
            _logger.LogInformation($"Returning Weather with ID: {Id}.");
            return response;
        }

    }
}
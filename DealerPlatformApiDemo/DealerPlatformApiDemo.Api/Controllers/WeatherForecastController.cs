using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DealerPlatformApiDemo.Core.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace DealerPlatformApiDemo.Api.Controllers
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
        private readonly SqlHelper _sqlHelper;
        private readonly DbHelper _dbHelper;

        public WeatherForecastController(ILogger<WeatherForecastController> logger, SqlHelper sqlHelper, DbHelper dbHelper)
        {
            _logger = logger;
            _sqlHelper = sqlHelper;
            _dbHelper = dbHelper;
        }

        [HttpGet]
        public IEnumerable<WeatherForecast> Get()
        {
            try
            {
                _sqlHelper.ExecuteNoQuery("aa");
            }
            catch (Exception e)
            {
                _dbHelper.ExecuteNoQuery("bb");
            }


            var rng = new Random();
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = rng.Next(-20, 55),
                Summary = Summaries[rng.Next(Summaries.Length)]
            })
            .ToArray();
        }
    }
}

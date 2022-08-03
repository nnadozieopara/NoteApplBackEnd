using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace CCSA_Web.Controllers
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
        public IDependency Dependency { get; }

        public WeatherForecastController(ILogger<WeatherForecastController> logger, IDependency dependency)
        {
            _logger = logger;
            Dependency = dependency;
        }


        [HttpPost]
        public async Task<IActionResult> GetByOverload([FromBody] WeatherForecast weather)
        {
            //https://localhost:5274/weatherforecast?name=jh&course=ijj
            //Reflection get me the class with Attributes ApiController
            var result = Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = Random.Shared.Next(-20, 55),
                Shared = SharedEnum.Public,
                Summary = Summaries[Random.Shared.Next(Summaries.Length)]
            })
            .ToArray();
            await Task.Delay(2000);
            return Ok(weather.Summary);
        }

        [HttpGet]
        public async Task<IActionResult> GetMethod()
        {
            await Task.Delay(100);
            Dependency.print("Hello World, Called");
            return Ok("Entered");
        }

        [HttpGet("/weatherforecast/getall/{name}/{course}")]
        public async Task<IActionResult> Get(string name, string course)
        {
            var result = Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = Random.Shared.Next(-20, 55),
                Shared = SharedEnum.Public,
                Summary = Summaries[Random.Shared.Next(Summaries.Length)]
            })
            .ToArray();
            await Task.Delay(2000);
            return Ok($"{name}");
        }


        [HttpPut("/weatherforecast/{id}")]
        public async Task<IActionResult> Update(int id,[FromBody] WeatherForecast model)
        {
            return Ok(model);
        }

        [HttpGet("/weatherforecast/overlad")]
        public async Task<IActionResult> Get2(string name, string course)
        {
            var result = Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = Random.Shared.Next(-20, 55),
                Shared = SharedEnum.Public,
                Summary = Summaries[Random.Shared.Next(Summaries.Length)]
            })
            .ToArray();
            await Task.Delay(2000);
            return Ok($"{name} - {course}");
        }

        [HttpGet("badcall")]
        public IActionResult GetNew()
        {
            return BadRequest("Hello Bad Call");
        }


    }
}

public class NewClass
{
    public NewClass(IDependency dependency)
    {
                    
    }
}

public class Dependency: IDependency
{
    public void print(string overload)
    {
        Console.WriteLine(overload);
    }
}

public class DependencyNew : Dependency
{
    public new void print(string overload)
    {
        Console.WriteLine(overload+"New");
    }
}
public interface IDependency
{
    void print(string overload);
}
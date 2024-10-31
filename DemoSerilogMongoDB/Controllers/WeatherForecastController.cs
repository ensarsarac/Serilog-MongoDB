using DemoSerilogMongoDB.LogEntries;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft;
using Newtonsoft.Json;
namespace DemoSerilogMongoDB.Controllers
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
			var response = Enumerable.Range(1, 5).Select(index => new WeatherForecast
			{
				Date = DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
				TemperatureC = Random.Shared.Next(-20, 55),
				Summary = Summaries[Random.Shared.Next(Summaries.Length)]
			})
			.ToArray();

			LogEntry logEntry = new LogEntry
			{
				Message = "Get endpoint istekde bulundu",
				Data = new Dictionary<string, object>()
				{
					{ "Response",JsonConvert.SerializeObject(response) }
				}
			};

			_logger.LogInformation("Log entry:{@logEntry}", logEntry);
			//_logger.LogInformation($"Get endpoint çaðrýldý. data:{JsonConvert.SerializeObject(response)}");

			return response;
		}
	}
}

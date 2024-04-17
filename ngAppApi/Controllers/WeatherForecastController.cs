using Microsoft.AspNetCore.Mvc;
using ngAppApi.Core.Cqs;
using ngAppApi.TestPOC.Commands;
using ngAppApi.TestPOC.Queries;

namespace ngAppApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private readonly ILogger<WeatherForecastController> _logger;
        private readonly ICqsDispatcher _cqsDispatcher;

        public WeatherForecastController(ILogger<WeatherForecastController> logger, ICqsDispatcher cqsDispatcher)
        {
            _logger = logger;
            _cqsDispatcher = cqsDispatcher;
        }

        [HttpGet("get-weather-forecast")]
        public async Task<ActionResult<IEnumerable<WeatherForecast>>> Get()
        {
            var query = new TestListDataQuery();
            var foobar = await _cqsDispatcher.HandleQueryAsync<TestListDataQuery, List<WeatherForecast>>(query);
            return Ok(foobar);
        }

        [HttpGet("get-weather-forecast-singular")]
        public async Task<ActionResult<WeatherForecast>> GetSingular()
        {
            var query = new TestSingularDataQuery();
            var foobar = await _cqsDispatcher.HandleQueryAsync<TestSingularDataQuery, WeatherForecast>(query);
            _logger.LogInformation("dasdas");
            return Ok(foobar);
        }

        [HttpPost("do-sth")]
        public async Task<ActionResult> DoSth()
        {
            var command = new DoSthCommand();
            await _cqsDispatcher.HandleCommandAsync(command);
            return Ok();
        }

    }
}
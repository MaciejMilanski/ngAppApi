using ngAppApi.Core.Cqs;

namespace ngAppApi.TestPOC.Queries.Handlers
{
    public class TestSingularDataQueryHandler : QueryHandlerAsync<TestSingularDataQuery, WeatherForecast>
    {
        private static readonly string[] Summaries = new[]
{
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        public override async Task<WeatherForecast> HandleQueryAsync(TestSingularDataQuery query)
        {
            var foo = new WeatherForecast
            {
                Date = DateTime.Now.AddDays(2),
                TemperatureC = Random.Shared.Next(-20, 55),
                Summary = Summaries[Random.Shared.Next(Summaries.Length)]
            };

            return foo;
        }
    }
}

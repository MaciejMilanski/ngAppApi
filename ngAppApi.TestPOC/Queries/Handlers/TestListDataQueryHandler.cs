using ngAppApi.Core.Cqs;

namespace ngAppApi.TestPOC.Queries.Handlers
{
    public class TestListDataQueryHandler : QueryHandlerAsync<TestListDataQuery, List<WeatherForecast>>
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        public override async Task<List<WeatherForecast>> HandleQueryAsync(TestListDataQuery query)
        {
            var bar = await Task.Run(() => 2 + 2);

            var foo = Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = Random.Shared.Next(-20, 55),
                Summary = Summaries[Random.Shared.Next(Summaries.Length)]
            }).ToList();

            return foo;
        }
    }
}

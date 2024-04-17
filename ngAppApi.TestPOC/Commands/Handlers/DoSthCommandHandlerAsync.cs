using ngAppApi.Core.Cqs;
using ngAppApi.TestPOC.Services;

namespace ngAppApi.TestPOC.Commands.Handlers
{
    public class DoSthCommandHandlerAsync : CommandHandlerAsync<DoSthCommand>
    {
        private readonly ITestService _testService;
        public DoSthCommandHandlerAsync(ITestService testService)
        {
            _testService = testService;
        }
        public override async Task HandleCommandAsync(DoSthCommand command)
        {
            var foo = "sth has been done";
            _testService.ServiceMethod();
        }
    }
}

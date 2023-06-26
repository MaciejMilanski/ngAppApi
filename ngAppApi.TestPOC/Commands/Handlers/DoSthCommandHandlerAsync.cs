using ngAppApi.Core.Cqs;

namespace ngAppApi.TestPOC.Commands.Handlers
{
    public class DoSthCommandHandlerAsync : CommandHandlerAsync<DoSthCommand>
    {
        public override async Task HandleCommandAsync(DoSthCommand command)
        {
            var foo = "sth has been done";
        }
    }
}

namespace ngAppApi.Core.Cqs
{
    public abstract class CommandHandlerAsync<T> : ICommandHandlerAsync where T : ICommand
    {
        public abstract Task HandleCommandAsync(T command);
    }
}

namespace ngAppApi.Core.Cqs
{
    public abstract class CommandHandler<T> : ICommandHandler where T : ICommand
    {
        public abstract void HandleCommand(T command);
    }
}

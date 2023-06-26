namespace ngAppApi.Core.Cqs
{
    public interface ICqsDispatcher
    {
        Task HandleCommandAsync<T>(T command) where T : ICommand;
        Task<TResult> HandleQueryAsync<T, TResult>(T query) where T : IQuery<TResult>;
    }
}

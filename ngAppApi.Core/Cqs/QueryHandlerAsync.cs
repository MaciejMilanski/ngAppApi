namespace ngAppApi.Core.Cqs
{
    public abstract class QueryHandlerAsync<TQuery, TResult> : IQueryHandlerAsync where TQuery : IQuery<TResult>
    {
        public abstract Task<TResult> HandleQueryAsync(TQuery query);
    }
}

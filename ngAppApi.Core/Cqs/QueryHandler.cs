namespace ngAppApi.Core.Cqs
{
    public abstract class QueryHandler<TQuery, TResult> : IQueryHandler where TQuery : IQuery<TResult>
    {
        public abstract TResult HandleQuery(TQuery query);
    }
}

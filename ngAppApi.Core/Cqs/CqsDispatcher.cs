namespace ngAppApi.Core.Cqs
{
    public class CqsDispatcher : ICqsDispatcher
    {

        private readonly Dictionary<Type, ICommandHandler> _handlersDictionary;
        private readonly Dictionary<Type, ICommandHandlerAsync> _handlersAsyncDictionary;
        private readonly Dictionary<Type, IQueryHandler> _queriesDictionary;
        private readonly Dictionary<Type, IQueryHandlerAsync> _queriesAsyncDictionary;

        public CqsDispatcher(
                IEnumerable<ICommandHandler> commandHandlers,
                IEnumerable<ICommandHandlerAsync> commandHandlersAsync,
                IEnumerable<IQueryHandler> queryHandlers,
                IEnumerable<IQueryHandlerAsync> queryHandlersAsync)
        {
            _handlersDictionary = new Dictionary<Type, ICommandHandler>();
            foreach (var commandHandler in commandHandlers)
            {
                var handledCommandType = commandHandler.GetType().BaseType.GetGenericArguments()[0];
                _handlersDictionary.Add(handledCommandType, commandHandler);
            }

            _handlersAsyncDictionary = new Dictionary<Type, ICommandHandlerAsync>();
            foreach (var commandHandlerAsync in commandHandlersAsync)
            {
                var handledCommandType = commandHandlerAsync.GetType().BaseType.GetGenericArguments()[0];
                _handlersAsyncDictionary.Add(handledCommandType, commandHandlerAsync);
            }

            _queriesDictionary = new Dictionary<Type, IQueryHandler>();
            foreach (var queryHandler in queryHandlers)
            {
                var handledQueryType = queryHandler.GetType().BaseType.GetGenericArguments()[0];
                _queriesDictionary.Add(handledQueryType, queryHandler);
            }

            _queriesAsyncDictionary = new Dictionary<Type, IQueryHandlerAsync>();
            foreach (var queryHandlerAsync in queryHandlersAsync)
            {
                var handledQueryAsyncType = queryHandlerAsync.GetType().BaseType.GetGenericArguments()[0];
                _queriesAsyncDictionary.Add(handledQueryAsyncType, queryHandlerAsync);
            }
        }

        public async Task HandleCommandAsync<T>(T command) where T : ICommand
        {
            if (_handlersDictionary.TryGetValue(typeof(T), out ICommandHandler selectedHandler))
            {
                var commandHandler = selectedHandler as CommandHandler<T>;
                commandHandler.HandleCommand(command);
            }
            else if (_handlersAsyncDictionary.TryGetValue(typeof(T), out ICommandHandlerAsync selectedHandlerAsync))
            {
                var commandHandlerAsync = selectedHandlerAsync as CommandHandlerAsync<T>;
                await commandHandlerAsync.HandleCommandAsync(command).ConfigureAwait(false);
            }
            else
            {
                throw new Exception($"No handler registered for command {command.GetType()}");
            }
        }

        public async Task<TResult> HandleQueryAsync<TQuery, TResult>(TQuery query) where TQuery : IQuery<TResult>
        {
            var queryType = query.GetType();

            if (_queriesDictionary.TryGetValue(queryType, out IQueryHandler selectedHandler))
            {
                var queryHandler = selectedHandler as QueryHandler<TQuery, TResult>;
                return queryHandler.HandleQuery(query);
            }
            else if (_queriesAsyncDictionary.TryGetValue(queryType, out IQueryHandlerAsync selectedHandlerAsync))
            {
                var queryHandlerAsync = selectedHandlerAsync as QueryHandlerAsync<TQuery, TResult>;
                return await queryHandlerAsync.HandleQueryAsync(query).ConfigureAwait(false);
            }
            else
            {
                throw new Exception($"No handler registered for query {queryType}");
            }
        }

        //public async Task<TResult> HandleQueryAsync<TQuery, TResult>(TQuery query) where TQuery : IQuery<TResult>
        //{
        //    var queryType = query.GetType();

        //    if (_queriesDictionary.TryGetValue(queryType, out IQueryHandler selectedHandler))
        //    {
        //        var queryHandler = selectedHandler as QueryHandler<TQuery, TResult>;
        //        return queryHandler.Handle(query);
        //    }
        //    else if (_queriesAsyncDictionary.TryGetValue(queryType, out IQueryHandlerAsync selectedHandlerAsync))
        //    {
        //        var queryHandlerAsync = selectedHandlerAsync as QueryHandlerAsync<TQuery, TResult>;
        //        return await queryHandlerAsync.HandleAsync(query).ConfigureAwait(false);
        //    }
        //    else
        //    {
        //        throw new Exception($"No handler registered for query {queryType}");
        //    }
        //}
    }
}

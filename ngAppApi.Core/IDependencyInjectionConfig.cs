namespace ngAppApi.Core
{
    public interface IDependencyInjectionConfig
    {
        void AddWithDefaultLifetime<TService, TImplementation>()
            where TService : class
            where TImplementation : class, TService;
        void AddWithDefaultLifetime<TService>()
            where TService : class;
        void AddWithDefaultLifetime<TService>(Func<IServiceProvider, TService> factoryFunc)
            where TService : class;

        void AddRequestScope<TImplementation>()
            where TImplementation : class;
        void AddRequestScope<TService, TImplementation>()
            where TService : class
            where TImplementation : class, TService;
        void AddRequestScope<TService>(Func<IServiceProvider, TService> factoryFunc)
            where TService : class;
        void AddTransient<TService, TImplementation>()
            where TService : class
            where TImplementation : class, TService;
        void AddSingleton<TService>(Func<IServiceProvider, TService> factoryFunc)
            where TService : class;
        void AddSingleton<TService, TImplementation>()
            where TService : class
            where TImplementation : class, TService;
        void AddSingleton<TService>(TService instance)
            where TService : class;
    }
}

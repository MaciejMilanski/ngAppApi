using ngAppApi.Core;


namespace ngAppApi
{
    public class MicrosoftDependencyInjectionConfiguration : IDependencyInjectionConfig
    {
        private readonly IServiceCollection _serviceCollection;
        private readonly ServiceLifetime _defaultLifetime;

        public MicrosoftDependencyInjectionConfiguration(IServiceCollection serviceCollection, ServiceLifetime defaultLifetime)
        {
            _serviceCollection = serviceCollection;
            _defaultLifetime = defaultLifetime;
        }

        public void AddRequestScope<TImplementation>() where TImplementation : class
        {
            _serviceCollection.AddScoped<TImplementation>();
        }

        public void AddRequestScope<TService>(Func<IServiceProvider, TService> factoryFunc) where TService : class
        {
            _serviceCollection.AddScoped<TService>(factoryFunc);
        }

        public void AddSingleton<TService>(Func<IServiceProvider, TService> factoryFunc) where TService : class
        {
            _serviceCollection.AddSingleton<TService>(factoryFunc);
        }

        public void AddSingleton<TService>(TService instance) where TService : class
        {
            _serviceCollection.AddSingleton<TService>(instance);
        }

        public void AddWithDefaultLifetime<TService>() where TService : class
        {
            _serviceCollection.Add(new ServiceDescriptor(typeof(TService), typeof(TService), _defaultLifetime));
        }

        public void AddWithDefaultLifetime<TService>(Func<IServiceProvider, TService> factoryFunc) where TService : class
        {
            _serviceCollection.Add(new ServiceDescriptor(typeof(TService), factoryFunc, _defaultLifetime));
        }

        void IDependencyInjectionConfig.AddRequestScope<TService, TImplementation>()
        {
            _serviceCollection.AddScoped<TService, TImplementation>();
        }

        void IDependencyInjectionConfig.AddSingleton<TService, TImplementation>()
        {
            _serviceCollection.AddSingleton<TService, TImplementation>();
        }

        void IDependencyInjectionConfig.AddTransient<TService, TImplementation>()
        {
            _serviceCollection.AddTransient<TService, TImplementation>();
        }

        void IDependencyInjectionConfig.AddWithDefaultLifetime<TService, TImplementation>()
        {
            _serviceCollection.Add(new ServiceDescriptor(typeof(TService), typeof(TImplementation), _defaultLifetime));
        }
    }
}

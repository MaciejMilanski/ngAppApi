using ngAppApi.Core;
using ngAppApi.Core.Cqs;
using ngAppApi.SentimentAnalysis.Queries.Handlers;
using ngAppApi.SentimentAnalysis.Services;
using ngAppApi.SentimentAnalysis.Services.Implementations;
using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("DynamicProxyGenAssembly2")]
namespace ngAppApi.SentimentAnalysis
{
    public class Bootstrap
    {
        public static void Configure(IDependencyInjectionConfig config)
        {
            config.AddWithDefaultLifetime<IPredictionResultResolverService, PredictionResultResolverService>();
            config.AddWithDefaultLifetime<IQueryHandler, ClassifySentimentQueryHandler>();
        }
    }
}

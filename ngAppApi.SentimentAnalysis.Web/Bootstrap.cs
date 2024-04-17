using ngAppApi.Core;

namespace ngAppApi.SentimentAnalysis.Web
{
    public class Bootstrap
    {
        public static void Configure(IDependencyInjectionConfig config)
        {
            SentimentAnalysis.Bootstrap.Configure(config);
        }
    }
}

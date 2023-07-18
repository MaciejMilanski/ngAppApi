using ngAppApi.Core;
using ngAppApi.TestPOC.Services;
using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("DynamicProxyGenAssembly2")]
namespace ngAppApi.TestPOC
{
    public class Bootstrap
    {
        public static void Configure(IDependencyInjectionConfig config)
        {
            config.AddWithDefaultLifetime<ITestService, TestService>();
        }
    }
}

using ngAppApi.Core;
using ngAppApi.Core.Cqs;
using ngAppApi.TestPOC.Commands.Handlers;
using ngAppApi.TestPOC.Queries.Handlers;
using Serilog;

namespace ngAppApi
{
    public class Program
    {
        private const string CORS_LOCAL_POLICY = "CorsLocalPolicy";
        private const string CORS_REMOTE_POLICY = "CorsRemotePolicy";

        public static void Main(string[] args)
        {
            var config = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json", optional: false)
                .Build();

            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            var logger = new LoggerConfiguration()
                .ReadFrom.Configuration(builder.Configuration)
                .Enrich.FromLogContext()
                .CreateLogger();

            var sentimentAnalysisModuleWebAssembly = typeof(SentimentAnalysis.Web.Bootstrap).Assembly;

            builder.Services.AddControllers()
                .AddApplicationPart(sentimentAnalysisModuleWebAssembly);
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            builder.Logging.ClearProviders();
            builder.Services.AddSerilog(logger);

            builder.Services.AddCors(o =>
            {
                o.AddPolicy(CORS_LOCAL_POLICY, builder =>
                {
                    builder
                    .SetIsOriginAllowed(_ => true)
                    .AllowAnyMethod()
                    .AllowAnyHeader()
                    .AllowCredentials();
                });

                //o.AddPolicy(CORS_REMOTE_POLICY, builder =>
                //{
                //    builder
                //    .WithOrigins(config.GetValue<string[]>("Cors:Origins"))
                //    .AllowAnyMethod()
                //    .AllowAnyHeader()
                //    .AllowCredentials();
                //});
            });
            IDependencyInjectionConfig diConfig = new MicrosoftDependencyInjectionConfiguration(
                builder.Services, Microsoft.Extensions.DependencyInjection.ServiceLifetime.Scoped);

            builder.Services.AddScoped<ICommandHandlerAsync, DoSthCommandHandlerAsync>();

            builder.Services.AddScoped<IQueryHandlerAsync, TestSingularDataQueryHandler>();
            builder.Services.AddScoped<IQueryHandlerAsync, TestListDataQueryHandler>();
            builder.Services.AddScoped<ICqsDispatcher, CqsDispatcher>();

            ngAppApi.TestPOC.Bootstrap.Configure(diConfig);
            ngAppApi.SentimentAnalysis.Web.Bootstrap.Configure(diConfig);

            var app = builder.Build();
            // Just to check releases, you didn't see it (flash!)
            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
                app.UseCors(CORS_LOCAL_POLICY);
            }
            else
            {
                app.UseCors(CORS_REMOTE_POLICY);
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();

            app.MapControllers();

            app.Run();
        }
    }
}
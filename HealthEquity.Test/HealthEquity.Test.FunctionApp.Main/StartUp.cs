using AzureFunctions.Extensions.Swashbuckle;
using AzureFunctions.Extensions.Swashbuckle.Settings;
using HealthEquity.Test.Domain.Services;
using HealthEquity.Test.FunctionApp.Main;
using HealthEquity.Test.Services.Cars;
using Microsoft.Azure.Functions.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

[assembly: FunctionsStartup(typeof(StartUp))]
namespace HealthEquity.Test.FunctionApp.Main
{
    internal class StartUp : FunctionsStartup
    {
        public override void Configure(IFunctionsHostBuilder builder)
        {

            var configuration = new ConfigurationBuilder().AddEnvironmentVariables().Build();

            builder.AddSwashBuckle(Assembly.GetExecutingAssembly(), opts =>
            {
                opts.AddCodeParameter = true;

                opts.Documents = new[]
                {
                    new SwaggerDocument
                    {
                        Name = "v1",
                        Title = "HealthEquity Api",
                        Version = "v1",
                    }
                };
            });

            builder.Services.AddCarsforceService(configuration);
        }
    }
    static class CustomExtensions
    {
        public static IServiceCollection AddCarsforceService(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddSingleton<ICarService>(sp => 
            {
                return new CarService();
            });

            return services;
        }
    }
}

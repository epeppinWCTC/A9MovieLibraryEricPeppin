using System;
using A4___Movie_Library___Eric_Peppin.Data;
using A4___Movie_Library___Eric_Peppin.Services;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace A4___Movie_Library___Eric_Peppin
{
    public class Startup
    {
        public IServiceProvider ConfigureServices()
        {
            IServiceCollection services = new ServiceCollection();

            services.AddLogging(builder =>
            {
                builder.AddConsole();
                //builder.AddFile("app.log");
            });

            // Add new lines of code here to register any interfaces and concrete services you create
            services.AddTransient<IMainService, MainService>();
            services.AddTransient<IOrchestrator, OrchestratorService>();
            return services.BuildServiceProvider();
        }
    }
}
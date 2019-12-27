using Entities.Factory;
using Entities.WeatherControl;
using HwEFCoreWebAPI.Models;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace HwEFCoreWebAPI.Tasks
{
    public class ForecastGenerationHostedService : IHostedService
    {
        private readonly IServiceProvider _serviceProvider;

        public ForecastGenerationHostedService(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        public async Task StartAsync(CancellationToken cancellationToken)
        {
            // Create a new scope to retrieve scoped services
            using (var scope = _serviceProvider.CreateScope())
            {
                // Get the DbContext instance
                var forecastContext = scope.ServiceProvider.GetRequiredService<ForecastContext>();

                var solarSystem = SolarSystemFactory.GenerateSolarSystem();
                var weatherControlSystem = new WeatherControlSystem(solarSystem);
                await forecastContext.Forecasts.AddRangeAsync(weatherControlSystem.CalculateForecast(3650));
                await forecastContext.SaveChangesAsync();
            }
        }

        // noop
        public Task StopAsync(CancellationToken cancellationToken) => Task.CompletedTask;
    }
}

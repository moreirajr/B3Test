using B3Test.Monitoring.Abstractions;
using B3Test.Monitoring.Abstractions.Configurator;
using B3Test.Monitoring.Abstractions.Providers;
using B3Test.Monitoring.Prometheus.Configurator;
using Microsoft.AspNetCore.Builder;

namespace B3Test.Monitoring.AspNetCore.Providers
{
    public class ApiMonitoringProvider : IMonitoringProvider
    {
        private readonly IApplicationBuilder _app;
        public ApiMonitoringProvider(IApplicationBuilder app)
        {
            _app = app;
        }

        private IDictionary<EMonitoringProvider, Func<IApplicationBuilder, IMonitoringConfigurator?>> ConfigurationStrategy =
            new Dictionary<EMonitoringProvider, Func<IApplicationBuilder, IMonitoringConfigurator?>>
            {
                [EMonitoringProvider.None] = NoConfiguration,
                [EMonitoringProvider.Prometheus] = ConfigurePrometheus
            };

        /// <summary>
        /// Uses strategy based on EMonitoringProvider to create a configurator (IMonitoringConfigurator) instance.
        /// </summary>
        /// <param name="provider"></param>
        /// <returns></returns>
        public IMonitoringConfigurator? GetConfigurator(EMonitoringProvider provider)
        {
            var configurator = ConfigurationStrategy[provider];
            return configurator.Invoke(_app);
        }

        private static IMonitoringConfigurator? NoConfiguration(IApplicationBuilder app)
            => null;

        private static IMonitoringConfigurator? ConfigurePrometheus(IApplicationBuilder app)
            => new PrometheusApiMonitoringConfigurator(app);
    }
}

using B3Test.Monitoring.Abstractions;
using B3Test.Monitoring.Abstractions.Configurator;
using B3Test.Monitoring.Abstractions.Providers;
using B3Test.Monitoring.Prometheus.Configurator;

namespace B3Test.Monitoring.AspNetCore.Providers
{
    public class WorkerMonitoringProvider : IMonitoringProvider
    {
        private IDictionary<EMonitoringProvider, Func<IMonitoringConfigurator?>> ConfigurationStrategy =
           new Dictionary<EMonitoringProvider, Func<IMonitoringConfigurator?>>
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
            return configurator.Invoke();
        }

        private static IMonitoringConfigurator? NoConfiguration()
            => null;

        private static IMonitoringConfigurator? ConfigurePrometheus()
            => new PrometheusWorkerMonitoringConfigurator();
    }
}

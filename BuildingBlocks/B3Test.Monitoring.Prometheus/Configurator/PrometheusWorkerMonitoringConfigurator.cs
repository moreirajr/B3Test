using B3Test.Monitoring.Abstractions;
using B3Test.Monitoring.Abstractions.Configurator;
using Prometheus;

namespace B3Test.Monitoring.Prometheus.Configurator
{
    public class PrometheusWorkerMonitoringConfigurator : IMonitoringConfigurator
    {
        public void Configure(MonitoringConfiguration configuration)
        {
            var server = new KestrelMetricServer(port: configuration.Port);
            server.Start();
        }
    }
}

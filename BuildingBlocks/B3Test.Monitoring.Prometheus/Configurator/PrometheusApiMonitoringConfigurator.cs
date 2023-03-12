using B3Test.Monitoring.Abstractions;
using B3Test.Monitoring.Abstractions.Configurator;
using Microsoft.AspNetCore.Builder;

namespace B3Test.Monitoring.Prometheus.Configurator
{
    public class PrometheusApiMonitoringConfigurator : IMonitoringConfigurator
    {
        private readonly IApplicationBuilder _app;
        public PrometheusApiMonitoringConfigurator(IApplicationBuilder app)
        {
            _app = app;
        }

        public void Configure(MonitoringConfiguration configuration)
        {
            _app.ConfigurePrometheus();
        }
    }
}

using B3Test.Monitoring.Abstractions;
using B3Test.Monitoring.AspNetCore.Providers;

namespace B3Test.Worker.Extensions
{
    public static class HostExtensions
    {
        private const string ConfigurationSectionName = "MonitoringConfiguration";

        public static void ConfigureWorkerMonitoring(this IHost host)
        {
            var configuration = host.Services.GetService<IConfiguration>();
            if (configuration == null) throw new ArgumentNullException(nameof(configuration), "Configuration cannot be null");

            var monitoringConfiguration = configuration.GetSection(ConfigurationSectionName).Get<MonitoringConfiguration>();

            var monitoringProvider = new WorkerMonitoringProvider();
            var configurator = monitoringProvider.GetConfigurator(monitoringConfiguration.Provider);

            if (configurator != null)
                configurator.Configure(monitoringConfiguration);
        }
    }
}
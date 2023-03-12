using B3Test.Monitoring.Abstractions;
using B3Test.Monitoring.AspNetCore.Providers;

namespace B3Test.Api.Extensions
{
    public static class ApplicationBuilderExtensions
    {
        private const string ConfigurationSectionName = "MonitoringConfiguration";

        public static void ConfigureApplicationMonitoring(this IApplicationBuilder app, IConfiguration configuration)
        {
            var monitoringConfiguration = configuration.GetSection(ConfigurationSectionName).Get<MonitoringConfiguration>();

            var monitoringProvider = new ApiMonitoringProvider(app);
            var configurator = monitoringProvider.GetConfigurator(monitoringConfiguration.Provider);

            if (configurator != null)
                configurator.Configure(monitoringConfiguration);
        }
    }
}

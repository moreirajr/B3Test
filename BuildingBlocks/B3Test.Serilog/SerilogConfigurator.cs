using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Serilog;

namespace B3Test.Serilog
{
    public static class SerilogConfigurator
    {
        private const string DATADOG_CONFIG_SECTION = "DatadogAgentConfiguration";
        private static Action<HostBuilderContext, LoggerConfiguration> Configure
            => (context, configuration) =>
            {
                var datadogConfiguration = context.Configuration.GetSection(DATADOG_CONFIG_SECTION).Get<DatadogAgentConfiguration>();
                configuration
                    .Enrich.FromLogContext()
                    .Enrich.WithMachineName()
                    .WriteTo.Debug()
                    .WriteTo.Console()
                    .WriteTo.DatadogLogs(datadogConfiguration.ApiKey,
                        service: context.HostingEnvironment.ApplicationName,
                        host: context.HostingEnvironment.EnvironmentName)
                    .ReadFrom.Configuration(context.Configuration);
            };

        public static IHostBuilder UseSerilog(this IHostBuilder builder)
        {
            builder.UseSerilog(Configure);
            return builder;
        }
    }
}

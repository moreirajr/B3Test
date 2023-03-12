using B3Test.Monitoring.Abstractions.Configurator;

namespace B3Test.Monitoring.Abstractions.Providers
{
    public interface IMonitoringProvider
    {
        public IMonitoringConfigurator? GetConfigurator(EMonitoringProvider provider);
    }
}
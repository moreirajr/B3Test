namespace B3Test.Monitoring.Abstractions
{
    public record MonitoringConfiguration
    {
        public int Port { get; set; }
        public string Url { get; set; } = string.Empty;
        public EMonitoringProvider Provider { get; set; }
    }
}
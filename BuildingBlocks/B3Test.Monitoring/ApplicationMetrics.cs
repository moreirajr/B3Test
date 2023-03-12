namespace B3Test.Monitoring.Abstractions
{
    public class ApplicationMetrics
    {
        public const string CPU_USAGE = "myapp_cpu_usage_percent";
        public const string MEMORY_USAGE = "myapp_memory_usage_bytes";
        public const string REQUEST_COUNT = "myapp_requests_total";
        public const string ERROR_COUNT = "myapp_errors_total";
    }
}
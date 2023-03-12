using Microsoft.AspNetCore.Builder;
using Prometheus;

namespace B3Test.Monitoring.Prometheus
{
    public static class PrometheusExtensions
    {
        public static void ConfigurePrometheus(this IApplicationBuilder app)
        {
            app.UseMetricServer();
            app.UseHttpMetrics();
        }
    }
}
using Azure.Monitor.OpenTelemetry.Exporter;
using Lab.Customers.Infra.Telemetry.Interfaces;
using OpenTelemetry.Metrics;
using OpenTelemetry.Resources;
using OpenTelemetry.Trace;

namespace Lab.Customers.Infra.Telemetry.Exporters;

public class ApplicationInsightsExporter(string instrumentationKey) : IApmExporter
{
    private readonly string _instrumentationKey =
        instrumentationKey ?? throw new ArgumentNullException(nameof(instrumentationKey));

    public TracerProviderBuilder AddExporter(TracerProviderBuilder builder)
    {
        return builder
            //.SetResourceBuilder(ResourceBuilder.CreateDefault().AddTelemetrySdk())
            .AddAzureMonitorTraceExporter(o => { o.ConnectionString = $"{_instrumentationKey}"; });
    }

    public MeterProviderBuilder AddExporter(MeterProviderBuilder builder)
    {
        return builder
            //.SetResourceBuilder(ResourceBuilder.CreateDefault().AddTelemetrySdk())
            .AddAzureMonitorMetricExporter(o => { o.ConnectionString = $"{_instrumentationKey}"; });
    }
}
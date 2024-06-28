using Azure.Monitor.OpenTelemetry.Exporter;
using Lab.Telemetry.Interfaces;
using OpenTelemetry.Exporter;
using OpenTelemetry.Metrics;
using OpenTelemetry.Trace;

namespace Lab.Telemetry.Exporters;

public class ApplicationInsightsExporter(Action<AzureMonitorExporterOptions> options) : IApmExporter
{
    public TracerProviderBuilder AddExporter(TracerProviderBuilder builder)
    {
        return builder
            .AddAzureMonitorTraceExporter(options);
    }

    public MeterProviderBuilder AddExporter(MeterProviderBuilder builder)
    {
        return builder
            .AddAzureMonitorMetricExporter(options);
    }
}
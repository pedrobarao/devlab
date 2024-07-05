using Lab.Telemetry.Interfaces;
using OpenTelemetry.Exporter;
using OpenTelemetry.Metrics;
using OpenTelemetry.Trace;

namespace Lab.Telemetry.Exporters;

public class OpenTelemetryCollectorExporter(Action<OtlpExporterOptions> options) : IApmExporter
{
    public TracerProviderBuilder AddExporter(TracerProviderBuilder builder)
    {
        return builder
            //.SetResourceBuilder(ResourceBuilder.CreateDefault().AddTelemetrySdk())
            .AddOtlpExporter(options);
    }

    public MeterProviderBuilder AddExporter(MeterProviderBuilder builder)
    {
        return builder
            //.SetResourceBuilder(ResourceBuilder.CreateDefault().AddTelemetrySdk())
            .AddOtlpExporter(options);
    }
}
using OpenTelemetry.Metrics;
using OpenTelemetry.Trace;

namespace Lab.Customers.Infra.Telemetry.Interfaces;

public interface IApmExporter
{
    TracerProviderBuilder AddExporter(TracerProviderBuilder builder);
    MeterProviderBuilder AddExporter(MeterProviderBuilder builder);
}
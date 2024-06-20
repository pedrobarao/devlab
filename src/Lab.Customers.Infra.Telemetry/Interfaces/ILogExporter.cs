using OpenTelemetry.Logs;

namespace Lab.Customers.Infra.Telemetry.Interfaces;

public interface ILogExporter
{
    OpenTelemetryLoggerOptions AddExporter(OpenTelemetryLoggerOptions options);
}
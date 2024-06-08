using OpenTelemetry.Logs;

namespace Lab.Customers.Telemetry.Interfaces;

public interface ILogExporter
{
    OpenTelemetryLoggerOptions AddExporter(OpenTelemetryLoggerOptions options);
}
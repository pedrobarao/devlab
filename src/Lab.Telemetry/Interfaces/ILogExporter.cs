using OpenTelemetry.Logs;

namespace Lab.Telemetry.Interfaces;

public interface ILogExporter
{
    OpenTelemetryLoggerOptions AddExporter(OpenTelemetryLoggerOptions options);
}
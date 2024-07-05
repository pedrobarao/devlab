using Lab.Telemetry.Interfaces;
using OpenTelemetry.Exporter;
using OpenTelemetry.Logs;

namespace Lab.Telemetry.Loggers;

public class OpenTelemetryCollectorLogger(Action<OtlpExporterOptions> options) : ILogExporter
{
    public OpenTelemetryLoggerOptions AddExporter(OpenTelemetryLoggerOptions loggerOptions)
    {
        return loggerOptions.AddOtlpExporter(options);
    }
}
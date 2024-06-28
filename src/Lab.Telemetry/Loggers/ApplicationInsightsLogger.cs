using Azure.Monitor.OpenTelemetry.Exporter;
using Lab.Telemetry.Interfaces;
using OpenTelemetry.Logs;

namespace Lab.Telemetry.Loggers;

public class ApplicationInsightsLogger(Action<AzureMonitorExporterOptions> options) : ILogExporter
{
    public OpenTelemetryLoggerOptions AddExporter(OpenTelemetryLoggerOptions loggerOptions)
    {
        return loggerOptions.AddAzureMonitorLogExporter(options);
    }
}
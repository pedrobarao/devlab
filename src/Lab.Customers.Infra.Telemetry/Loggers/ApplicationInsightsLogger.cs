using Azure.Monitor.OpenTelemetry.Exporter;
using Lab.Customers.Infra.Telemetry.Interfaces;
using OpenTelemetry.Logs;

namespace Lab.Customers.Infra.Telemetry.Loggers;

public class ApplicationInsightsLogger(string instrumentationKey) : ILogExporter
{
    private readonly string _instrumentationKey =
        instrumentationKey ?? throw new ArgumentNullException(nameof(instrumentationKey));

    public OpenTelemetryLoggerOptions AddExporter(OpenTelemetryLoggerOptions options)
    {
        return options.AddAzureMonitorLogExporter(o =>
            o.ConnectionString = $"InstrumentationKey={_instrumentationKey}");
    }
}
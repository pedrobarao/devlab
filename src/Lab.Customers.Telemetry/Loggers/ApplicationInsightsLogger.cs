using Lab.Customers.Telemetry.Interfaces;
using OpenTelemetry.Logs;

namespace Lab.Customers.Telemetry.Loggers;

public class ApplicationInsightsLogger(string instrumentationKey) : ILogExporter
{
    public OpenTelemetryLoggerOptions AddExporter(OpenTelemetryLoggerOptions options)
    {
        throw new NotImplementedException();
        //return options.AddApplicationInsights();
    }
}
using System;
using Azure.Monitor.OpenTelemetry.Exporter;
using Lab.Customers.Telemetry.Interfaces;
using OpenTelemetry.Logs;
using OpenTelemetry.Metrics;
using OpenTelemetry.Resources;
using OpenTelemetry.Trace;

namespace Lab.Customers.Telemetry.Exporters;

public class ApplicationInsightsExporter(string instrumentationKey) : IApmExporter
{
    private readonly string _instrumentationKey = instrumentationKey ?? throw new ArgumentNullException(nameof(instrumentationKey));

    public TracerProviderBuilder AddExporter(TracerProviderBuilder builder)
    {
        return builder
            .SetResourceBuilder(
                ResourceBuilder.CreateDefault()
                    .AddTelemetrySdk()
            )
            .AddAzureMonitorTraceExporter(o => o.ConnectionString = $"InstrumentationKey={_instrumentationKey}");
    }

    public MeterProviderBuilder AddExporter(MeterProviderBuilder builder)
    {
        return builder
            .AddAzureMonitorMetricExporter(o => o.ConnectionString = $"InstrumentationKey={_instrumentationKey}");
    }

    // public OpenTelemetryLoggerOptions AddExporter(OpenTelemetryLoggerOptions options)
    // {
    //     return options.AddApplicationInsights(_instrumentationKey);
    // }
}
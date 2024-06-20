using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using OpenTelemetry.Logs;
using OpenTelemetry.Metrics;
using OpenTelemetry.Resources;
using OpenTelemetry.Trace;

namespace Lab.Customers.Infra.Telemetry.Config;

public static class TelemetryConfig
{
    public static IHostApplicationBuilder AddTelemetry(this IHostApplicationBuilder builder,
        Action<TelemetryOptions> configureOptions)
    {
        var options = new TelemetryOptions();
        configureOptions(options);

        builder.Services.AddSingleton(options);

        builder.Logging.AddOpenTelemetry(otelLogging =>
        {
            otelLogging
                .SetResourceBuilder(ResourceBuilder.CreateDefault().AddService(options.ServiceName!))
                .AddConsoleExporter();

            foreach (var logExporter in options.LogExporters) otelLogging = logExporter.AddExporter(otelLogging);
        });

        builder.Services.AddOpenTelemetry()
            .ConfigureResource(resource => resource.AddService(options.ServiceName!))
            .WithTracing(tracing =>
            {
                tracing.AddAspNetCoreInstrumentation();
                tracing.AddConsoleExporter();
                foreach (var apmExporter in options.ApmExporters) tracing = apmExporter.AddExporter(tracing);
            })
            .WithMetrics(metrics =>
            {
                metrics.AddAspNetCoreInstrumentation();
                metrics.AddConsoleExporter();
                foreach (var apmExporter in options.ApmExporters) metrics = apmExporter.AddExporter(metrics);
            });

        return builder;
    }
}
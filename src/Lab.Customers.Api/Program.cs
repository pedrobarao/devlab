using Lab.Customers.Api.Config;
using Lab.Telemetry.Config;
using Lab.Telemetry.Exporters;
using Lab.Telemetry.Loggers;
using OpenTelemetry.Exporter;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddApiConfig(builder.Configuration);

builder.AddTelemetry(options =>
{
    options.AddLogExporter(new OpenTelemetryCollectorLogger(o =>
    {
        o.Endpoint = new Uri("");
        o.Protocol = OtlpExportProtocol.Grpc;
    }));

    options.AddApmExporter(new OpenTelemetryCollectorExporter(o =>
    {
        o.Endpoint = new Uri("");
        o.Protocol = OtlpExportProtocol.Grpc;
    }));
});

var app = builder.Build();

app.UseApiConfig();

app.Run();
using Lab.Customers.Api.Config;
using Lab.Customers.Api.Extensions;
using Lab.Telemetry.Config;
using Lab.Telemetry.Exporters;
using Lab.Telemetry.Loggers;
using OpenTelemetry.Exporter;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddApiConfig(builder.Configuration);

var appSettings = builder.Configuration.Get<AppSettings>();

builder.AddTelemetry(options =>
{
    options.ServiceName = appSettings?.ApplicationName;

    options.AddLogExporter(new OpenTelemetryCollectorLogger(o =>
    {
        o.Endpoint = new Uri(appSettings!.Telemetry!.OtlCollectorUrl!);
        o.Protocol = OtlpExportProtocol.Grpc;
    }));

    options.AddApmExporter(new OpenTelemetryCollectorExporter(o =>
    {
        o.Endpoint = new Uri(appSettings!.Telemetry!.OtlCollectorUrl!);
        o.Protocol = OtlpExportProtocol.Grpc;
    }));
});

var app = builder.Build();

app.UseApiConfig();

app.Run();

public abstract partial class Program
{
}
using Lab.Customers.Api.Config;
using Lab.Customers.Infra.Telemetry.Config;
using Lab.Customers.Infra.Telemetry.Exporters;
using Lab.Customers.Infra.Telemetry.Loggers;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddApiConfig(builder.Configuration);
builder.AddTelemetry(options =>
{
    //options.AddApmExporter(new ApplicationInsightsExporter(""));
});

var app = builder.Build();

app.UseApiConfig();

app.Run();
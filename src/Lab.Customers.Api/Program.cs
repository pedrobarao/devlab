using Lab.Customers.Api.Config;
using Lab.Customers.Infra.Telemetry.Config;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddApiConfig(builder.Configuration);
builder.AddTelemetry(options =>
{
    // options.AddApmExporter(new ApplicationInsightsExporter("4bdbbbdd-8a87-45a6-b8ec-8d06d3c72b4e"));
    // options.AddLogExporter(new ApplicationInsightsLogger("4bdbbbdd-8a87-45a6-b8ec-8d06d3c72b4e"));
});

var app = builder.Build();

app.UseApiConfig();

app.Run();
using Lab.Customers.Api.Config;
using Lab.Customers.Infra.Telemetry.Config;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddApiConfig(builder.Configuration);
builder.AddTelemetry(options =>
{
    //options.AddApmExporter(new ApplicationInsightsExporter(""));
});

var app = builder.Build();

app.UseApiConfig();

app.Run();
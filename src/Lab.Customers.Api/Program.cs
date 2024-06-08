#region

using Lab.Customers.Api.Config;
using Lab.Customers.Telemetry.Config;
using Lab.Customers.Telemetry.Exporters;
using Lab.Customers.Telemetry.Loggers;

#endregion

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddApiConfig(builder.Configuration);
builder.AddTelemetry(options =>
{
    //options.ServiceName = "NomeQualquer";
    // options.AddApmExporter(new ApplicationInsightsExporter(""));
    // options.AddLogExporter(new ApplicationInsightsLogger(""));
});
var app = builder.Build();

app.UseApiConfig();

app.Run();
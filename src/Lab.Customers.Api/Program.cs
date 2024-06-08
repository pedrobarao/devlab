#region

using Lab.Customers.Api.Config;
using Lab.Customers.Telemetry.Config;
using Lab.Customers.Telemetry.Exporters;

#endregion

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddApiConfig(builder.Configuration);
builder.AddTelemetry(options =>
{
    //options.ServiceName = "NomeQualquer";
    //options.AddApmExporter(new ApplicationInsightsExporter(""));
});
var app = builder.Build();

app.UseApiConfig();

app.Run();
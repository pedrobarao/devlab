#region

using Lab.Customers.Api.Config;

#endregion

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddApiConfig(builder.Configuration);

var app = builder.Build();

app.UseApiConfig();

app.Run();
using Snowdeed.PasswordManager.Application;
using Snowdeed.PasswordManager.Infrastructure;
using Snowdeed.PasswordManager.API.Endpoints;
using Snowdeed.PasswordManager.API.Extensions;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddApplication().AddInfrastructure(builder.Configuration);

var app = builder.Build();

app.ApplyMigrations();

app.MapAccountEndpoints();
app.MapIdentifierEndpoints();

app.Run();
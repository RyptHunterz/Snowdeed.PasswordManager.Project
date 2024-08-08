using Snowdeed.PasswordManager.Application;
using Snowdeed.PasswordManager.Infrastructure;
using Snowdeed.PasswordManager.API.Endpoints;
using Snowdeed.PasswordManager.API.Extensions;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddApplication().AddInfrastructure(builder.Configuration);

//builder.Services.AddScoped(x => new PasswordManagerDbContext(builder.Configuration.GetConnectionString("PasswordManagerConnection")));

var app = builder.Build();

//app.MapGet("/", async ([FromServices] PasswordManagerDbContext context) =>
//{
//    await context.CreateDatabaseAsync();
//    await context.CreateTableAsync();
//});

app.ApplyMigrations();

app.MapAccountEndpoints();
app.MapIdentifierEndpoints();

app.Run();
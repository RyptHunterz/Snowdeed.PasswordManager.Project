using Snowdeed.PasswordManager.Infrastructure;

namespace Snowdeed.PasswordManager.API.Extensions;

public static class MigrationExtensions
{
    public async static void ApplyMigrations(this WebApplication app)
    {
        using var scope = app.Services.CreateScope();

        var dbContext = scope.ServiceProvider.GetRequiredService<PasswordManagerDbContext>();

        await dbContext.CreateDatabaseAsync();
        await dbContext.CreateTableAsync();
    }
}
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Snowdeed.PasswordManager.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddScoped(x => new PasswordManagerDbContext(configuration.GetConnectionString("PasswordManagerConnection")));

        return services;
    }
}
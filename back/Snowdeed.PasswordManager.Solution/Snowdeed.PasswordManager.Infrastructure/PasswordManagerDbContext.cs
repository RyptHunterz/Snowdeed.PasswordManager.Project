using Snowdeed.FrameworkADO.Core;
using Snowdeed.PasswordManager.Domain.Entities;

namespace Snowdeed.PasswordManager.Infrastructure;

public class PasswordManagerDbContext(string? connectionString) : DbContext(connectionString)
{
    private DbSet<Account>? _Account;
    private DbSet<Identifier>? _Identifier;

    public DbSet<Account> Account => _Account ??= new DbSet<Account>(connection, databaseName);
    public DbSet<Identifier> Identifier => _Identifier ??= new DbSet<Identifier>(connection, databaseName);
}

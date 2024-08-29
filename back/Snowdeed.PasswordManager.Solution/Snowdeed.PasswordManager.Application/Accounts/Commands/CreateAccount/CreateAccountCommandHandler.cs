using MediatR;
using Snowdeed.PasswordManager.Domain.Entities;
using Snowdeed.PasswordManager.Infrastructure;

namespace Snowdeed.PasswordManager.Application.Accounts.Commands.CreateAccount;

public class CreateAccountCommandHandler(PasswordManagerDbContext dbContext) : IRequestHandler<CreateAccountCommand>
{
    private readonly PasswordManagerDbContext _dbContext = dbContext;

    public async Task Handle(CreateAccountCommand request, CancellationToken cancellationToken)
    {
        var account = new Account()
        {
            AccountEmail = request.AccountEmail,
            Salt = request.Salt,
            PasswordHash = request.PasswordHash,
            EmailContact = request.EmailContact
        };

        await _dbContext.Account.AddAsync(account, cancellationToken);
    }
}

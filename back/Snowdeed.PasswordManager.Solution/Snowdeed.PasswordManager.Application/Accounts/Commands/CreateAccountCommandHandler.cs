using MediatR;
using Snowdeed.PasswordManager.Domain.Entities;
using Snowdeed.PasswordManager.Infrastructure;

namespace Snowdeed.PasswordManager.Application.Accounts.Commands;

public class CreateAccountCommandHandler(PasswordManagerDbContext dbContext) : IRequestHandler<CreateAccountCommand>
{
    private readonly PasswordManagerDbContext _dbContext = dbContext;

    public async Task Handle(CreateAccountCommand request, CancellationToken cancellationToken)
    {
        var account = new Account()
        {
            AccountEmail = request.AccountEmail,
            PasswordHash = request.PasswordHash,
            EmailContact = request.EmailContact
        };

        await _dbContext.Account.AddAsync(account);
    }
}

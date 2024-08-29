using MediatR;
using Snowdeed.PasswordManager.Infrastructure;

namespace Snowdeed.PasswordManager.Application.Accounts.Queries.GetAccountByAccountEmail;

public class GetAccountByAccountEmailQueryHandler(PasswordManagerDbContext dbContext) : IRequestHandler<GetAccountByAccountEmailQuery, GetAccountByAccountEmailResponse?>
{
    private readonly PasswordManagerDbContext _dbContext = dbContext;

    public async Task<GetAccountByAccountEmailResponse?> Handle(GetAccountByAccountEmailQuery request, CancellationToken cancellationToken)
    {
        string AccountEmail = request.AccountEmail;
        return (await _dbContext.Account.FindAsync(x => x.AccountEmail == request.AccountEmail, cancellationToken))
            .Select(s => new GetAccountByAccountEmailResponse() { AccountGuid = s.AccountGuid, AccountEmail = s.AccountEmail, Salt = s.Salt })
            .FirstOrDefault();
    }
}
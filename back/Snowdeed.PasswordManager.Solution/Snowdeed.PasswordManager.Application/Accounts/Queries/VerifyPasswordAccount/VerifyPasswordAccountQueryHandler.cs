using MediatR;
using Snowdeed.PasswordManager.Infrastructure;

namespace Snowdeed.PasswordManager.Application.Accounts.Queries.VerifyPasswordAccount
{
    public class VerifyPasswordAccountQueryHandler(PasswordManagerDbContext dbContext) : IRequestHandler<VerifyPasswordAccountQuery, VerifyPasswordAccountResponse>
    {
        private readonly PasswordManagerDbContext _dbContext = dbContext;

        public async Task<VerifyPasswordAccountResponse> Handle(VerifyPasswordAccountQuery request, CancellationToken cancellationToken)
        {
            var userDb = (await _dbContext.Account.FindAsync(x => x.AccountEmail == request.AccountEmail, cancellationToken)).First();

            return new VerifyPasswordAccountResponse()
            {
                AccountEmail = request.AccountEmail,
                IsConnected = request.PasswordHash.SequenceEqual(userDb.PasswordHash)
            };
        }
    }
}

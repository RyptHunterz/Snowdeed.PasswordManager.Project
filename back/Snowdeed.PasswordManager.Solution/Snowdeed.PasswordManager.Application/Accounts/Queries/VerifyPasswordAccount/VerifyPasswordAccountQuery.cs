using MediatR;

namespace Snowdeed.PasswordManager.Application.Accounts.Queries.VerifyPasswordAccount;

public record VerifyPasswordAccountQuery(string AccountEmail, string PasswordHash) : IRequest<VerifyPasswordAccountResponse>
{
}

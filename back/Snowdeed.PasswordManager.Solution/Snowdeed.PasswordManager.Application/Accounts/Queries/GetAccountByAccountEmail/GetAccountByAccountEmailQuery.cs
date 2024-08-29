using MediatR;

namespace Snowdeed.PasswordManager.Application.Accounts.Queries.GetAccountByAccountEmail;

public record GetAccountByAccountEmailQuery(string AccountEmail) : IRequest<GetAccountByAccountEmailResponse>;
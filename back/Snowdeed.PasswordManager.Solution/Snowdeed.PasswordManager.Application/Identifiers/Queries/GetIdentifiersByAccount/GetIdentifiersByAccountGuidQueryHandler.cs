using MediatR;
using Snowdeed.PasswordManager.Infrastructure;

namespace Snowdeed.PasswordManager.Application.Identifiers.Queries.GetIdentifiersByAccount;

public class GetIdentifiersByAccountGuidQueryHandler(PasswordManagerDbContext dbContext) : IRequestHandler<GetIdentifiersByAccountGuidQuery, IEnumerable<IdentifierLiteResponse>>
{
    private readonly PasswordManagerDbContext _dbContext = dbContext;

    public async Task<IEnumerable<IdentifierLiteResponse>> Handle(GetIdentifiersByAccountGuidQuery request, CancellationToken cancellationToken)
    {
        return (await _dbContext.Identifier.GetAllAsync(cancellationToken))
            .Where(w => w.AccountGuid == request.AccountGuid)
            .Select(s => new IdentifierLiteResponse()
            {
                IdentifierGuid = s.IdentifierGuid,
                Name = s.Name,
                Login = s.Login
            }).ToList();
    }
}
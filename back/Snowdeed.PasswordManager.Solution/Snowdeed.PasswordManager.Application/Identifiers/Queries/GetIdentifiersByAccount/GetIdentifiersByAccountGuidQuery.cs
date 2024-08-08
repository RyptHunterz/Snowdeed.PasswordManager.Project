using MediatR;

namespace Snowdeed.PasswordManager.Application.Identifiers.Queries.GetIdentifiersByAccount;

public record GetIdentifiersByAccountGuidQuery(Guid AccountGuid) : IRequest<IEnumerable<IdentifierLiteResponse>>;

public class IdentifierLiteResponse()
{
    public Guid IdentifierGuid { get; set; }
    public required string Name { get; set; }
    public string? Login { get; set; }
}

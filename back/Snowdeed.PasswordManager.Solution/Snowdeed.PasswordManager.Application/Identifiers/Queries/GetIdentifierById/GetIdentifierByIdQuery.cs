using MediatR;

namespace Snowdeed.PasswordManager.Application.Identifiers.Queries.GetIdentifierById;

public record GetIdentifierByIdQuery(Guid Id) : IRequest<IdentifierResponse>;

public class IdentifierResponse()
{
    public Guid IdentifierGuid { get; set; }
    public required string Name { get; set; }
    public string? Login { get; set; }
    public string? PasswordCrypt { get; set; }
    public DateTime CreatedDate { get; set; }
    public DateTime UpdatedDate { get; set; }
    public DateTime PasswordUpdateDate { get; set; }
}

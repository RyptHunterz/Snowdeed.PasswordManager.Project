using MediatR;

namespace Snowdeed.PasswordManager.Application.Identifiers.Commands.CreateIdentifier;

public class CreateIdentifierCommand : IRequest
{
    public required string Name { get; set; }
    public string? Login { get; set; }
    public string? PasswordCrypt { get; set; }
    public required Guid AccountGuid { get; set; }
}
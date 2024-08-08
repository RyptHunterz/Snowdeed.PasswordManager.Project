namespace Snowdeed.PasswordManager.Domain.Exceptions.Identifier;

public sealed class IdentifierNotFoundException : Exception
{
    public IdentifierNotFoundException(Guid id)
        : base($"The identifier with the ID '{id}' was not found")
    { }
}

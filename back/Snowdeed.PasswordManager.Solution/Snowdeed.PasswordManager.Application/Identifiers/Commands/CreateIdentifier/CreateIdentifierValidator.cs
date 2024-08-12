using FluentValidation;

namespace Snowdeed.PasswordManager.Application.Identifiers.Commands.CreateIdentifier;

public class CreateIdentifierValidator : AbstractValidator<CreateIdentifierCommand>
{
    public CreateIdentifierValidator()
    {
        RuleFor(rf => rf.Name).NotNull().NotEmpty();
    }
}
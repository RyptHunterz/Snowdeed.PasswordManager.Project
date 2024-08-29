using FluentValidation;

namespace Snowdeed.PasswordManager.Application.Accounts.Commands.CreateAccount
{
    public class CreateAccountValidator : AbstractValidator<CreateAccountCommand>
    {
        public CreateAccountValidator() { }
    }
}

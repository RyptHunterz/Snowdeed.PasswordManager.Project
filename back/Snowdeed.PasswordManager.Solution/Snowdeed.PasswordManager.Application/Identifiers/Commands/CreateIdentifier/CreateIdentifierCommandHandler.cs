using MediatR;
using Snowdeed.PasswordManager.Application.Commons.Securities;
using Snowdeed.PasswordManager.Domain.Entities;
using Snowdeed.PasswordManager.Infrastructure;

namespace Snowdeed.PasswordManager.Application.Identifiers.Commands.CreateIdentifier;

public class CreateIdentifierCommandHandler(PasswordManagerDbContext dbContext) : IRequestHandler<CreateIdentifierCommand>
{
    private readonly PasswordManagerDbContext _dbContext = dbContext;

    public async Task Handle(CreateIdentifierCommand request, CancellationToken cancellationToken)
    {
        var identifier = new Identifier()
        {
            Name = request.Name,
            Login = request.Login,
            PasswordCrypt = request.PasswordCrypt,
            AccountGuid = request.AccountGuid,
            CreatedDate = DateTime.UtcNow
        };

        await _dbContext.Identifier.AddAsync(identifier);
    }
}
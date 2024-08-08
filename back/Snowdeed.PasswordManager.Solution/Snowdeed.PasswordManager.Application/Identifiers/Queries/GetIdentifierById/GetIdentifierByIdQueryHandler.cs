using MediatR;
using Snowdeed.PasswordManager.Application.Commons.Securities;
using Snowdeed.PasswordManager.Domain.Exceptions.Identifier;
using Snowdeed.PasswordManager.Infrastructure;

namespace Snowdeed.PasswordManager.Application.Identifiers.Queries.GetIdentifierById
{
    public class GetIdentifierByIdQueryHandler(PasswordManagerDbContext dbContext) : IRequestHandler<GetIdentifierByIdQuery, IdentifierResponse>
    {
        private readonly PasswordManagerDbContext _dbContext = dbContext;

        public async Task<IdentifierResponse> Handle(GetIdentifierByIdQuery request, CancellationToken cancellationToken)
        {
            var identifier = await _dbContext.Identifier.GetAsync(request.Id);

            if (identifier is null)
                throw new IdentifierNotFoundException(request.Id);

            return new IdentifierResponse
            {
                IdentifierGuid = identifier.IdentifierGuid,
                Name = identifier.Name,
                Login = identifier.Login,
                PasswordCrypt = identifier.PasswordCrypt,
                CreatedDate = identifier.CreatedDate,
                UpdatedDate = identifier.UpdatedDate,
                PasswordUpdateDate = identifier.PasswordUpdateDate
            };
        }
    }
}

using MediatR;

namespace Snowdeed.PasswordManager.Application.Identifiers.Queries.GetIdentifierById;

public record GetIdentifierByIdQuery(Guid Id) : IRequest<GetIdentifierByIdResponse>;
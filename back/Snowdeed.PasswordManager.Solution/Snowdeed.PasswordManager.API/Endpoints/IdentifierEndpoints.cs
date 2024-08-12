using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Snowdeed.PasswordManager.Application.Identifiers.Commands.CreateIdentifier;
using Snowdeed.PasswordManager.Application.Identifiers.Queries.GetIdentifierById;
using Snowdeed.PasswordManager.Application.Identifiers.Queries.GetIdentifiersByAccount;
using Snowdeed.PasswordManager.Domain.Exceptions.Identifier;

namespace Snowdeed.PasswordManager.API.Endpoints;

public static class IdentifierEndpoints
{
    public static void MapIdentifierEndpoints(this IEndpointRouteBuilder app)
    {
        app.MapGet("identifiers/{AccountGuid}", async ([FromRoute] Guid AccountGuid, ISender sender, CancellationToken cancellationToken) =>
        {
            return Results.Ok(await sender.Send(new GetIdentifiersByAccountGuidQuery(AccountGuid), cancellationToken));
        });

        app.MapGet("identifier/{IdentifierGuid}", async ([FromRoute] Guid IdentifierGuid, ISender sender, CancellationToken cancellationToken) =>
        {
            try
            {
                return Results.Ok(await sender.Send(new GetIdentifierByIdQuery(IdentifierGuid), cancellationToken));
            }
            catch (IdentifierNotFoundException ex)
            {
                return Results.NotFound(ex.Message);
            }
        });

        app.MapPost("identifiers/", async (CreateIdentifierCommand command, ISender sender, IValidator<CreateIdentifierCommand> validator, CancellationToken cancellationToken) =>
        {
            var result = await validator.ValidateAsync(command, cancellationToken);

            if(!result.IsValid)
            {
                return Results.BadRequest(result.ToDictionary());
            }

            await sender.Send(command, cancellationToken);
            return Results.Ok();
        });
    }
}
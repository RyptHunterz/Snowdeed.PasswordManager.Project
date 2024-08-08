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
        app.MapGet("identifiers/{AccountGuid}", async ([FromRoute] Guid AccountGuid, ISender sender) =>
        {
            return Results.Ok(await sender.Send(new GetIdentifiersByAccountGuidQuery(AccountGuid)));
        });

        app.MapGet("identifier/{IdentifierGuid}", async ([FromRoute] Guid IdentifierGuid, ISender sender) =>
        {
            try
            {
                return Results.Ok(await sender.Send(new GetIdentifierByIdQuery(IdentifierGuid)));
            }
            catch (IdentifierNotFoundException ex)
            {
                return Results.NotFound();
            }
        });

        app.MapPost("identifiers/", async (CreateIdentifierCommand command, ISender sender, IValidator<CreateIdentifierCommand> validator, CancellationToken cancellationToken) =>
        {
            var result = await validator.ValidateAsync(command);

            if(!result.IsValid)
            {
                return Results.BadRequest(result.ToDictionary());
            }

            await sender.Send(command);
            return Results.Ok();
        });
    }
}

public class IdentifierValidator : AbstractValidator<CreateIdentifierCommand>
{
    public IdentifierValidator()
    {
        RuleFor(rf => rf.Name).NotNull().NotEmpty();
    }
}
using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Snowdeed.PasswordManager.Application.Accounts.Commands.CreateAccount;
using Snowdeed.PasswordManager.Application.Accounts.Queries.GetAccountByAccountEmail;
using Snowdeed.PasswordManager.Application.Accounts.Queries.VerifyPasswordAccount;

namespace Snowdeed.PasswordManager.API.Endpoints;

public static class AccountEndpoints
{
    public static void MapAccountEndpoints(this IEndpointRouteBuilder app)
    {
        app.MapPost("account/", async (CreateAccountCommand command, ISender sender, IValidator<CreateAccountCommand> validator, CancellationToken cancellationToken) =>
        {
            var result = await validator.ValidateAsync(command, cancellationToken);

            if (!result.IsValid)
            {
                return Results.BadRequest(result.ToDictionary());
            }

            await sender.Send(command, cancellationToken);
            return Results.Ok();
        });

        app.MapGet("/account/{AccountEmail}/{PasswordHash}", async ([FromRoute] string AccountEmail, [FromRoute] string PasswordHash, ISender sender, CancellationToken cancellationToken) =>
        {
            return Results.Ok(await sender.Send(new VerifyPasswordAccountQuery(AccountEmail, PasswordHash), cancellationToken));
        });

        app.MapGet("/account/{AccountEmail}", async ([FromRoute] string AccountEmail, ISender sender, CancellationToken cancellationToken) =>
        {
            var item = await sender.Send(new GetAccountByAccountEmailQuery(AccountEmail), cancellationToken);
            return item is not null ? Results.Ok(item) : Results.NotFound();
        });
    }
}
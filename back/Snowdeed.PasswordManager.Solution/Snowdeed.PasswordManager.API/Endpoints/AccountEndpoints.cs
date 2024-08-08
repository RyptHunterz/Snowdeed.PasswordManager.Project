using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Snowdeed.PasswordManager.API.Endpoints;

public static class AccountEndpoints
{
    public static void MapAccountEndpoints(this IEndpointRouteBuilder app)
    {
        //app.MapPost("/account/", async ([FromBody] AccountDto account, ISender sender, CancellationToken cancellationToken) =>
        //{
        //    var command = new Create

        //    //return (await context.Account.GetAllAsync()).Any(w => w.AccountEmail == account.AccountEmail && w.PasswordHash == account.PasswordHash);
        //});

        app.MapGet("/accounts/{AccountGuid}", async ([FromBody] Guid AccountGuid, ISender sender, CancellationToken cancellationToken) =>
        {

            //return (await context.Account.GetAllAsync()).Where(w => w.AccountEmail == account.AccountEmail).FirstOrDefault();
        });
    }
}
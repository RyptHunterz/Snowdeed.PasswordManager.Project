namespace Snowdeed.PasswordManager.Application.Accounts.Queries.GetAccountByAccountEmail;

public class GetAccountByAccountEmailResponse
{
    public Guid AccountGuid { get; set; }
    public required string AccountEmail { get; set; }
    public required string Salt { get; set; }
}
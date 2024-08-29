namespace Snowdeed.PasswordManager.Application.Accounts.Queries.VerifyPasswordAccount;

public class VerifyPasswordAccountResponse
{
    public required string AccountEmail { get; set; }
    public required bool IsConnected { get; set; }
}
namespace Snowdeed.PasswordManager.Tests.Dtos;
public class AccountDto
{
    public required string AccountEmail { get; set; }
    public required string PasswordHash { get; set; }
}

namespace Snowdeed.PasswordManager.Tests.Models;

public class CreateAccountModel
{
    public required string AccountEmail { get; set; }
    public string? Salt { get; set; }
    public required string Password { get; set; }
    public string? PasswordHash { get; set; }
    public required string EmailContact { get; set; }
}
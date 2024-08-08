using Snowdeed.FrameworkADO.Core.Attributes;

namespace Snowdeed.PasswordManager.Domain.Entities;

public class Account
{
    [Identity]
    public int AccountId { get; protected set; }
    [PrimaryKey]
    public Guid AccountGuid { get; set; }
    public required string AccountEmail { get; set; }
    public required string PasswordHash { get; set; }
    public required string EmailContact { get; set; }

}
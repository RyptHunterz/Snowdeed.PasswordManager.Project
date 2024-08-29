using Snowdeed.FrameworkADO.Core.Attributes;

namespace Snowdeed.PasswordManager.Domain.Entities;

public class Account
{
    [Identity]
    public int AccountId { get; protected set; }
    [PrimaryKey]
    public Guid AccountGuid { get; set; }
    [MaxLenght(50)]
    public required string AccountEmail { get; set; }
    [MaxLenght(32)]
    public required string Salt { get; set; }
    [MaxLenght(64)]
    public required string PasswordHash { get; set; }
    [MaxLenght(50)]
    public required string EmailContact { get; set; }
}
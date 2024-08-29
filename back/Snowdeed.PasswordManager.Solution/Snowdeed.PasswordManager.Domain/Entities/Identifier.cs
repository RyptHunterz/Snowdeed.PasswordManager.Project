using Snowdeed.FrameworkADO.Core.Attributes;

namespace Snowdeed.PasswordManager.Domain.Entities;

public class Identifier
{
    [Identity]
    public int IdentifierId { get; protected set; }
    [PrimaryKey]
    public Guid IdentifierGuid { get; set; }
    [MaxLenght(50)]
    public required string Name { get; set; }
    [MaxLenght(50)]
    public string? Login { get; set; }
    [MaxLenght(50)]
    public string? PasswordCrypt { get; set; }
    public DateTime CreatedDate { get; set; }
    public DateTime UpdatedDate { get; set; }
    public DateTime PasswordUpdateDate { get; set; }

    [ForeignKey(nameof(Account), nameof(Account.AccountGuid))]
    public Guid AccountGuid { get; set; }
}
using System.Text.Json.Serialization;

namespace Snowdeed.PasswordManager.Tests.Models;

public class AccountModel
{
    [JsonPropertyName("accountGuid")]
    public Guid AccountGuid { get; set; }
    [JsonPropertyName("accountEmail")]
    public string? AccountEmail { get; set; }
    [JsonPropertyName("salt")]
    public string? Salt { get; set; }
}

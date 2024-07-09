using System.Text.Json.Serialization;

namespace DiscordSharperActivities.Models;

public class DiscordUser
{
    [JsonRequired]
    public readonly string username = default!;

    [JsonRequired]
    public readonly string id = default!;

    [JsonRequired]
    public readonly string discriminator = default!;

    [JsonPropertyName("avatar")]
    public readonly string? avatarID;
}
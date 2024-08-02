using System.Text.Json.Serialization;

namespace DiscordSharperActivities.Models;

public class DiscordUser
{
    internal DiscordUser(string username, string id, string discriminator, string? avatarID)
    {
        this.username = username;
        this.id = id;
        this.discriminator = discriminator;
        this.avatarID = avatarID;
    }
    
    [JsonRequired]
    public readonly string username = default!;

    [JsonRequired]
    public readonly string id = default!;

    [JsonRequired]
    public readonly string discriminator = default!;

    [JsonPropertyName("avatar")]
    public readonly string? avatarID;   
}
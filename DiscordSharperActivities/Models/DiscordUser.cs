using System.Text.Json.Serialization;

namespace DiscordSharperActivities.Models;


public class DiscordUser
{
    [JsonConstructor]
    internal DiscordUser(string username, string id, string discriminator, string? avatarID)
    {
        this.username = username ?? throw new ArgumentNullException(nameof(username));
        this.id = id ?? throw new ArgumentNullException(nameof(id));
        this.discriminator = discriminator ?? throw new ArgumentNullException(nameof(discriminator));
        this.avatarID = avatarID;
    }
    
    [JsonPropertyName("username")]
    [JsonInclude]
    public readonly string username = default!;

    [JsonPropertyName("id")]
    [JsonInclude]
    public readonly string id = default!;

    [JsonPropertyName("discriminator")]
    [JsonInclude]
    
    public readonly string discriminator = default!;

    [JsonPropertyName("avatar")]
    [JsonInclude]
    public readonly string? avatarID;   
}
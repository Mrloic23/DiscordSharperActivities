using System.Text.Json.Serialization;

namespace DiscordSharperActivities.Models;


public class UserVoiceState
{
    [JsonRequired]
    public readonly bool mute;

    [JsonPropertyName("nick")]
    [JsonRequired]
    public readonly string nickname = default!;

    [JsonRequired]
    public readonly DiscordUser user = default!;
    
}
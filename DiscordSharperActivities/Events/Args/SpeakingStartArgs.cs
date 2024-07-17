using System.Text.Json.Serialization;

namespace DiscordSharperActivities.Events.Args;

public class SpeakingStartArgs
{
    [JsonRequired]
    [JsonPropertyName("user_id")]
    public readonly string userID = default!;

    [JsonRequired]
    [JsonPropertyName("channel_id")]
    public readonly string channelID = default!;

    [JsonRequired]
    [JsonPropertyName("lobby_id")]
    public readonly string lobbyID = default!;
}

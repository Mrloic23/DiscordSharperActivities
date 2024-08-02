using System.Text.Json.Serialization;

namespace DiscordSharperActivities.Events.Args;

public class SpeakingStopArgs(string userID, string channelID, string lobbyID)
{
    [JsonRequired]
    [JsonPropertyName("user_id")]
    public readonly string userID = userID;

    [JsonRequired]
    [JsonPropertyName("channel_id")]
    public readonly string channelID = channelID;

    [JsonRequired]
    [JsonPropertyName("lobby_id")]
    public readonly string lobbyID = lobbyID;
}

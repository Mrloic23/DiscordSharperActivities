using System.Text.Json.Serialization;

namespace DiscordSharperActivities.Events.Args;

public class SpeakingStartArgs(string userID, string channelID, string lobbyID)
{
    [JsonRequired]
    [JsonPropertyName("user_id")]
    public required string UserID { init; get; } = userID;

    [JsonRequired]
    [JsonPropertyName("channel_id")]
    public required string ChannelID { init; get; } = channelID;

    [JsonRequired]
    [JsonPropertyName("lobby_id")]
    public required string LobbyID { init; get; } = lobbyID;
}

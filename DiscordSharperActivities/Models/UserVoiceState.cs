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
    [JsonRequired]
    public readonly VoiceState voiceState = default!;

    public class VoiceState
    {
        [JsonRequired]
        public bool mute;
        [JsonRequired]
        public bool deaf;
        [JsonPropertyName("self_mute")]
        [JsonRequired]
        public bool selfMute;

        [JsonPropertyName("self_deaf")]
        [JsonRequired]
        public bool selfDeaf;

        [JsonRequired]
        public bool suppress;

    }
}
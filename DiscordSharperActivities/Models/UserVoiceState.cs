using System.Text.Json.Serialization;

namespace DiscordSharperActivities.Models;


public class UserVoiceState
{
    internal UserVoiceState(bool mute, string nickname, DiscordUser user, VoiceState voiceState)
    {
        this.mute = mute;
        this.nickname = nickname;
        this.user = user;
        this.voiceState = voiceState;
    }
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

        internal VoiceState(bool mute, bool deaf, bool selfMute, bool selfDeaf, bool suppress)
        {
            this.mute = mute;
            this.deaf = deaf;
            this.selfMute = selfMute;
            this.selfDeaf = selfDeaf;
            this.suppress = suppress;
        }
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
using DiscordSharperActivities.Models;

namespace DiscordSharperActivities.Testing;
/// <summary>
/// Factory for creating models from DiscordSharperActivities.Models, for customization see <see cref="ModelFactory.Mode"/>
/// </summary>
public class ModelFactory
{
    public Modes Mode { get; set; } = Modes.Random;
    public DiscordUser CreateDiscordUser(string? username, string? id, string? discriminator, string? avatarID = null)
    {
        if (Mode == Modes.Default)
        {
            username ??= "default";
            id ??= "default";
            discriminator ??= "default";
        }
        if (Mode == Modes.Random)
        {
            // not realistic because it's guid but good enough
            username ??= Guid.NewGuid().ToString();
            id ??= Guid.NewGuid().ToString();
            discriminator ??= Guid.NewGuid().ToString();
        }

        // at this point Mode is Modes.Custom
        if (username is null) throw new ArgumentNullException(nameof(username), "username is required in custom mode");
        if (id is null) throw new ArgumentNullException(nameof(id), "id is required in custom mode");
        if (discriminator is null) throw new ArgumentNullException(nameof(discriminator), "discriminator is required in custom mode");

        return new DiscordUser(username, id, discriminator, avatarID);
    }

    public UserVoiceState.VoiceState CreateVoiceState(bool? mute, bool? deaf, bool? selfMute = null, bool? selfDeaf = null)
    {
        if (Mode == Modes.Default)
        {
            mute ??= false;
            deaf ??= false;
            selfMute ??= false;
            selfDeaf ??= false;
        }
        if (Mode == Modes.Random)
        {
            mute ??= new Random().Next(0, 2) == 1;
            deaf ??= new Random().Next(0, 2) == 1;
            selfMute ??= mute.Value && new Random().Next(0, 2) == 1;
            selfDeaf ??= deaf.Value && new Random().Next(0, 2) == 1;
        }
        if(mute is null) throw new ArgumentNullException(nameof(mute), "mute is required in custom mode");
        if(deaf is null) throw new ArgumentNullException(nameof(deaf), "deaf is required in custom mode");
        if(selfDeaf is null) throw new ArgumentNullException(nameof(selfDeaf), "selfDeafen is required in custom mode");
        if(selfMute is null) throw new ArgumentNullException(nameof(selfMute), "selfMute is required in custom mode");

        // at this point Mode is Modes.Custom
        return new UserVoiceState.VoiceState(mute.Value, deaf.Value, selfMute.Value, selfDeaf.Value, false);
    }
    public UserVoiceState CreateUserVoiceState(bool? mute, string? nickname, DiscordUser? user, UserVoiceState.VoiceState? voiceState)
    {
        if (Mode == Modes.Default)
        {
            mute ??= false;
            nickname ??= "default";
            user ??= CreateDiscordUser(nickname, null, null);
            voiceState ??= CreateVoiceState(mute, false);
        }
        if (Mode == Modes.Random)
        {
            mute ??= new Random().Next(0, 2) == 1;
            nickname ??= Guid.NewGuid().ToString();
            user ??= CreateDiscordUser(nickname, null, null);
            voiceState ??= CreateVoiceState(mute, false);
        }

        // at this point Mode is Modes.Custom
        if (mute is null) throw new ArgumentNullException(nameof(mute), "mute is required in custom mode");
        if (nickname is null) throw new ArgumentNullException(nameof(nickname), "nickname is required in custom mode");
        if (user is null) throw new ArgumentNullException(nameof(user), "user is required in custom mode");
        if (voiceState is null) throw new ArgumentNullException(nameof(voiceState), "voiceState is required in custom mode");

        return new UserVoiceState(mute.Value, nickname, user, voiceState);
    }

    /// <summary>
    /// running mode of the factory
    /// </summary>
    public enum Modes
    {
        /// <summary>
        /// all unprecised parameters will be random
        /// </summary>
        Random,
        /// <summary>
        /// all unprecised parameters will use a default value (provided by the library)
        /// </summary>
        Default,
        /// <summary>
        /// all parameters MUST be provided by the user except for the ones that are marked as optional
        /// </summary>
        Custom
    }
}
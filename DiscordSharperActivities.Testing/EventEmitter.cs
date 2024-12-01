using System.Runtime.Versioning;
using System.Text.Json;
using DiscordSharperActivities.Events;
using DiscordSharperActivities.Events.Args;
using DiscordSharperActivities.Models;

namespace DiscordSharperActivities.Testing;

[SupportedOSPlatform("browser")]
public class EventEmitter(DiscordSDKMock mock)
{
    internal DiscordSDKMock mock = mock;
    private static JsonSerializerOptions jsonSerializerOptions => new() { IncludeFields = true };
    public EventEmitter Ready()
    {
        JSBindings.EmitReady(mock._sdk);
        return this;
    }

    public EventEmitter VoiceStateUpdate(UserVoiceState state)
    {
        JSBindings.EmitEvent(mock._sdk, EventType.VoiceStateUpdate.GetJSName(), JsonSerializer.Serialize(state, jsonSerializerOptions));
        return this;
    }

    public EventEmitter SpeakingStart(SpeakingStartArgs args)
    {
        JSBindings.EmitEvent(mock._sdk, EventType.VoiceStateUpdate.GetJSName(), JsonSerializer.Serialize(args, jsonSerializerOptions));
        return this;
    }
    public EventEmitter SpeakingStop(SpeakingStopArgs args)
    {
        JSBindings.EmitEvent(mock._sdk, EventType.SpeakingStop.GetJSName(), JsonSerializer.Serialize(args, jsonSerializerOptions));
        return this;
    }

    public EventEmitter LayoutModeChanged(LayoutModeChangedArgs args)
    {
        JSBindings.EmitEvent(mock._sdk, EventType.LayoutModeUpdate.GetJSName(), JsonSerializer.Serialize(args, jsonSerializerOptions));
        return this;
    }

    public EventEmitter OrientationChanged(ScreenOrientationchangedArgs args)
    {
        JSBindings.EmitEvent(mock._sdk, EventType.OrientationUpdate.GetJSName(), JsonSerializer.Serialize(args, jsonSerializerOptions));
        return this;
    }

    public EventEmitter CurrentUserUpdated(DiscordUser user)
    {
        JSBindings.EmitEvent(mock._sdk, EventType.CurrentUserUpdate.GetJSName(), JsonSerializer.Serialize(user, jsonSerializerOptions));
        return this;
    }

    public EventEmitter EntitlementCreated(CreateEntitlementArgs args)
    {
        JSBindings.EmitEvent(mock._sdk, EventType.EntitlementCreate.GetJSName(), JsonSerializer.Serialize(args, jsonSerializerOptions));
        return this;
    }

}
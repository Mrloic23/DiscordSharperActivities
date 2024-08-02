using System.Runtime.Versioning;
using System.Text.Json;
using DiscordSharperActivities.Events;
using DiscordSharperActivities.Events.Args;
using DiscordSharperActivities.Models;

namespace DiscordSharperActivities.Testing;

[SupportedOSPlatform("browser")]
public class EventEmitter
{
    public EventEmitter Ready()
    {
        JSBindings.EmitReady(DiscordSDKMock.Instance._sdk);
        return this;
    }

    public EventEmitter VoiceStateUpdate(UserVoiceState state)
    {
        JSBindings.EmitEvent(EventType.VoiceStateUpdate.GetJSName(), JsonSerializer.Serialize(state));
        return this;
    }

    public EventEmitter SpeakingStart(SpeakingStartArgs args)
    {
        JSBindings.EmitEvent(EventType.VoiceStateUpdate.GetJSName(), JsonSerializer.Serialize(args));
        return this;
    }
    public EventEmitter SpeakingStop(SpeakingStopArgs args)
    {
        JSBindings.EmitEvent(EventType.SpeakingStop.GetJSName(), JsonSerializer.Serialize(args));
        return this;
    }

    public EventEmitter LayoutModeChanged(LayoutModeChangedArgs args)
    {
        JSBindings.EmitEvent(EventType.LayoutModeUpdate.GetJSName(), JsonSerializer.Serialize(args));
        return this;
    }

    public EventEmitter OrientationChanged(ScreenOrientationchangedArgs args)
    {
        JSBindings.EmitEvent(EventType.OrientationUpdate.GetJSName(), JsonSerializer.Serialize(args));
        return this;
    }



}
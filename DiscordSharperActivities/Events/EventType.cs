namespace DiscordSharperActivities.Events;
internal enum EventType
{
    Ready,
    VoiceStateUpdate,
    SpeakingStart,
    SpeakingStop,
    OrientationUpdate,
    EntitlementCreate,
    CurrentUserUpdate,
    ThermalStateUpdate,
    ActivityInstanceParticipantsUpdate
}

internal static class EventTypeExt
{
    internal static string GetJSName(this EventType @event)
    {
        return @event switch
        {
            EventType.Ready => "READY",
            EventType.VoiceStateUpdate => "VOICE_STATE_UPDATE",
            EventType.SpeakingStart => "SPEAKING_START",
            EventType.SpeakingStop => "SPEAKING_STOP",
            EventType.OrientationUpdate => "ORIENTATION_UPDATE",
            EventType.EntitlementCreate => "ENTITLEMENT_CREATE",
            EventType.ThermalStateUpdate => "THERMAL_STATE_UPDATE",
            EventType.ActivityInstanceParticipantsUpdate => "ACTIVITY_INSTANCE_PARTICIPANTS_UPDATE",
            _ => throw new ArgumentOutOfRangeException(nameof(@event), @event, null),
        };
    }
}
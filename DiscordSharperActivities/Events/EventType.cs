namespace DiscordSharperActivities.Events;
internal enum EventType
{
    READY,
    VOICE_STATE_UPDATE,
    SPEAKING_START,
    ORIENTATION_UPDATE,
    ENTITLEMENT_CREATE,
    THERMAL_STATE_UPDATE,
    ACTIVITY_INSTANCE_PARTICIPANTS_UPDATE
}

internal static class EventTypeExt
{
    internal static string GetJSName(this EventType @event)
    {
        return @event switch
        {
            EventType.READY => "READY",
            EventType.VOICE_STATE_UPDATE => "VOICE_STATE_UPDATE",
            EventType.SPEAKING_START => "SPEAKING_START",
            EventType.ORIENTATION_UPDATE => "ORIENTATION_UPDATE",
            EventType.ENTITLEMENT_CREATE => "ENTITLEMENT_CREATE",
            EventType.THERMAL_STATE_UPDATE => "THERMAL_STATE_UPDATE",
            EventType.ACTIVITY_INSTANCE_PARTICIPANTS_UPDATE => "ACTIVITY_INSTANCE_PARTICIPANTS_UPDATE",
            _ => throw new ArgumentOutOfRangeException(nameof(@event), @event, null),
        };
    }
}
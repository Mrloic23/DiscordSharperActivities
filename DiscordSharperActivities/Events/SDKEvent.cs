using System.ComponentModel;
using System.Runtime.Versioning;
using System.Text.Json;

namespace DiscordSharperActivities.Events;
[SupportedOSPlatform("browser")]
internal class SDKEvent<T>
{
    private readonly object _lock = new();
    internal EventType EventType { get; }
    EventHandler<T>? _handlers;
    internal SDKEvent(EventType eventType)
    {
        EventType = eventType;
    }

    internal EventHandler<T> Add(EventHandler<T> handler)
    {
        lock (_lock)
        {
            if (_handlers is null)
            {
                _ = JSBindings.SubscribeToEvent(EventType.GetJSName(), (jsObject) =>
                    _handlers!.Invoke(
                        this,
                        JsonSerializer.Deserialize<T>(jsObject.ToString()!)!
                ));
            }
            return _handlers += handler;
        }
    }
    internal void Remove(EventHandler<T> handler)
    {
        lock (_lock)
            _handlers -= handler;
    }
}
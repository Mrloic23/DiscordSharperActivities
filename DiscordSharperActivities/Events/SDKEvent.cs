using System.ComponentModel;
using System.Runtime.Versioning;
using System.Text.Json;

namespace DiscordSharperActivities.Events;
[SupportedOSPlatform("browser")]
internal class SDKEvent<T>
{
    private static readonly JsonSerializerOptions jsonSerializerOptions = new() { IncludeFields = true };
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
                _ = JSBindings.SubscribeToEvent(DiscordSDK.Instance._sdk, EventType.GetJSName(), (jsObject) =>
                {
                    _handlers!.Invoke(
                        DiscordSDK.Instance,
                        JsonSerializer.Deserialize<T>(JSBindings.Stringify(jsObject), jsonSerializerOptions)!);
                });
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
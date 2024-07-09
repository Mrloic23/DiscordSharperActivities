using System.Diagnostics.CodeAnalysis;
using System.Runtime.InteropServices.JavaScript;
using System.Runtime.Versioning;
using System.Text.Json;
using DiscordSharperActivities.Events;
using DiscordSharperActivities.Events.Args;
using DiscordSharperActivities.Models;

namespace DiscordSharperActivities;

[SupportedOSPlatform("Browser")]
public class DiscordSDK
{
    private EventHandler<ReadyEventArgs>? _ready;
    private readonly object _lock = new();

    private static DiscordSDK? _instance;
    private readonly JSObject _sdk;

    public string ClientID { get => _sdk.GetPropertyAsString("clientID")!; }
    public string InstanceID { get => _sdk.GetPropertyAsString("instanceID")!; }

    private DiscordSDK(string urlBase, string clientID, SDKConfig? config = null)
    {
        JSBindings.Import(urlBase);
        _sdk = JSBindings.InstantiateSDK(clientID, config?._ref);
    }

    /**
     * Get the instance of the Discord SDK, clientID can be null if there is already an instance
     * @param clientID The client ID of the Discord application
     * @returns The instance of the Discord SDK
     */
    public static DiscordSDK GetInstance(string? clientID = null, string? urlBase = null, SDKConfig? config = null)
    {
        if (_instance != null)
            return _instance;
        if (clientID == null)
            throw new ArgumentNullException(nameof(clientID), "clientID and urlBase cannot be null when instantiating");
        if (urlBase == null)
            throw new ArgumentNullException(nameof(urlBase), "clientID and urlBase cannot be null when instantiating");
        _instance ??= new DiscordSDK(urlBase!, clientID!, config);
        return _instance;
    }

    public event EventHandler<ReadyEventArgs> OnReady
    {
        add
        {
            lock (_lock)
            {
                if (_ready == null)
                {
                    JSBindings.SubscribeToEvent(EventType.READY.GetJSName(), (jsObject) =>
                        _ready!.Invoke(
                            this,
                            JsonSerializer.Deserialize<ReadyEventArgs>(jsObject.ToString()!)!
                    ));
                }
                _ready += value;
            }
        }
        remove
        {
            lock (_lock)
            {
                _ready -= value;
            }
        }
    }
}
using System.Collections;
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
    private readonly SDKEvent<ReadyEventArgs> _ready = new(EventType.Ready);
    private readonly SDKEvent<UserVoiceState> _voiceStateUpdate = new(EventType.VoiceStateUpdate);
    private readonly SDKEvent<SpeakingStartArgs> _speakingStart = new(EventType.SpeakingStart);
    private readonly SDKEvent<SpeakingStopArgs> _speakingStop = new(EventType.SpeakingStop);
    private readonly SDKEvent<LayoutModeChangedArgs> _layoutModeChanged = new(EventType.OrientationUpdate);

    private readonly SDKEvent<ThermalState> _thermalStateChanged = new(EventType.ThermalStateUpdate);
    private static DiscordSDK? _instance;
    private readonly JSObject _sdk;

    public string ClientID { get => _sdk.GetPropertyAsString("clientID")!; }
    public string InstanceID { get => _sdk.GetPropertyAsString("instanceID")!; }

    private DiscordSDK(string urlBase, string clientID, SDKConfig? config = null)
    {
        JSBindings.Import(urlBase);
        _sdk = JSBindings.InstantiateSDK(clientID, config?._ref);
    }

    /// <summary>
    /// Get the instance of the Discord SDK, clientID can be null if there is already an instance
    /// </summary>
    /// <param name="clientID">The client ID of the Discord application</param>
    /// <returns>The instance of the Discord SDK</returns>

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

    /// <summary>
    /// Creates a Task that is resolved when the SDK is ready
    /// </summary>
    /// <returns></returns>
    public async Task Ready()
    {
        await JSBindings.Ready(_sdk);
    }

    /// <summary>
    /// Event fired when the SDK is ready (for a call/task based event <see cref="Ready"/>)
    /// </summary>
    public event EventHandler<ReadyEventArgs> OnReady
    {
        add { _ready.Add(value); }
        remove { _ready.Remove(value); }
    }
    public event EventHandler<UserVoiceState> OnVoiceStateUpdate
    {
        add { _voiceStateUpdate.Add(value); }
        remove { _voiceStateUpdate.Remove(value); }
    }

    public event EventHandler<SpeakingStartArgs> OnSpeakingStart
    {
        add { _speakingStart.Add(value); }
        remove { _speakingStart.Remove(value); }
    }
    public event EventHandler<SpeakingStopArgs> OnSpeakingStop
    {
        add { _speakingStop.Add(value); }
        remove { _speakingStop.Remove(value); }
    }

    public event EventHandler<LayoutModeChangedArgs> OnLayoutModeChanged
    {
        add { _layoutModeChanged.Add(value); }
        remove { _layoutModeChanged.Remove(value); }
    }

    public event EventHandler<ThermalState> OnThermalStateChanged
    {
        add { _thermalStateChanged.Add(value); }
        remove { _thermalStateChanged.Remove(value); }
    }
}
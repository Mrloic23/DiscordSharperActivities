
global using global::System;
global using global::System.Threading.Tasks;

using System.Collections;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices.JavaScript;
using System.Runtime.Versioning;
using System.Text.Json;
using DiscordSharperActivities.Events;
using DiscordSharperActivities.Events.Args;
using DiscordSharperActivities.Models;

[assembly: InternalsVisibleTo("DiscordSharperActivities.Testing")]
namespace DiscordSharperActivities;

[SupportedOSPlatform("Browser")]
public class DiscordSDK
{
    private readonly SDKEvent<ReadyEventArgs> _ready = new(EventType.Ready);
    private readonly SDKEvent<UserVoiceState> _voiceStateUpdate = new(EventType.VoiceStateUpdate);
    private readonly SDKEvent<SpeakingStartArgs> _speakingStart = new(EventType.SpeakingStart);
    private readonly SDKEvent<SpeakingStopArgs> _speakingStop = new(EventType.SpeakingStop);
    private readonly SDKEvent<LayoutModeChangedArgs> _layoutModeChanged = new(EventType.OrientationUpdate);

    private readonly SDKEvent<ScreenOrientationchangedArgs> _orientationChanged = new(EventType.OrientationUpdate);

    private readonly SDKEvent<DiscordUser> _currentUserUpdated = new(EventType.CurrentUserUpdate);

    private readonly SDKEvent<CreateEntitlementArgs> _entitlementCreated = new(EventType.EntitlementCreate);
    private readonly SDKEvent<ThermalState> _thermalStateChanged = new(EventType.ThermalStateUpdate);
    internal static DiscordSDK? _instance;
    internal protected readonly JSObject _sdk;
    public static DiscordSDK Instance { get => _instance ?? throw new InvalidOperationException("SDK has not been created yet"); }
    public string ClientID { get => _sdk.GetPropertyAsString("clientId")!; }
    public string InstanceID { get => _sdk.GetPropertyAsString("instanceId")!; }



    internal protected DiscordSDK(SDKConfig config)
    {
        var conf = config.ToJSObject();
        _sdk = JSBindings.InstantiateSDK(config.clientID, conf);
    }

    public async static Task<DiscordSDK> CreateSDKAsync(SDKConfig config)
    {
        if (_instance != null)
            throw new InvalidOperationException("SDK has already been created");

        if (!JSBindings.IsImported)
            await JSBindings.ImportAsync(config.urlBase);
        _instance = new DiscordSDK(config);
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

    public event EventHandler<CreateEntitlementArgs> OnEntitlementCreated
    {
        add { _entitlementCreated.Add(value); }
        remove { _entitlementCreated.Remove(value); }
    }
    public event EventHandler<DiscordUser> OnCurrentUserUpdated
    {
        add { _currentUserUpdated.Add(value); }
        remove { _currentUserUpdated.Remove(value); }
    }
}
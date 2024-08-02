using System.Runtime.CompilerServices;
using System.Runtime.Versioning;
using DiscordSharperActivities;
using DiscordSharperActivities.Models;

namespace DiscordSharperActivities.Testing;

[SupportedOSPlatform("browser")]
public class DiscordSDKMock : DiscordSDK
{
    private static DiscordSDKMock? _instance;

    public new static DiscordSDKMock Instance{ get => _instance ?? throw new InvalidOperationException("SDK has not been created yet"); }
    public EventEmitter Emit { get; } = new();
    private DiscordSDKMock(SDKConfig config) : base(config)
    {
    }

    public async static new Task<DiscordSDKMock> CreateSDKAsync(SDKConfig config)
    {
        if (_instance != null)
            throw new InvalidOperationException("SDK has already been created");
        if (!JSBindings.IsImported)
            await JSBindings.ImportAsync(config.urlBase);
        _instance = new(config);
        return _instance;
    }




}
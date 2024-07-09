using System.Runtime.InteropServices.JavaScript;
using System.Runtime.Versioning;

namespace DiscordSharperActivities.Models;
[SupportedOSPlatform("Browser")]
public class SDKConfig
{
    internal readonly JSObject _ref;
    public SDKConfig()
    {
        _ref = JSBindings.CreateSDKConfig();
    }

    public bool DisableConsoleLogOverride
    {
        get => _ref.GetPropertyAsBoolean("disableConsoleLogOverride");
        set => _ref.SetProperty("disableConsoleLogOverride", value);
    }
    
}
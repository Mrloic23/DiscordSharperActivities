using System.Runtime.InteropServices.JavaScript;
using System.Runtime.Versioning;

namespace DiscordSharperActivities;
[SupportedOSPlatform("browser")]
public class Commands
{

    private readonly DiscordSDK _sdk;
    internal JSObject _commands;

    internal Commands(DiscordSDK sdk)
    {
        _sdk = sdk;
        _commands = JSBindings.GetCommands(sdk._sdk);
    }
}
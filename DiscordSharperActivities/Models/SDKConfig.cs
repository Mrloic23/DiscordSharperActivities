using System.Runtime.InteropServices.JavaScript;
using System.Runtime.Versioning;
using Microsoft.JSInterop;

namespace DiscordSharperActivities.Models;
[SupportedOSPlatform("Browser")]
public class SDKConfig(string clientID, string urlBase = "")
{
    public readonly string clientID = clientID;
    public readonly string urlBase = urlBase;

    public bool DisableConsoleLogOverride { get; set; }

    internal JSObject ToJSObject()
    {  
        var obj = JSBindings.CreateSDKConfig();
        obj.SetProperty("disableConsoleLogOverride", DisableConsoleLogOverride);
        Console.WriteLine("Config Created");
        return obj;
    }
}
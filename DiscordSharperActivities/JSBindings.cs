using System.Collections;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.JavaScript;
using System.Runtime.Versioning;

namespace DiscordSharperActivities;
[SupportedOSPlatform("browser")]
internal static partial class JSBindings
{
    internal static void Import(string urlBase)
    {
        JSHost.ImportAsync("discordWrapper",$"{urlBase}/wrapper.js").Wait();
    }

    [JSImport("createSDKConfig", "discordWrapper")]
    [return: JSMarshalAs<JSType.Object>]
    internal static partial JSObject CreateSDKConfig();

    [JSImport("instantiateSDK", "discordWrapper")]
    [return: JSMarshalAs<JSType.Object>]
    internal static partial JSObject InstantiateSDK(string clientID, [JSMarshalAs<JSType.Object>] JSObject? config);

    [JSImport("subscribeToEvent", "discordWrapper")]
    internal static partial Task SubscribeToEvent(string eventName, [JSMarshalAs<JSType.Function<JSType.Object>>] Action<JSObject> action);

    [JSImport("ready", "discordWrapper")]
    internal static partial Task Ready(JSObject sdk);
}
using System.Collections;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.JavaScript;
using System.Runtime.Versioning;

namespace DiscordSharperActivities;
[SupportedOSPlatform("browser")]
internal static partial class JSBindings
{
    internal async static Task ImportAsync(string urlBase)
    {
        await JSHost.ImportAsync("discordWrapper",$"{urlBase}/_content/DiscordSharperActivities/wrapper.js");
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
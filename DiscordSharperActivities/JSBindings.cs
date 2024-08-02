using System.Collections;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.JavaScript;
using System.Runtime.Versioning;

namespace DiscordSharperActivities;
[SupportedOSPlatform("browser")]

internal static partial class JSBindings
{
    internal static bool IsImported { get; set; } = false;
    internal async static Task ImportAsync(string urlBase)
    {
        if (IsImported)
            return;
        await JSHost.ImportAsync("DiscordWrapper", $"{urlBase}/_content/DiscordSharperActivities/wrapper.js");
    }

    [JSImport("globalThis.DiscordWrapper.createSDKConfig")]
    [return: JSMarshalAs<JSType.Object>]
    internal static partial JSObject CreateSDKConfig();

    [JSImport("globalThis.DiscordWrapper.instantiateSDK")]
    [return: JSMarshalAs<JSType.Object>]
    internal static partial JSObject InstantiateSDK(string clientID, [JSMarshalAs<JSType.Object>] JSObject? config);

    [JSImport("globalThis.DiscordWrapper.subscribeToEvent")]
    internal static partial Task SubscribeToEvent(string eventName, [JSMarshalAs<JSType.Function<JSType.Object>>] Action<JSObject> action);

    [JSImport("globalThis.DiscordWrapper.ready")]
    internal static partial Task Ready(JSObject sdk);
}
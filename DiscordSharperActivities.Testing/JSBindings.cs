using System.Runtime.InteropServices.JavaScript;
using System.Runtime.Versioning;
using Microsoft.JSInterop;

namespace DiscordSharperActivities.Testing;

[SupportedOSPlatform("browser")]
internal static partial class JSBindings
{
    internal static bool IsImported { get; private set; }

    internal static async Task ImportAsync(string urlBase)
    {
        if (IsImported)
            return;
        await JSHost.ImportAsync("DiscordWrapper", $"{urlBase}/_content/DiscordSharperActivities.Testing/mock.js?");
        IsImported = true;
        DiscordSharperActivities.JSBindings.IsImported = true;
    }

    [JSImport("globalThis.DiscordWrapper.emitReady")]
    [return: JSMarshalAs<JSType.Void>]
    internal static partial void EmitReady([JSMarshalAs<JSType.Object>] JSObject sdk);

    [JSImport("globalThis.DiscordWrapper.emitEvent")]
    [return: JSMarshalAs<JSType.Void>]
    internal static partial void EmitEvent([JSMarshalAs<JSType.Object>] JSObject sdk, [JSMarshalAs<JSType.String>] string eventName, [JSMarshalAs<JSType.String>] string data);

    [JSImport("globalThis.DiscordWrapper.setGuildID")]
    internal static partial void SetGuildID(string guildID);
    [JSImport("globalThis.DiscordWrapper.setChannelID")]
    internal static partial void SetChannelID(string channelID);
}
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
        await JSHost.ImportAsync("DiscordWrapper", $"{urlBase}/_content/DiscordSharperActivities.Testing/wrapper.js");
        IsImported = true;
        DiscordSharperActivities.JSBindings.IsImported = true;
    }

    [JSImport("globalThis.DiscordWrapper.emitReady")]
    internal static partial void EmitReady(JSObject sdk);

    [JSImport("globalThis.DiscordWrapper.emitEvent")]
    internal static partial void EmitEvent(string eventName, string data);

    [JSImport("globalThis.DiscordWrapper.setGuildID")]
    internal static partial void SetGuildID(string guildID);
    [JSImport("globalThis.DiscordWrapper.setChannelID")]
    internal static partial void SetChannelID(string channelID);
}
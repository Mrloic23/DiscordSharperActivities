using System.Text.Json.Serialization;
using DiscordSharperActivities.Models;

namespace DiscordSharperActivities.Events.Args;

public class LayoutModeChangedArgs
{
    [JsonRequired]
    [JsonPropertyName("layout_mode")]
    public readonly LayoutMode layoutMode = default!;
}
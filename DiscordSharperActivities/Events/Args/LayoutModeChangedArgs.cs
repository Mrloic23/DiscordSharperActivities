using System.Text.Json.Serialization;
using DiscordSharperActivities.Models;

namespace DiscordSharperActivities.Events.Args;

public class LayoutModeChangedArgs(LayoutMode layoutMode)
{
    [JsonRequired]
    [JsonPropertyName("layout_mode")]
    public readonly LayoutMode layoutMode = layoutMode;
}
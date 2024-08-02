namespace DiscordSharperActivities.Events.Args;

using System.Text.Json.Serialization;
using DiscordSharperActivities.Models;

public class ScreenOrientationchangedArgs(ScreenOrientation orientation)
{
    [JsonRequired]
    [JsonPropertyName("screen_orientation")]
    public readonly ScreenOrientation orientation = orientation;
}
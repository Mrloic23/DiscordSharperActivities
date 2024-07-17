namespace DiscordSharperActivities.Events.Args;

using System.Text.Json.Serialization;
using DiscordSharperActivities.Models;

public class ScreenOrientationchangedArgs
{
    [JsonRequired]
    [JsonPropertyName("screen_orientation")]
    public readonly ScreenOrientation orientation;
}
using System.Text.Json.Serialization;
using DiscordSharperActivities.Models;

namespace DiscordSharperActivities.Events.Args;

public class CreateEntitlementArgs(Entitlement entitlement){
    

    [JsonPropertyName("entitlement")]
    [JsonRequired]
    public required Entitlement Entitlement { get; set; } = entitlement;
}

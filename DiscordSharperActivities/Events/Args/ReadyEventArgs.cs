using System.Security.Cryptography.X509Certificates;
using System.Text.Json.Serialization;
using DiscordSharperActivities.Models;

namespace DiscordSharperActivities.Events.Args;

public class ReadyEventArgs : EventArgs
{
    [JsonPropertyName("v")]
    [JsonRequired]
    public readonly float version;

    [JsonPropertyName("config")]
    [JsonRequired]
    public readonly ReadyEventConfiguration configuration = default!;

    /// <summary>
    /// this class should not be instantiated manually, 
    /// it is used to reference a nested object in the JSEventArgs passed
    /// </summary>
    public class ReadyEventConfiguration{
        [JsonRequired]
        public readonly string cdn_host = default!;
        [JsonRequired]
        public readonly string api_endpoint = default!;
        [JsonRequired]
        public readonly string environment = default!;
    }
}
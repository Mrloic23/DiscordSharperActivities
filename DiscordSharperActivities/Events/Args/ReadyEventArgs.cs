using System.Security.Cryptography.X509Certificates;
using System.Text.Json.Serialization;
using DiscordSharperActivities.Models;

namespace DiscordSharperActivities.Events.Args;

public class ReadyEventArgs(float version, ReadyEventArgs.ReadyEventConfiguration configuration) : EventArgs
{
    [JsonPropertyName("v")]
    [JsonRequired]
    public readonly float version = version;

    [JsonPropertyName("config")]
    [JsonRequired]
    public readonly ReadyEventConfiguration configuration = configuration;

    /// <summary>
    /// this class should not be instantiated manually, 
    /// it is used to reference a nested object in the JSEventArgs passed
    /// </summary>
    public class ReadyEventConfiguration(string cdn_host, string api_endpoint, string environment)
    {
        [JsonRequired]
        public readonly string cdn_host = cdn_host;
        [JsonRequired]
        public readonly string api_endpoint = api_endpoint;
        [JsonRequired]
        public readonly string environment = environment;
    }
}
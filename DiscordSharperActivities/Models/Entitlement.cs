using System.Text.Json.Serialization;

namespace DiscordSharperActivities.Models;

public class Entitlement
{
    internal Entitlement(string id, string applicationId, string userId, string skuId, int giftCodeFlags)
    {
        this.id = id;
        this.applicationId = applicationId;
        this.userId = userId;
        this.skuId = skuId;
        this.giftCodeFlags = giftCodeFlags;
    }
    [JsonPropertyName("parent_id")]
    public string? parentId;

    [JsonPropertyName("gifter_user_id")]
    public string? gifterUserId;

    [JsonPropertyName("branches")]
    public string[]? branches;

    [JsonPropertyName("starts_at")]
    public string? startsAt; // ISO string

    [JsonPropertyName("ends_at")]
    public string? endsAt; // ISO string

    [JsonPropertyName("consumed")]
    public bool? consumed;

    [JsonPropertyName("deleted")]
    public bool? deleted;

    [JsonPropertyName("gift_code_batch_id")]
    public string? giftCodeBatchId;

    [JsonPropertyName("type")]
    public EntitlementTypes type;

    [JsonPropertyName("id")]
    [JsonRequired]
    public string id;

    [JsonPropertyName("application_id")]
    [JsonRequired]
    public string applicationId;

    [JsonPropertyName("user_id")]
    [JsonRequired]
    public string userId;

    [JsonPropertyName("sku_id")]
    [JsonRequired]
    public string skuId = default!;

    [JsonPropertyName("gift_code_flags")]
    [JsonRequired]
    public int giftCodeFlags;
}

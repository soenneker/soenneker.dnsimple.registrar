using System.Text.Json.Serialization;

namespace Soenneker.DNSimple.Registrar.Responses;

/// <summary>
/// Represents details of a renewed domain.
/// </summary>
public record DomainRenewalData
{
    /// <summary>
    /// The unique identifier of the renewal.
    /// </summary>
    [JsonPropertyName("id")]
    public int Id { get; set; }

    /// <summary>
    /// The domain ID.
    /// </summary>
    [JsonPropertyName("domain_id")]
    public int DomainId { get; set; }

    /// <summary>
    /// The current state of the renewal (e.g., "renewed").
    /// </summary>
    [JsonPropertyName("state")]
    public string State { get; set; }
}
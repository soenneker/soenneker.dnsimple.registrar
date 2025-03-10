using System.Text.Json.Serialization;

namespace Soenneker.DNSimple.Registrar.Responses;

/// <summary>
/// Represents details of a transferred domain.
/// </summary>
public record DomainTransferData
{
    /// <summary>
    /// The unique identifier of the transfer.
    /// </summary>
    [JsonPropertyName("id")]
    public int Id { get; set; }

    /// <summary>
    /// The domain ID.
    /// </summary>
    [JsonPropertyName("domain_id")]
    public int DomainId { get; set; }

    /// <summary>
    /// The current state of the transfer (e.g., "transferring", "completed").
    /// </summary>
    [JsonPropertyName("state")]
    public string State { get; set; }
}
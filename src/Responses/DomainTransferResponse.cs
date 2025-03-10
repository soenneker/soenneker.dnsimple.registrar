using System.Text.Json.Serialization;

namespace Soenneker.DNSimple.Registrar.Responses;

/// <summary>
/// Response model for domain transfer.
/// </summary>
public record DomainTransferResponse
{
    /// <summary>
    /// The domain transfer details.
    /// </summary>
    [JsonPropertyName("data")]
    public DomainTransferData Data { get; set; }
}
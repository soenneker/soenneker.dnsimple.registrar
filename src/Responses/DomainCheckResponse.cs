using System.Text.Json.Serialization;

namespace Soenneker.DNSimple.Registrar.Responses;

/// <summary>
/// Response model for checking domain availability.
/// </summary>
public record DomainCheckResponse
{
    /// <summary>
    /// The domain availability information.
    /// </summary>
    [JsonPropertyName("data")]
    public DomainCheckData Data { get; set; }
}
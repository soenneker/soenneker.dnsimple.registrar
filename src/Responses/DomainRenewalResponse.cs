using System.Text.Json.Serialization;

namespace Soenneker.DNSimple.Registrar.Responses;

/// <summary>
/// Response model for domain renewal.
/// </summary>
public record DomainRenewalResponse
{
    /// <summary>
    /// The domain renewal details.
    /// </summary>
    [JsonPropertyName("data")]
    public DomainRenewalData Data { get; set; }
}
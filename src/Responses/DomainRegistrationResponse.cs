using System.Text.Json.Serialization;

namespace Soenneker.DNSimple.Registrar.Responses;

/// <summary>
/// Response model for domain registration.
/// </summary>
public record DomainRegistrationResponse
{
    /// <summary>
    /// The domain registration details.
    /// </summary>
    [JsonPropertyName("data")]
    public DomainRegistrationData Data { get; set; }
}
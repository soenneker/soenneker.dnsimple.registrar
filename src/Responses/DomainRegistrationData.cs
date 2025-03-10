using System.Text.Json.Serialization;

namespace Soenneker.DNSimple.Registrar.Responses;

/// <summary>
/// Represents details of a registered domain.
/// </summary>
public record DomainRegistrationData
{
    /// <summary>
    /// The unique identifier of the registration.
    /// </summary>
    [JsonPropertyName("id")]
    public int Id { get; set; }

    /// <summary>
    /// The domain ID.
    /// </summary>
    [JsonPropertyName("domain_id")]
    public int DomainId { get; set; }

    /// <summary>
    /// The state of the domain registration (e.g., "new", "registering").
    /// </summary>
    [JsonPropertyName("state")]
    public string State { get; set; }
}
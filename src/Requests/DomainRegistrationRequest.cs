using System.Text.Json.Serialization;

namespace Soenneker.DNSimple.Registrar.Requests;

/// <summary>
/// Request model for domain registration.
/// </summary>
public record DomainRegistrationRequest
{
    /// <summary>
    /// The ID of an existing contact in your account.
    /// </summary>
    [JsonPropertyName("registrant_id")]
    public int RegistrantId { get; set; }

    /// <summary>
    /// Whether to enable auto-renewal for the domain.
    /// </summary>
    [JsonPropertyName("auto_renew")]
    public bool AutoRenew { get; set; }
}
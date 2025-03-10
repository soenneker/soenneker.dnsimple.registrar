using System.Text.Json.Serialization;

namespace Soenneker.DNSimple.Registrar.Requests;

/// <summary>
/// Request model for transferring a domain.
/// </summary>
public record DomainTransferRequest
{
    /// <summary>
    /// The ID of an existing contact in your account.
    /// </summary>
    [JsonPropertyName("registrant_id")]
    public int RegistrantId { get; set; }

    /// <summary>
    /// The authorization code required for domain transfer.
    /// </summary>
    [JsonPropertyName("auth_code")]
    public string AuthCode { get; set; }
}
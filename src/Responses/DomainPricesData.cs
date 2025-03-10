using System.Text.Json.Serialization;

namespace Soenneker.DNSimple.Registrar.Responses;

/// <summary>
/// Represents domain pricing information.
/// </summary>
public record DomainPricesData
{
    /// <summary>
    /// The domain name.
    /// </summary>
    [JsonPropertyName("domain")]
    public string Domain { get; set; }

    /// <summary>
    /// Indicates whether the domain is a premium domain.
    /// </summary>
    [JsonPropertyName("premium")]
    public bool Premium { get; set; }

    /// <summary>
    /// The price for registering the domain.
    /// </summary>
    [JsonPropertyName("registration_price")]
    public decimal RegistrationPrice { get; set; }

    /// <summary>
    /// The price for renewing the domain.
    /// </summary>
    [JsonPropertyName("renewal_price")]
    public decimal RenewalPrice { get; set; }

    /// <summary>
    /// The price for transferring the domain.
    /// </summary>
    [JsonPropertyName("transfer_price")]
    public decimal TransferPrice { get; set; }
}
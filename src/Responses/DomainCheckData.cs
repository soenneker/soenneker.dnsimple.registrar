using System.Text.Json.Serialization;

namespace Soenneker.DNSimple.Registrar.Responses;

/// <summary>
/// Represents domain availability details.
/// </summary>
public record DomainCheckData
{
    /// <summary>
    /// The domain name that was checked.
    /// </summary>
    [JsonPropertyName("domain")]
    public string Domain { get; set; }

    /// <summary>
    /// Indicates whether the domain is available for registration.
    /// </summary>
    [JsonPropertyName("available")]
    public bool Available { get; set; }

    /// <summary>
    /// Indicates whether the domain is a premium domain.
    /// </summary>
    [JsonPropertyName("premium")]
    public bool Premium { get; set; }
}
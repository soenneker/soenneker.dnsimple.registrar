using System.Text.Json.Serialization;

namespace Soenneker.DNSimple.Registrar.Responses;

public record DomainPremiumPriceData
{
    [JsonPropertyName("premium_price")]
    public string PremiumPrice { get; set; }

    [JsonPropertyName("action")]
    public string Action { get; set; }
}
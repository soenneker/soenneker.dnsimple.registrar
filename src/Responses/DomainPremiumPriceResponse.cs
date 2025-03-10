using System.Text.Json.Serialization;

namespace Soenneker.DNSimple.Registrar.Responses;

public record DomainPremiumPriceResponse
{
    [JsonPropertyName("data")]
    public DomainPremiumPriceData Data { get; set; }
}
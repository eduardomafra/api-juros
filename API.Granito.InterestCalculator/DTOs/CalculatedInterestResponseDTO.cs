using System.Text.Json.Serialization;

namespace API.Granito.InterestCalculator.DTOs
{
    public class CalculatedInterestResponseDTO
    {
        [JsonPropertyName("Valor com juros")]
        public decimal ValueWithInterest { get; set; }
    }
}

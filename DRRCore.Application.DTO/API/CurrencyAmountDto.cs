using System.Text.Json.Serialization;

namespace DRRCore.Application.DTO.API
{
    public class CurrencyAmountDto
    {
        [JsonPropertyName("DRR_CURAMO_ISOCUR")]
        public string IsoCurrency { get; set; } = string.Empty;
        [JsonPropertyName("DRR_CURAMO_AMOUNT")]
        public double Amount { get; set; }
        [JsonPropertyName("DRR_CURAMO_COMMEN")]
        public string Comment { get; set; } = string.Empty;
    }
    public class CurrencyAmountWithDateDto : CurrencyAmountDto
    {
        [JsonPropertyName("DRR_CURAMO_LASINF")]
        public string LastInformationDate { get; set; } = string.Empty;
    }
}

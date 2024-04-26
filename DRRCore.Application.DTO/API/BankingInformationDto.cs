using System.Text.Json.Serialization;

namespace DRRCore.Application.DTO.API
{
    public class BankingInformationDto
    {
        [JsonPropertyName("DRR_BANINF_SBSEXR")]
        public double ExchangeRateSbs { get; set; }
        [JsonPropertyName("DRR_BANINF_RISCEN")]
        public string RiskCenter { get; set; }= string.Empty;
        [JsonPropertyName("DRR_BANINF_REGDAT")]
        public string RegisterDate { get; set; }=string.Empty;
        [JsonPropertyName("DRR_BANINF_BANKKS")]
        public List<BankDto> Banks { get; set; } = new List<BankDto>();
        [JsonPropertyName("DRR_BANINF_MNTOTA")]
        public double MNTotal { get; set; }
        [JsonPropertyName("DRR_BANINF_MNGOFF")]
        public double MNGuaranteesOffered { get; set; }
        [JsonPropertyName("DRR_BANINF_SBSCOM")]
        public string SbsComment { get; set; } = string.Empty;

    }
    public class BankDto
    {
        [JsonPropertyName("DRR_BANKKS_BANNKK")]
        public string Bank { get; set; } = string.Empty;
        [JsonPropertyName("DRR_BANKKS_DEBRAT")]
        public ValueDetailDto DebtRating { get; set; }= new ValueDetailDto();
        [JsonPropertyName("DRR_BANKKS_ISOCUR")]
        public string IsoCurrency { get; set; } = string.Empty;
        [JsonPropertyName("DRR_BANKKS_AMOUNT")]
        public double Amount { get; set; }
    }
   
}

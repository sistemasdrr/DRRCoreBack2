using System.Text.Json.Serialization;

namespace DRRCore.Application.DTO.API
{
    public class LegalBackgroundDto
    {
        [JsonPropertyName("DRR_LEGBAC_LEGSTA")]
        public string LegalStatus { get; set; } = string.Empty;
        [JsonPropertyName("DRR_LEGBAC_INCDAT")]
        public string IncorporationDate { get; set; }=string.Empty;
        [JsonPropertyName("DRR_LEGBAC_STADAT")]
        public string OperationStartDate { get; set; }=string.Empty;
        [JsonPropertyName("DRR_LEGBAC_REGPLA")]
        public string RegisterPlace { get; set;}=string.Empty;
        [JsonPropertyName("DRR_LEGBAC_NOTOFF")]
        public string NotaryOffice { get;set; }=string.Empty;
        [JsonPropertyName("DRR_LEGBAC_DURTIM")]
        public string DurationTime { get; set;}=string.Empty;
        [JsonPropertyName("DRR_LEGBAC_REGFOL")]
        public string RegistrationFolio { get; set; }=string.Empty;
        [JsonPropertyName("DRR_LEGBAC_CURPCA")]
        public CurrencyAmountDto PaidInCapital { get; set; } = new CurrencyAmountDto();
        [JsonPropertyName("DRR_LEGBAC_LASCID")]
        public string LastCapitalIncreaseDate { get; set; }=string.Empty;
        [JsonPropertyName("DRR_LEGBAC_SHOEQU")]
        public CurrencyAmountWithDateDto ShareholdersEquity { get; set; } = new CurrencyAmountWithDateDto();
        [JsonPropertyName("DRR_LEGBAC_SHACLA")]
        public string ShareClass { get; set; }=string.Empty;
        [JsonPropertyName("DRR_LEGBAC_STKEXL")]
        public bool StockExchangeListed { get;set; }=false;
        [JsonPropertyName("DRR_LEGBAC_CUREXR")]
        public CurrencyAmountDto CurrentExchangeRate { get; set; } = new CurrencyAmountDto();
        [JsonPropertyName("DRR_LEGBAC_MEMSHI")]
        public string Membership { get; set; }= string.Empty;
        [JsonPropertyName("DRR_LEGBAC_COMENT")]
        public string Comments { get; set; } = string.Empty;

    }
}

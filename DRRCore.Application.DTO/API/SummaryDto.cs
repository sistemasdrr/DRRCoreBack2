using Microsoft.VisualBasic;
using System;
using System.Text.Json.Serialization;

namespace DRRCore.Application.DTO.API
{
    public class SummaryDto
    {
        [JsonPropertyName("DRR_SUMMAR_INSYEA")]
        public string InscriptionYear { get; set; } = string.Empty;
        [JsonPropertyName("DRR_SUMMAR_CAPSTK")]
        public CurrencyAmountDto CapitalStock { get; set; } = new CurrencyAmountDto();
        [JsonPropertyName("DRR_SUMMAR_SHOLEQ")]
        public CurrencyAmountWithDateDto ShareholdersEquity { get; set; } = new CurrencyAmountWithDateDto();
        [JsonPropertyName("DRR_SUMMAR_ANNREN")]
        public CurrencyAmountWithDateDto AnnualRevenues { get; set; } = new CurrencyAmountWithDateDto();
        [JsonPropertyName("DRR_SUMMAR_PROFIT")]
        public CurrencyAmountWithDateDto Profits { get; set; } = new CurrencyAmountWithDateDto();
        [JsonPropertyName("DRR_SUMMAR_EMPLOY")]
        public int Employees { get; set; } = 0;
        [JsonPropertyName("DRR_SUMMAR_CHIEEX")]
        public string ChiefExecutive { get; set; } = string.Empty;
        [JsonPropertyName("DRR_SUMMAR_FINSIT")]
        public ValueDetailDto FinalSituation { get; set; } = new ValueDetailDto();
        [JsonPropertyName("DRR_SUMMAR_DISPOS")]
        public ValueDetailDto Disposition { get; set; } = new ValueDetailDto();
        [JsonPropertyName("DRR_SUMMAR_PAYPOL")]
        public ValueDetailDto PaymentsPolicy { get; set; } = new ValueDetailDto();
        [JsonPropertyName("DRR_SUMMAR_CREDIT")]
        public ValueDetailDto Credit { get; set; } = new ValueDetailDto();
        [JsonPropertyName("DRR_SUMMAR_SECTOR")]
        public ValueDetailDto Sector { get; set; } = new ValueDetailDto();
        [JsonPropertyName("DRR_SUMMAR_BRANCH")]
        public ValueDetailDto Branch { get; set; } = new ValueDetailDto();

    }
    
   
   
}



 
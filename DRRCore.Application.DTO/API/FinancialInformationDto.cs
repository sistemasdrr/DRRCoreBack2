using System.Text.Json.Serialization;

namespace DRRCore.Application.DTO.API
{
    public class FinancialInformationDto
    {
        [JsonPropertyName("DRR_FININF_DISPOS")]
        public ValueDetailDto Disposition { get; set; } = new ValueDetailDto();
        [JsonPropertyName("DRR_FININF_INFPRO")]
        public string InformationProvided { get; set; } = string.Empty;
        [JsonPropertyName("DRR_FININF_INTBAL")]
        public List<BalanceSheetDto> InterimBalanceSheets { get; set; } = new List<BalanceSheetDto>();
        [JsonPropertyName("DRR_FININF_RATSIT")]
        public RatioSituationDto RatioSituation { get; set; } = new RatioSituationDto();
        [JsonPropertyName("DRR_FININF_BALSHE")]
        public List<BalanceSheetDto> BalanceSheets { get; set; } = new List<BalanceSheetDto>();
        [JsonPropertyName("DRR_FININF_SITFIN")]
        public ValueDetailDto SituationalFinancial { get; set; } = new ValueDetailDto();
        [JsonPropertyName("DRR_FININF_COMMEN")]
        public string Comments { get; set; } = string.Empty;
        [JsonPropertyName("DRR_FININF_ANACOM")]
        public string AnalystComments { get; set; } = string.Empty;
        [JsonPropertyName("DRR_FININF_INSURA")]
        public List<InsuranceCompaniesDto> Insurances { get; set; } = new List<InsuranceCompaniesDto>();


    }
    public class RatioSituationDto
    {
        [JsonPropertyName("DRR_RATSIT_LIQRAT")]
        public double LiquidityRatio { get; set; }
        [JsonPropertyName("DRR_RATSIT_DLIRAT")]
        public double DebtToEquityRatio { get; set; }
        [JsonPropertyName("DRR_RATSIT_PROMAR")]
        public double ProfitabilityMargin { get; set; }
        [JsonPropertyName("DRR_RATSIT_WORCAP")]
        public double WorkingCapital { get; set; }
    }
    public class InsuranceCompaniesDto
    {
        [JsonPropertyName("DRR_INSURA_DESCRI")]
        public string Name { get; set; } = string.Empty;
        [JsonPropertyName("DRR_INSURA_AGAINS")]
        public string Against { get; set; } = string.Empty;
    }
}

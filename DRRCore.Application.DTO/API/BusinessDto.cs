using System.Text.Json.Serialization;

namespace DRRCore.Application.DTO.API
{
    public class BusinessDto
    {
        [JsonPropertyName("DRR_BUSINE_MAIACT")]
        public string MainActivity { get; set; }=string.Empty;
        [JsonPropertyName("DRR_BUSINE_SECTOR")]
        public ValueDetailDto Sector { get; set; } = new ValueDetailDto();
        [JsonPropertyName("DRR_BUSINE_BRANCH")]
        public ValueDetailDto Branch { get; set; } = new ValueDetailDto();
        [JsonPropertyName("DRR_BUSINE_IMPORT")]
        public BussinessImportExportDto Import { get; set; } = new BussinessImportExportDto();
        [JsonPropertyName("DRR_BUSINE_EXPORT")]
        public BussinessImportExportDto Export { get; set; } = new BussinessImportExportDto();
        [JsonPropertyName("DRR_BUSINE_CSALPG")]
        public PercentageValue CashSalesPercentage { get; set; } = new PercentageValue();
        [JsonPropertyName("DRR_BUSINE_CRESPG")]
        public PercentageValue CreditSalesPercentage { get; set; } = new PercentageValue();
        [JsonPropertyName("DRR_BUSINE_FRGSPG")]
        public PercentageValue ForeignSalePercentage { get; set; } = new PercentageValue();
        [JsonPropertyName("DRR_BUSINE_DOMPPG")]
        public PercentageValue DomesticPourchasesPercentage { get; set; } = new PercentageValue();
        [JsonPropertyName("DRR_BUSINE_FORPPG")]
        public PercentageValue ForeignPourchasesPercentage { get; set; } = new PercentageValue();
        [JsonPropertyName("DRR_BUSINE_SELTPG")]
        public PercentageValue SellingTerritoryPercentage { get; set; } = new PercentageValue();
        [JsonPropertyName("DRR_BUSINE_EMPLOY")]
        public int? Employess { get; set; }


    }
    public class PercentageValue
    {
        [JsonPropertyName("DRR_PERCGE_VALUEE")]
        public decimal? Value { get; set; }
        [JsonPropertyName("DRR_PERCGE_DESCRI")]
        public string Description { get; set; } = string.Empty;
    }
    public class BussinessImportExportDto
    {
        [JsonPropertyName("DRR_BUSIMP_HASIMP")]
        public bool? HasImportedOrExported { get; set; }=false;
        [JsonPropertyName("DRR_BUSIMP_COUNTS")]
        public List<string> Countries { get; set;}=new List<string>();
        [JsonPropertyName("DRR_BUSIMP_DETAIL")]
        public List<BussinessAmountDetailDto> Details { get; set; } = new List<BussinessAmountDetailDto>();

    }
   
    public class BussinessAmountDetailDto
    {
        [JsonPropertyName("DRR_BUSAMO_YEEARR")]
        public string Year { get; set; } = string.Empty;
        [JsonPropertyName("DRR_BUSAMO_AMOUNT")]
        public double Amount { get; set; } 
    }       
}

using System.Text.Json.Serialization;

namespace DRRCore.Application.DTO.API
{
    public class BalanceSheetDto
    {
        [JsonPropertyName("DRR_BALSHE_ISCURR")]
        public bool IsCurrent { get; set; } = false;
        [JsonPropertyName("DRR_BALSHE_DATTEE")]
        public string Date { get; set; } = string.Empty;
        [JsonPropertyName("DRR_BALSHE_TYBALS")]
        public string TypeBalanceSheet { get; set; } = string.Empty;
        [JsonPropertyName("DRR_BALSHE_PERIOD")]
        public string Period { get; set; } = string.Empty;
        [JsonPropertyName("DRR_BALSHE_ISOCUR")]
        public string IsoCurrency { get; set; } = string.Empty;
        [JsonPropertyName("DRR_BALSHE_EXCRAN")]
        public string ExchangeRate { get; set; } = string.Empty;
        [JsonPropertyName("DRR_BALSHE_ASSETS")]
        public AssetsDto Assets { get; set; } = new AssetsDto();
        [JsonPropertyName("DRR_BALSHE_LIABIL")]
        public LiabilitiesDto Liabilities { get; set; } = new LiabilitiesDto();
        [JsonPropertyName("DRR_BALSHE_SHOEQU")]
        public ShareholdersEquityDto ShareholdersEquity { get; set; } = new ShareholdersEquityDto();
        [JsonPropertyName("DRR_BALSHE_SALESS")]
        public double Sales { get; set; }
        [JsonPropertyName("DRR_BALSHE_PROLSS")]
        public double ProfitLoss { get; set; }  

    }
    public class AssetsDto
    {
        [JsonPropertyName("DRR_ASSETS_CASBAN")]
        public double CashBanks { get; set; }
        [JsonPropertyName("DRR_ASSETS_RECIVB")]
        public double Receivables { get; set; }
        [JsonPropertyName("DRR_ASSETS_INVENT")]
        public double Inventory { get; set; }
        [JsonPropertyName("DRR_ASSETS_OTHAST")]
        public double OthersAssets { get; set; }
        [JsonPropertyName("DRR_ASSETS_CURAST")]
        public double CurrentAssets { get; set; }
        [JsonPropertyName("DRR_ASSETS_FIXXED")]
        public double Fixed { get; set; }
        [JsonPropertyName("DRR_ASSETS_OCUAST")]
        public double OthersCurrentAssets { get; set; }
        [JsonPropertyName("DRR_ASSETS_TOTAST")]
        public double TotalAssets { get; set; }
    }
    public class LiabilitiesDto
    {
        [JsonPropertyName("DRR_LIABTS_BANSUP")]
        public double BankSuppliers { get; set; }
        [JsonPropertyName("DRR_LIABTS_OTHLBS")]
        public double OthersLiabilities { get; set; }
        [JsonPropertyName("DRR_LIABTS_CURLBS")]
        public double CurrentLiabilities { get; set; }
        [JsonPropertyName("DRR_LIABTS_OCULBS")]
        public double OthersCurrentLiabilities { get; set; }
    }
    public class ShareholdersEquityDto
    {
        [JsonPropertyName("DRR_SHOEQU_CAPITA")]
        public double Capital { get; set; }
        [JsonPropertyName("DRR_SHOEQU_RESERV")]
        public double Reserves { get; set; }
        [JsonPropertyName("DRR_SHOEQU_PROLOO")]
        public double ProfitsLoots { get; set; }
        [JsonPropertyName("DRR_SHOEQU_TOTSEQ")]
        public double TotalShareholderEquity { get; set; }
        [JsonPropertyName("DRR_SHOEQU_TOTLBS")]
        public double TotalLiabilitiesShareholderEquity { get; set; }
    }
}

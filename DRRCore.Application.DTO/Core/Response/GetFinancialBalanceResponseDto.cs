namespace DRRCore.Application.DTO.Core.Response
{
    public class GetFinancialBalanceResponseDto
    {
        public int Id { get; set; }

        public int? IdCompany { get; set; }

        public string? Date { get; set; }

        public string? BalanceType { get; set; }

        public string? Duration { get; set; }

        public int? IdCurrency { get; set; }

        public decimal? ExchangeRate { get; set; }

        public decimal? Sales { get; set; }

        public decimal? Utilities { get; set; }

        public decimal? TotalAssets { get; set; }

        public decimal? TotalCurrentAssets { get; set; }

        public decimal? ACashBoxBank { get; set; }

        public decimal? AToCollect { get; set; }

        public decimal? AInventory { get; set; }

        public decimal? AOtherCurrentAssets { get; set; }

        public decimal? TotalNonCurrentAssets { get; set; }

        public decimal? AFixed { get; set; }

        public decimal? AOtherNonCurrentAssets { get; set; }

        public decimal? TotalLliabilities { get; set; }

        public decimal? TotalCurrentLiabilities { get; set; }

        public decimal? LCashBoxBank { get; set; }

        public decimal? LOtherCurrentLiabilities { get; set; }

        public decimal? TotalNonCurrentLiabilities { get; set; }

        public decimal? LLongTerm { get; set; }

        public decimal? LOtherNonCurrentLiabilities { get; set; }

        public decimal? TotalPatrimony { get; set; }

        public decimal? PCapital { get; set; }

        public decimal? PStockPile { get; set; }

        public decimal? PUtilities { get; set; }

        public decimal? POther { get; set; }

        public decimal? TotalLiabilitiesPatrimony { get; set; }

        public decimal? LiquidityRatio { get; set; }

        public decimal? DebtRatio { get; set; }

        public decimal? ProfitabilityRatio { get; set; }

        public decimal? WorkingCapital { get; set; }
    }
}

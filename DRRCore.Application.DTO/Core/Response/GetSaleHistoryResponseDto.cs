namespace DRRCore.Application.DTO.Core.Response
{
    public class GetSaleHistoryResponseDto
    {
        public int Id { get; set; }
        public int? IdCompany{ get; set; }
        public int? IdCurrency{ get; set; }
        public DateTime? Date { get; set; }
        public decimal? Amount { get; set; } = new decimal();
        public decimal? ExchangeRate{ get; set; } = new decimal();
        public decimal? EquivalentToDollars { get; set; } = new decimal();
    }
}

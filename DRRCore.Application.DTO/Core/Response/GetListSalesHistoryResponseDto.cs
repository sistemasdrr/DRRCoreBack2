namespace DRRCore.Application.DTO.Core.Response
{
    public class GetListSalesHistoryResponseDto
    {
        public int Id { get; set; }
        public string? Date { get; set; }
        public string Currency { get; set; } = string.Empty;
        public string Amount{ get; set; } = string.Empty;
        public string ExchangeRate { get; set; } = string.Empty;
        public string EquivalentToDollars { get; set; } = string.Empty;
    }
}

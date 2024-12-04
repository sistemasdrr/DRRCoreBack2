using DRRCore.Application.DTO.Core.Response;

namespace DRRCore.Application.DTO.Core.Request
{
    public class AddOrUpdateAgentInvoiceRequestDto
    {
        public string? InvoiceCode { get; set; }
        public DateTime? InvoiceDate { get; set; }
        public string? Language { get; set; }
        public int? IdCurrency { get; set; }
        public int? IdAgent { get; set; }
        public string? AgentCode { get; set; }
        public int? IdCountry { get; set; }
        public string? AttendedByName { get; set; }
        public string? AttendedByEmail { get; set; }
        public List<GetInvoiceAgentListResponseDto>? InvoiceAgentList { get; set; }
    }
    public class AddOrUpdateSubscriberInvoiceRequestDto
    {
        
        public string? InvoiceCode { get; set; }
        public DateTime? InvoiceDate { get; set; }
        public string? Language { get; set; }
        public int? IdCurrency { get; set; }
        public int? IdCountry { get; set; }
        public int? IdSubscriber { get; set; }

        public decimal? ExchangeRate { get; set; }
        public string? SubscriberCode { get; set; }
        public string? AttendedByName { get; set; }
        public string? AttendedByEmail { get; set; }
        public string? TaxTypeCode { get; set; }
        public decimal? Igv { get; set; }
        public string? Address { get; set; }
        public string? AttendedBy { get; set; }
        public List<GetInvoiceSubscriberListByBillResponseDto>? InvoiceSubscriberList { get; set; }
        
    }
    public class AddOrUpdateSubscriberInvoiceCCRequestDto
    {
        public string? InvoiceCode { get; set; }
        public DateTime? InvoiceDate { get; set; }
        public string? Language { get; set; }
        public int? IdCurrency { get; set; }
        public int? IdCountry{ get; set; }
        public int? IdSubscriber { get; set; }

        public decimal? ExchangeRate { get; set; }
        public string? SubscriberCode { get; set; }
        public string? AttendedByName { get; set; }
        public string? AttendedByEmail { get; set; }
        public string? TaxTypeCode { get; set; }
        public decimal? Igv { get; set; }
        public string? Address { get; set; }
        public string? AttendedBy { get; set; }
        public int? Quantity { get; set; }
        public decimal? TotalPrice { get; set; }
        public List<InvoiceSubscriberCCHistory> Details { get; set; }
    }

    public class GetSubscriberPricesDto
    {
        public decimal PriceT1 { get; set; }
        public decimal PriceT2 { get; set; }
        public decimal PriceT3 { get; set; }
    }
}

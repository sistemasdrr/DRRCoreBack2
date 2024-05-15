namespace DRRCore.Application.DTO.Core.Response
{
    public class GetAgentInvoiceListResponseDto
    {
        public int Id { get; set; }
        public string? InvoiceCode { get; set; }
        public int? IdAgent { get; set; }
        public string? AgentCode { get; set; }
        public string? AgentName { get; set; }
        public int? IdCurrency { get; set; }
        public List<AgentInvoiceDetailsDto>? Details { get; set; } 
    }

    public class AgentInvoiceDetailsDto
    {
        public int Id { get; set; }
        public int? IdAgentInvoice { get; set; }
        public string? RequestedName { get; set; }
        public string? BusinessName { get; set; }
        public string? OrderDate { get; set; }
        public string? ShippingDate { get; set; }
        public string? ExpireDate { get; set; }
        public int? IdCountry { get; set; }
        public string? Country { get; set; }
        public string? FlagCountry { get; set; }
        public string? ProcedureType { get; set; }
        public string? Quality { get; set; }
        public decimal? Price { get; set; }
    }
}

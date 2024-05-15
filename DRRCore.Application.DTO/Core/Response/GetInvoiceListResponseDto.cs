namespace DRRCore.Application.DTO.Core.Response
{
    public class GetInvoiceSubscriberListResponseDto
    {
        public int IdTicket { get; set; }
        public string Number { get; set; }
        public string? RequestedName { get; set; }
        public string? DispatchedName { get; set; }
        public string? OrderDate { get; set; }
        public string? ExpireDate { get; set; }
        public string? DispatchDate { get; set; }
        public string? ProcedureType { get; set; }
        public string? ReportType { get; set; }
        public int? IdCountry { get; set; }
        public string? Country { get; set; }
        public string? FlagCountry { get; set; }
        public decimal? Price { get; set; }
        public int? IdSubscriber { get; set; }
        public string? SubscriberName { get; set; }
        public string? SubscriberCode { get; set;}
        public int? IdInvoiceState { get; set; }

    }
    public class GetInvoiceAgentListResponseDto
    {
        public int? IdTicket { get; set; }
        public int IdTicketHistory { get; set; }
        public string Number { get; set; }
        public string? RequestedName { get; set; }
        public string? DispatchedName { get; set; }
        public string? OrderDate { get; set; }
        public string? ExpireDate { get; set; }
        public string? ShippingDate { get; set; }
        public string? ProcedureType { get; set; }
        public string? ReportType { get; set; }
        public int? IdCountry { get; set; }
        public string? Country { get; set; }
        public string? FlagCountry { get; set; }
        public decimal? Price { get; set; }
        public int? IdAgent{ get; set; }
        public string? AgentName { get; set; }
        public string? AgentCode { get; set; }
    }

}

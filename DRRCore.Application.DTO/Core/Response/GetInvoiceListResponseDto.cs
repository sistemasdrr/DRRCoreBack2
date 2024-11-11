namespace DRRCore.Application.DTO.Core.Response
{
    public class GetInvoiceSubscriberListByBillResponseDto
    {
        public int IdTicket { get; set; }
        public string? Number { get; set; }
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
    public class GetInvoiceSubscriberCCListByBillResponseDto
    {
        public int? IdSubscriber { get; set; }
        public string? Name { get; set; }
        public string? Code { get; set; }
        public string? Country { get; set; }
        public string? FlagCountry { get; set; }
        public List<InvoiceSubscriberCCHistory>? History { get; set; }

    }
    public class AddInvoiceSubscriberCC
    {
        public int? IdInvoice { get; set; }
    }
    public class InvoiceSubscriberCCHistory
    {
        public int? Id{ get; set; }
        public decimal? CouponAmount {  get; set; }
        public decimal? UnitPrice { get; set; }
        public decimal? TotalPrice { get; set; }
        public string? PurchaseDate{ get; set; }
    }

    public class GetInvoiceSubscriberListToCollectResponseDto
    {
        public int Id { get; set; }
        public string? InvoiceCode { get; set; }
        public int? IdCurrency { get; set; }
        public int? IdSubscriber { get; set; }
        public string? SubscriberName { get; set; }
        public string? SubscriberCode { get; set; }
        public DateTime? InvoiceEmitDate { get; set; }
        public List<GetInvoiceDetailsSubscriberListResponseDto>? Details { get; set; }
    }
    public class GetInvoiceSubscriberCCListToCollectResponseDto
    {
        public int Id { get; set; }
        public string? InvoiceCode { get; set; }
        public int? IdCurrency { get; set; }
        public int? IdSubscriber { get; set; }
        public string? SubscriberName { get; set; }
        public string? SubscriberCode { get; set; }
        public DateTime? InvoiceEmitDate { get; set; }
        public int? Quantity { get; set; }
        public decimal? TotalPrice { get; set; }
    }
    public class GetInvoiceSubscriberListPaidsResponseDto
    {
        public int Id { get; set; }
        public string? InvoiceCode { get; set; }
        public int? IdCurrency { get; set; }
        public int? IdSubscriber { get; set; }
        public string? SubscriberName { get; set; }
        public string? SubscriberCode { get; set; }
        public DateTime? InvoiceEmitDate { get; set; }
        public List<GetInvoiceDetailsSubscriberListResponseDto>? Details { get; set; }
    }
    public class GetInvoiceSubscriberCCListPaidsResponseDto
    {
        public int Id { get; set; }
        public string? InvoiceCode { get; set; }
        public int? IdCurrency { get; set; }
        public int? IdSubscriber { get; set; }
        public string? SubscriberName { get; set; }
        public string? SubscriberCode { get; set; }
        public DateTime? InvoiceEmitDate { get; set; }
        public int? Quantity { get; set; }
        public decimal? TotalPrice { get; set; }
    }
    public class GetInvoiceSubscriberccListPaidsResponseDto
    {
        public int Id { get; set; }
        public string? InvoiceCode { get; set; }
        public int? IdCurrency { get; set; }
        public int? IdSubscriber { get; set; }
        public string? SubscriberName { get; set; }
        public string? SubscriberCode { get; set; }
        public DateTime? InvoiceEmitDate { get; set; }
        public DateTime? InvoiceCancelDate { get; set; }
        public int? Quantity { get; set; }
        public decimal? TotalPrice { get; set; }
    }
    public class GetInvoiceDetailsSubscriberListResponseDto
    {
        public int IdSubscriberInvoiceDetails { get; set; }
        public int? IdSubscriberInvoice { get; set; }
        public int? IdTicket { get; set; }
        public string? Number { get; set; }
        public string? RequestedName { get; set; }
        public string? OrderDate { get; set; }
        public string? DispatchDate { get; set; }
        public string? ReferenceNUmber { get; set; }
        public int? IdCountry { get; set; }
        public string? Country { get; set; }
        public string? FlagCountry { get; set; }
        public string? ProcedureType { get; set; }
        public string? ReportType { get; set; }
        public decimal? Price { get; set; }
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
        public string? Quality { get; set; }
    }

}

﻿using DRRCore.Application.DTO.Core.Response;

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
        public int? IdSubscriber { get; set; }
        public string? AttendedByName { get; set; }
        public string? AttendedByEmail { get; set; }
        public List<GetInvoiceSubscriberListByBillResponseDto>? InvoiceSubscriberList { get; set; }
        
    }
}

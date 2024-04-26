using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DRRCore.Application.DTO.Core.Response
{
    public class GetSubscriberResponseDto
    {
        public int Id { get; set; } = new int();
        public string Code { get; set; } = string.Empty;
        public int IdContinent { get; set; } = new int();
        public int IdCountry { get; set; } = new int();
        public string City { get; set; } = string.Empty;
        public string StartDate { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
        public string Acronym { get; set; } = string.Empty;
        public string Address { get; set; } = string.Empty;
        public string Language { get; set; } = string.Empty;
        public string Telephone { get; set; } = string.Empty;
        public string Fax { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string WebPage { get; set; } = string.Empty;
        public string PrincipalContact { get; set; } = string.Empty;
        public int IdSubscriberCategory { get; set; } = new int();
        public string TaxRegistration { get; set; } = string.Empty;
        public string SendReportToName { get; set; } = string.Empty;
        public string SendReportToTelephone { get; set; } = string.Empty;
        public string SendReportToEmail { get; set; } = string.Empty;
        public string SendInvoiceToName { get; set; } = string.Empty;
        public string SendInvoiceToTelephone { get; set; } = string.Empty;
        public string SendInvoiceToEmail { get; set; } = string.Empty;
        public string AdditionalContactName { get; set; } = string.Empty;
        public string AdditionalContactTelephone { get; set; } = string.Empty;
        public string AdditionalContactEmail { get; set; } = string.Empty;
        public string Observations { get; set; } = string.Empty;
        public string Indications { get; set; } = string.Empty;
        public Boolean MaximumCredit { get; set; } = new Boolean();
        public Boolean RevealName { get; set; } = new Boolean();
        public string SubscriberType { get; set; } = string.Empty;
        public int IdCurrency { get; set; } = new int();
        public string FacturationType { get; set; } = string.Empty;
        public int RemainingCoupons { get; set; } = 0;
        public Boolean NormalPrice { get; set; } = new Boolean();
        public Boolean Enable { get; set; } = new Boolean();
    }
}

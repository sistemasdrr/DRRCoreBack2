namespace DRRCore.Application.DTO.Core.Request
{
    public class AddOrUpdateSubscriberRequestDto
    {
        public int Id { get; set; }

        public string? Code { get; set; }

        public int? IdContinent { get; set; }

        public int? IdCountry { get; set; }

        public string? City { get; set; }

        public string? StartDate { get; set; }

        public string? Name { get; set; }

        public string? Acronym { get; set; }
      

        public string? Address { get; set; }

        public string? Language { get; set; }

        public string? Telephone { get; set; }

        public string? Fax { get; set; }

        public string? Email { get; set; }

        public string? WebPage { get; set; }

        public string? PrincipalContact { get; set; }

        public int? IdSubscriberCategory { get; set; }

        public string? TaxRegistration { get; set; }

        public string? SendReportToName { get; set; }

        public string? SendReportToTelephone { get; set; }

        public string? SendReportToEmail { get; set; }

        public string? SendInvoiceToName { get; set; }

        public string? SendInvoiceToTelephone { get; set; }

        public string? SendInvoiceToEmail { get; set; }

        public string? AdditionalContactName { get; set; }

        public string? AdditionalContactTelephone { get; set; }

        public string? AdditionalContactEmail { get; set; }

        public string? Observations { get; set; }

        public string? Indications { get; set; }

        public bool? MaximumCredit { get; set; }

        public bool? RevealName { get; set; }

        public string? SubscriberType { get; set; }

        public int? IdCurrency { get; set; }

        public string? FacturationType { get; set; }

        public bool? NormalPrice { get; set; }

        public int? LastUpdateUser { get; set; }

    }
}

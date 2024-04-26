namespace DRRCore.Application.DTO.Core.Response
{
    public class GetListProviderResponseDto
    {
        public int Id { get; set; }
        public int IdCompany { get; set; }
        public int? IdPerson { get; set; }
        public string? Name { get; set; }
        public int? IdCountry { get; set; }
        public string? Country { get; set; }
        public string? FlagCountry { get; set; }
        public string? Qualification { get; set; }
        public string? QualificationEng { get; set; }
        public string? Date { get; set; }
        public string? Telephone { get; set; }
        public string? AttendedBy { get; set; }
        public int? IdCurrency { get; set; }
        public string? MaximumAmount { get; set; }
        public string? MaximumAmountEng { get; set; }
        public string? TimeLimit { get; set; }
        public string? TimeLimitEng { get; set; }
        public string? Compliance { get; set; }
        public string? ComplianceEng { get; set; }
        public string? ClientSince { get; set; }
        public string? ClientSinceEng { get; set; }
        public string? ProductsTheySell { get; set; }
        public string? ProductsTheySellEng { get; set; }
        public string? AdditionalCommentary { get; set; }
        public string? AdditionalCommentaryEng { get; set; }
        public string? ReferentCommentary { get; set; }
        public int? IdTicket { get; set; }
        public string? ReferentName { get; set; }
        public string? DateReferent { get; set; }
        public string? Ticket { get; set; }
        public bool? Enable { get; set; }
    }
    public class GetListProviderResponseDto2
    {
        public int Id { get; set; }

        public int? IdCompany { get; set; }

        public int? IdPerson { get; set; }

        public string? Name { get; set; }

        public int? IdCountry { get; set; }

        public string? Qualification { get; set; }

        public string? Date { get; set; }

        public string? Telephone { get; set; }

        public string? AttendedBy { get; set; }

        public int? IdCurrency { get; set; }

        public string? MaximumAmount { get; set; }

        public string? MaximumAmountEng { get; set; }

        public string? TimeLimit { get; set; }

        public string? TimeLimitEng { get; set; }

        public string? Compliance { get; set; }

        public string? ComplianceEng { get; set; }

        public string? ClientSince { get; set; }

        public string? ClientSinceEng { get; set; }

        public string? ProductsTheySell { get; set; }

        public string? ProductsTheySellEng { get; set; }

        public string? AdditionalCommentary { get; set; }

        public string? AdditionalCommentaryEng { get; set; }

        public string? ReferentCommentary { get; set; }

        public string? QualificationEng { get; set; }
        public int? IdTicket { get; set; }
        public string? ReferentName { get; set; }
        public string? DateReferent { get; set; }
        public string? Ticket { get; set; }
    }

    public class GetShortProviderByTicket
    {
        public int Id { get; set; }
        public int? IdCompany { get; set; }
        public int? IdPerson { get; set; }
        public string? Name { get; set; }
        public string? Telephone { get; set; }
        public string? Country { get; set; }
        public string? FlagCountry { get; set; }
    }
}

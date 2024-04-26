namespace DRRCore.Application.DTO.Core.Response
{
    public class GetListPersonPartnerResponseDto
    {
        public int Id { get; set; }

        public int? IdCompany { get; set; }

        public int? IdPerson { get; set; }

        public string? Name { get; set; }

        public string? Country { get; set; }

        public string? FlagCountry { get; set; }

        public string? TaxTypeName { get; set; }

        public string? TaxTypeCode { get; set; }

        public string? Situation { get; set; }

        public bool? MainExecutive { get; set; }

        public string? Profession { get; set; }

        public string? ConstitutionDate { get; set; }
    }
}

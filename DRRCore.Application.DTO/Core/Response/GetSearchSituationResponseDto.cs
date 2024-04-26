namespace DRRCore.Application.DTO.Core.Response
{
    public class GetSearchSituationResponseDto
    {
        public int? IdCompany { get; set; }
        public int? IdPerson { get; set; }

        public string? OldCode { get; set; }
        public string? Name { get; set; }
        public string? TaxName { get; set; }
        public string? TaxCode { get; set; }
        public string? Telephone { get; set; }
        public int? IdCountry { get; set; }
        public string? Country { get; set; }
        public string? FlagCountry { get; set; }

    }
}

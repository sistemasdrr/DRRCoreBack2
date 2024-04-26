namespace DRRCore.Application.DTO.Core.Response
{
    public class GetListCompanyRelationResponseDto
    {
        public int Id { get; set; }

        public int? IdCompany { get; set; }

        public int? IdCompanyRelation { get; set; }
        public string? Name { get; set; }
        public string? Country { get; set; }
        public string? FlagCountry { get; set; }
        public string? TaxTypeName { get; set; }
        public string? TaxTypeCode { get; set; }
        public string? ConstitutionDate { get; set; }
        public string? Situation{ get; set; }
    }
}

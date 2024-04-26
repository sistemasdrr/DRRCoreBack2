namespace DRRCore.Application.DTO.Core.Response
{
    public class GetListCompanyShareHolderResponseDto
    {
        public int Id { get; set; }

        public int? IdCompany { get; set; }

        public int? IdCompanyShareHolder { get; set; }

        public string? Name { get; set; }

        public string? Country{ get; set; }

        public string? FlagCountry{ get; set; }

        public string? TaxTypeName { get; set; }

        public string? TaxTypeCode { get; set; }

        public string? Relation { get; set; }

        public int? Participation { get; set; }

        public string? StartDate { get; set; }
    }
}

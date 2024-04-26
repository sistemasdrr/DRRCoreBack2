namespace DRRCore.Application.DTO.Core.Response
{
    public class GetCompanySearchResponseDto
    {
        public int Id { get; set; }
        public string? OldCode { get; set; }
        public string Name { get; set; } = null!;
        public string? SocialName { get; set; }
        public string? LastSearched { get; set; }
        public string? Language { get; set; }
        public string? YearFundation { get; set; }
        public string? Quality { get; set; }
        public string? TaxTypeName { get; set; }
        public string? TaxTypeCode { get; set; }
        public string? Address { get; set; }
        public string? Place { get; set; }
        public int? IdCountry { get; set; }
        public string? Country{ get; set; }
        public string? FlagCountry { get; set; }
        public string? HaveBalance { get; set; }
        public string? BalanceDate { get; set; }

    }
}

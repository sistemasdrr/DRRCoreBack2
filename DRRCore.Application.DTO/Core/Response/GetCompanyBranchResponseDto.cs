using DRRCore.Application.DTO.Core.Request;

namespace DRRCore.Application.DTO.Core.Response
{
    public class GetCompanyBranchResponseDto
    {
        public int Id { get; set; }

        public int? IdCompany { get; set; }

        public int? IdBranchSector { get; set; }

        public int? IdBusinessBranch { get; set; }

        public bool? Import { get; set; }

        public bool? Export { get; set; }

        public decimal? CashSalePercentage { get; set; }

        public string? CashSaleComentary { get; set; }

        public decimal? CreditSalePercentage { get; set; }

        public string? CreditSaleComentary { get; set; }

        public decimal? TerritorySalePercentage { get; set; }

        public string? TerritorySaleComentary { get; set; }

        public decimal? AbroadSalePercentage { get; set; }

        public string? AbroadSaleComentary { get; set; }

        public decimal? NationalPurchasesPercentage { get; set; }

        public string? NationalPurchasesComentary { get; set; }

        public decimal? InternationalPurchasesPercentage { get; set; }

        public string? InternationalPurchasesComentary { get; set; }

        public int? WorkerNumber { get; set; }

        public int? IdLandOwnership { get; set; }

        public string? TotalArea { get; set; }

        public string? PreviousAddress { get; set; }

        public string? OtherLocations { get; set; }

        public string? ActivityDetailCommentary { get; set; }

        public string? AditionalCommentary { get; set; }

        public string? TabCommentary { get; set; }

        public string? CountriesExport { get; set; }

        public string? CountriesImport { get; set; }

        public string? CountriesExportEng { get; set; }

        public string? CountriesImportEng { get; set; }

        public string? SpecificActivities { get; set; }
        public string? SpecificActivitiesEng { get; set; }
        public List<TraductionDto> Traductions { get; set; } = new List<TraductionDto>();
    }
}

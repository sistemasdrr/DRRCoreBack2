using System;
using System.Collections.Generic;

namespace DRRCore.Domain.Entities.SqlCoreContext;

public partial class CompanyBranch
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

    public DateTime CreationDate { get; set; }

    public DateTime? UpdateDate { get; set; }

    public DateTime? DeleteDate { get; set; }

    public bool? Enable { get; set; }

    public string? CountriesExport { get; set; }

    public string? CountriesImport { get; set; }

    public string? SpecificActivities { get; set; }

    public string? SpecificActivitiesEng { get; set; }

    public string? CountriesImportEng { get; set; }

    public string? CountriesExportEng { get; set; }

    public virtual ICollection<CompanyBusineesActivity> CompanyBusineesActivities { get; set; } = new List<CompanyBusineesActivity>();

    public virtual BranchSector? IdBranchSectorNavigation { get; set; }

    public virtual BusinessBranch? IdBusinessBranchNavigation { get; set; }

    public virtual Company? IdCompanyNavigation { get; set; }

    public virtual LandOwnership? IdLandOwnershipNavigation { get; set; }
}

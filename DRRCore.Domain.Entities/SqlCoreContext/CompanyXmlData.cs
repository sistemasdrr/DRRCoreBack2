using System.ComponentModel.DataAnnotations;

namespace DRRCore.Domain.Entities.SqlCoreContext
{
    public class CompanyXmlData
    {
        public int TicketNumber { get; set; }
        public string? DebtorName { get; set; }
        public string? DebtorCountry { get; set; }
        public string? ProviderReportReference { get; set; }
        public string? ReportDefaultCurrency { get; set; }
        public string? ReportDefaultMonetaryFactorCode { get; set; }
        public string? Language { get; set; }
        public string? TaxIdentificationKey { get; set; }
        public string? TaxIdentificationCategory { get; set; }
        public string? CommerceNumberIdentificationKey { get; set; }
        public string? CommerceNumberIdentificationCategory{ get; set; }
        public string? NationalNumberIdentificationKey { get; set; }
        public string? NationalNumberIdentificationCategory { get; set; }
        public string? SourceIdentificationKey { get; set; }
        public string? SourceIdentificationCategory { get; set; }
        public string? OperatingStatus { get; set; }
        public string? OperatingStatusObservationDate { get; set; }
        public string? CompanyName { get; set; }
        public string? CompanyNameType { get; set; }
        public string? LanguageAndAlphabetType { get; set; }
        public string? CompanyTradName { get; set; }
        public string? CompanyTradeNameType { get; set; }
        public string? LanguageAndAlphabetTradeType { get; set; }
        public string? AddressType { get; set; }
        public string? Street { get; set; }
        public string? PostCode { get; set; }
        public string? City { get; set; }
        public string? StateRegion { get; set; }
        public int? Country { get; set;}
        public string? FormerAddressType { get; set; }
        public string? FormerAddresslanguageAndAlphabetType { get; set; }
        public string? FormerAddressStreet { get; set; }
        public int? FormerAddressCountry { get; set; }
        public string? NumberOfEmployeesType { get; set; }
        public int? NumberOfEmployeesWithinTheCompanyRangeFrom { get; set; }
        public int? NumberOfEmployeesWithinTheCompanyRangeTo { get; set; }
        public string? CompanyLegalForm { get; set; }
        public string? ContactEmailAddress { get; set; }
        public string? ContactPrefixPhoneNumber { get; set; }
        public string? ContactPhoneNumber { get; set; }
        public string? ContactWebsiteAddress { get; set; }
        public string? IncorporationDate { get; set; }
        public string? RegistrationDate { get; set; }
        public string? ActivityStartDate { get; set; }
        public string? FoundationDate { get; set; }
        public int? CompanyMainSectorCode { get; set; }
        public string? CompanyMainSectorCodeType { get; set; }
        public string? CompanyMainSectorDescription { get; set; }
        public string? CompanyNature { get; set; }
        public string? CompanyNatureFromProvider { get; set; }
        public string? SourceEvaluationOriginalPaymentExperience { get; set; }
        public int? SourceEvaluationSimplePaymentExperience { get; set; }
        public string? SourceEvaluationExtendedPaymentExperience { get; set; }
        public string? SourceEvaluationCreditAdviceAmount { get; set; }
        public string? SourceEvaluationCreditAdviceExplanation { get; set; }
        public string? SourceEvaluationMaximumCreditAdviceAmount { get; set; }
        public string? SourceEvaluationMaximumSingleCreditAdviceAmount { get; }
        public string? SourceEvaluationCurrency { get; set; }
        public string? SourceRating { get; set; }
        public string? SourceRatingRange { get; set; }
        public string? SourceRatingComments { get; set; }
        public string? SourceEvaluationComments { get; set; }
        public string? NormalisedSourceRatingValue { get; set; }
        public string? NormalisedSourceRatingType { get; set; }
        public string? CompanyListedStockExchange { get; set; }
    }
    public class CompanyBalanceData
    {
        public int? CR_FD_keyFigures_accountingPeriod { get; set; }
        public string? CR_FD_keyFigures_startDateOfAccountingPeriod { get; set; }
        public string? CR_FD_keyFigures_endDateOfAccountingPeriod { get; set; }
        public string? CR_FD_keyFigures_typeOfFigures { get; set; }
        public string? CR_FD_keyFigures_balancesheetDefaultCurrency { get; set; }
        public string? CR_FD_keyFigures_auditedBalance { get; set; }
        public string? CR_FD_keyFigures_auditComment { get; set; }
        public string? CR_FD_keyFigures_consolidatedBalanceSheet { get; set; }
        public string? CR_FD_keyFigures_consolidationType { get; set; }
        public string? CR_FD_keyFigures_balancesheetDefaultMonetaryFactorCode { get; set; }
        public string? CR_FD_keyFigures_keyFigure_keyFigureItemCodeTotalAssets { get; set; }
        public decimal? CR_FD_keyFigures_keyFigure_keyFigureItemValueTotalAssets { get; set; }
        public string? CR_FD_keyFigures_keyFigure_keyFigureUnitPrefixCodeTotalAssets { get; set; }

        public string? CR_FD_keyFigures_keyFigure_keyFigureItemCodeFixedAssets { get; set; }
        public decimal? CR_FD_keyFigures_keyFigure_keyFigureItemValueFixedAssets { get; set; }
        public string? CR_FD_keyFigures_keyFigure_keyFigureUnitPrefixCodeFixedAssets { get; set; }

        public string? CR_FD_keyFigures_keyFigure_keyFigureItemCodeCurrentAssets { get; set; }
        public decimal? CR_FD_keyFigures_keyFigure_keyFigureItemValueCurrentAssets { get; set; }
        public string? CR_FD_keyFigures_keyFigure_keyFigureUnitPrefixCodeCurrentAssets { get; set; }

        public string? CR_FD_keyFigures_keyFigure_keyFigureItemCodeNonCurrentAssets { get; set; }
        public decimal? CR_FD_keyFigures_keyFigure_keyFigureItemValueNonCurrentAssets { get; set; }
        public string? CR_FD_keyFigures_keyFigure_keyFigureUnitPrefixCodeNonCurrentAssets { get; set; }

        public string? CR_FD_keyFigures_keyFigure_keyFigureItemCodeTotalEquityLiabilities { get; set; }
        public decimal? CR_FD_keyFigures_keyFigure_keyFigureItemValueCodeTotalEquityLiabilities { get; set; }
        public string? CR_FD_keyFigures_keyFigure_keyFigureUnitPrefixCodeCodeTotalEquityLiabilities { get; set; }

        public string? CR_FD_keyFigures_keyFigure_keyFigureItemCodeEquity { get; set; }
        public decimal? CR_FD_keyFigures_keyFigure_keyFigureItemValueEquity { get; set; }
        public string? CR_FD_keyFigures_keyFigure_keyFigureUnitPrefixCodeEquity { get; set; }

        public string? CR_FD_keyFigures_keyFigure_keyFigureItemCodeEquityPaiduPCapital { get; set; }
        public decimal? CR_FD_keyFigures_keyFigure_keyFigureItemValueEquityPaiduPCapital { get; set; }
        public string? CR_FD_keyFigures_keyFigure_keyFigureUnitPrefixCodeEquityPaiduPCapital { get; set; }

        public string? CR_FD_keyFigures_keyFigure_keyFigureItemCodeLTLiabilities { get; set; }
        public decimal? CR_FD_keyFigures_keyFigure_keyFigureItemValueLTLiabilities { get; set; }
        public string? CR_FD_keyFigures_keyFigure_keyFigureUnitPrefixCodeLTLiabilities { get; set; }

        public string? CR_FD_keyFigures_keyFigure_keyFigureItemCodeSTLiabilities { get; set; }
        public decimal? CR_FD_keyFigures_keyFigure_keyFigureItemValueSTLiabilities { get; set; }
        public string? CR_FD_keyFigures_keyFigure_keyFigureUnitPrefixCodeSTLiabilities { get; set; }

        public string? CR_FD_keyFigures_keyFigure_keyFigureItemCodeEquityRevenueSales { get; set; }
        public decimal? CR_FD_keyFigures_keyFigure_keyFigureItemValueEquityRevenueSales { get; set; }
        public string? CR_FD_keyFigures_keyFigure_keyFigureUnitPrefixCodeEquityRevenueSales { get; set; }

        public string? CR_FD_keyFigures_keyFigure_keyFigureItemCodeEquityNetResult { get; set; }
        public decimal? CR_FD_keyFigures_keyFigure_keyFigureItemValueEquityNetResult { get; set; }
        public string? CR_FD_keyFigures_keyFigure_keyFigureUnitPrefixCodeEquityNetResult { get; set; }
    }
    public class CompanyFunctionData
    {
        public string? FunctionType { get; set; }
        public string? NameOfPerson { get; set; }
    }
    public class CompanyLegalEventsData
    {
        public string? LegalEvent { get; set; }
        public string? SourceEvent { get; set; }
        public string? EndDate { get; set; }
        public string? StartDate { get; set; }
    }
    public class CompanyRelatedData
    {
        public string? RelatedName { get; set; }
        public string? RelatedTaxReg { get; set; }
        public string? RelationType { get; set; }
        public int? RelatedCountry { get; set; }
        public string? DateInc { get; set; }
    }
    public class CompanyShareholderSP
    {
        public string? Name { get; set; }
        public string? Title{ get; set; }
        public int? Participation{ get; set; }
        public int? ExecPrinc { get; set; }
        public string? StartDate { get; set; }
    }
    public class WhoIsWhoSP
    {
        public int Id { get; set; }
        public string? Fullname { get; set; }
        public string? Nacionality { get; set; }
        public string? birthDate { get; set; }
        public string? IdentificationDoc { get; set; }
        public string? civilStatus { get; set; }
        public string? Address { get; set; }
        public string? CodePhone { get; set; }
        public string? NumberPhone { get; set; }
        public string? cellPhone { get; set; }
        public string? TaxName { get; set; }
        public string? TaxCode { get; set; }
        public string? LegalRegisterSituation { get; set; }
        public string? Country { get; set; }
        public string? TradeName { get; set; }
        public string? Profession { get; set; }
        public string? FatherName { get; set; }
        public string? MotherName { get; set; }
        public string? Email { get; set; }
        public string? OtherDirecctions { get; set; }
        public string? History { get; set; }
        public string? References { get; set; }
        public string? Properties { get; set; }
        public string? BirthPlace { get; set; }
    }
}

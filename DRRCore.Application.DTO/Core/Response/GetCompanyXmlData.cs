namespace DRRCore.Application.DTO.Core.Response
{
    public class GetCompanyXmlData
    {
        public string? DebtorName { get; set; }
        public string? DebtorCountry { get; set; }
        public string? ProviderReportReference { get; set; }
        public string? ReportDefaultCurrency { get; set; }
        public string? ReportDefaultMonetaryFactorCode { get; set; }
        public string? Language { get; set; }
        public string? TaxIdentificationKey { get; set; }
        public string? TaxIdentificationCategory { get; set; }
        public string? CommerceNumberIdentificationKey { get; set; }
        public string? CommerceNumberIdentificationCategory { get; set; }
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
        public string? City { get; }
        public string? StateRegion { get; set; }
        public int? Country { get; set; }
        public string? FormerAddressType { get; set; }
        public string? FormerAddresslanguageAndAlphabetType { get; }
        public int? FormerAddressCountry { get; }
        public string? NumberOfEmployeesType { get; }
        public string? NumberOfEmployeesWithinTheCompanyRangeFrom { get; }
        public string? NumberOfEmployeesWithinTheCompanyRangeTo { get; }
        public string? CompanyLegalForm { get; }
        public string? ContactEmailAddress { get; }
        public string? ContactPrefixPhoneNumber { get; }
        public string? ContactPhoneNumber { get; }
        public string? ContactWebsiteAddress { get; }
        public string? IncorporationDate { get; }
        public string? RegistrationDate { get; }
        public string? ActivityStartDate { get; }
        public string? FoundationDate { get; }
        public string? CompanyMainSectorCode { get; }
        public string? CompanyMainSectorCodeType { get; }
        public string? CompanyMainSectorDescription { get; }
        public string? CompanyNature { get; }
        public string? CompanyNatureFromProvider { get; }
        public string? SourceEvaluationOriginalPaymentExperience { get; }
        public int? SourceEvaluationSimplePaymentExperience { get; }
        public string? SourceEvaluationExtendedPaymentExperience { get; }
        public string? SourceEvaluationCreditAdviceAmount { get; }
        public string? SourceEvaluationCreditAdviceExplanation { get; }
        public string? SourceEvaluationMaximumCreditAdviceAmount { get; }
        public string? SourceEvaluationMaximumSingleCreditAdviceAmount { get; }
        public string? SourceEvaluationCurrency { get; }
        public string? SourceRating { get; }
        public string? SourceRatingRange { get; }
        public string? SourceRatingComments { get; }
        public string? SourceEvaluationComments { get; }
        public string? NormalisedSourceRatingValue { get; }
        public string? NormalisedSourceRatingType { get; }
        public string? CompanyListedStockExchange { get; }
    }
}

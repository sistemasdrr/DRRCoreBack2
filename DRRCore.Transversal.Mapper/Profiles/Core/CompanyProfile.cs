using AutoMapper;
using DRRCore.Application.DTO.Core.Request;
using DRRCore.Application.DTO.Core.Response;
using DRRCore.Domain.Entities.SQLContext;
using DRRCore.Domain.Entities.SqlCoreContext;
using DRRCore.Transversal.Common;
using Microsoft.IdentityModel.Tokens;

namespace DRRCore.Transversal.Mapper.Profiles.Core
{
    public class CompanyProfile : Profile
    {
        public CompanyProfile() {

            CreateMap<AddOrUpdateCompanyRequestDto, Company>()
                   .ForMember(dest => dest.IdLegalPersonType, opt => opt?.MapFrom(src => src.IdLegalPersonType == 0 ? null : src.IdLegalPersonType))
                  .ForMember(dest => dest.IdLegalRegisterSituation, opt => opt?.MapFrom(src => src.IdLegalRegisterSituation == 0 ? null : src.IdLegalRegisterSituation))
                  .ForMember(dest => dest.IdCreditRisk, opt => opt?.MapFrom(src => src.IdCreditRisk == 0 ? null : src.IdCreditRisk))
                  .ForMember(dest => dest.IdPaymentPolicy, opt => opt?.MapFrom(src => src.IdPaymentPolicy == 0 ? null : src.IdPaymentPolicy))
                  .ForMember(dest => dest.IdReputation, opt => opt?.MapFrom(src => src.IdReputation == 0 ? null : src.IdReputation))
                  .ForMember(dest => dest.IdCountry, opt => opt?.MapFrom(src => src.IdCountry==0?null:src.IdCountry))
                   .ForMember(dest => dest.LastSearched, opt => opt?.MapFrom(src => StaticFunctions.VerifyDate(src.LastSearched)))
                   .ReverseMap();
            CreateMap<AddOrUpdateCompanyBackgroundRequestDto, CompanyBackground>()

                   .ForMember(dest => dest.Currency, opt => opt?.MapFrom(src => src.Currency == 0 ? null : src.Currency))
                   .ForMember(dest => dest.CurrentPaidCapitalCurrency, opt => opt?.MapFrom(src => src.CurrentPaidCapitalCurrency == 0 ? null : src.CurrentPaidCapitalCurrency))
                  .ForMember(dest => dest.LastQueryRrpp, opt => opt?.MapFrom(src => StaticFunctions.VerifyDate(src.LastQueryRrpp)))
                  .ForMember(dest => dest.ConstitutionDate, opt => opt?.MapFrom(src => StaticFunctions.VerifyDate(src.ConstitutionDate)))
                  .ReverseMap();
            CreateMap<AddOrUpdateCompanyBranchRequestDto, CompanyBranch>()
                  .ForMember(dest => dest.IdCompany, opt => opt?.MapFrom(src => src.IdCompany == 0 ? null : src.IdCompany))
                  .ForMember(dest => dest.IdBranchSector, opt => opt?.MapFrom(src => src.IdBranchSector == 0 ? null : src.IdBranchSector))
                  .ForMember(dest => dest.IdBusinessBranch, opt => opt?.MapFrom(src => src.IdBusinessBranch == 0 ? null : src.IdBusinessBranch))
                  .ForMember(dest => dest.IdLandOwnership, opt => opt?.MapFrom(src => src.IdLandOwnership == 0 ? null : src.IdLandOwnership))
                  .ForMember(dest => dest.CountriesExportEng, opt => opt?.MapFrom(src => src.CountriesExportEng))
                  .ForMember(dest => dest.IdLandOwnership, opt => opt?.MapFrom(src => src.IdLandOwnership == 0 ? null : src.IdLandOwnership))
                .ReverseMap();
            CreateMap<AddOrUpdateCompanyFinancialInformationRequestDto, CompanyFinancialInformation>()
                 .ForMember(dest => dest.IdCompany, opt => opt?.MapFrom(src => src.IdCompany == 0 ? null : src.IdCompany))
                 .ForMember(dest => dest.IdCollaborationDegree, opt => opt?.MapFrom(src => src.IdCollaborationDegree == 0 ? null : src.IdCollaborationDegree))
                 .ForMember(dest => dest.IdFinancialSituacion, opt => opt?.MapFrom(src => src.IdFinancialSituacion == 0 ? null : src.IdFinancialSituacion))
                 .ReverseMap();
            CreateMap<CompanyBranch, GetCompanyBranchResponseDto>()
                 .ForMember(dest => dest.Traductions, opt => opt?.MapFrom(src => src.IdCompanyNavigation.Traductions))
                 .ReverseMap();
            CreateMap<TraductionDto, Traduction>()
                 .ReverseMap();
            CreateMap<Company, GetCompanyResponseDto>()
                .ForMember(dest => dest.Enable, opt => opt?.MapFrom(src => src.Enable))
                .ForMember(dest => dest.LastSearched, opt => opt?.MapFrom(src =>StaticFunctions.DateTimeToString(src.LastSearched)))
                .ForMember(dest => dest.OldCode, opt => opt?.MapFrom(src => string.IsNullOrEmpty(src.OldCode)?"N"+src.Id.ToString("D10"):src.OldCode))
                .ForMember(dest => dest.Enable, opt => opt?.MapFrom(src => src.Enable))
                .ForMember(dest => dest.TaxTypeName, opt => opt?.MapFrom(src => src.IdCountryNavigation.TaxTypeName))
                .ForMember(dest => dest.IdContinent, opt => opt?.MapFrom(src => src.IdCountryNavigation.IdContinent))
                .ForMember(dest => dest.TaxTypeByCountry, opt => opt?.MapFrom(src => src.IdCountryNavigation.TaxTypeName))
                .ReverseMap(); 
            CreateMap<Company, GetCompanySearchResponseDto>()
                .ForMember(dest => dest.LastSearched, opt => opt?.MapFrom(src => StaticFunctions.DateTimeToString(src.LastSearched)))
                .ForMember(dest => dest.Name, opt => opt?.MapFrom(src => src.Name))
                .ForMember(dest => dest.SocialName, opt => opt?.MapFrom(src => src.SocialName))
                .ForMember(dest => dest.OldCode, opt => opt?.MapFrom(src => string.IsNullOrEmpty(src.OldCode) ? "N" + src.Id.ToString("D10") : src.OldCode))
                .ForMember(dest => dest.Place, opt => opt?.MapFrom(src => src.Place))
                .ForMember(dest => dest.Address, opt => opt?.MapFrom(src => src.Address))
                .ForMember(dest => dest.YearFundation, opt => opt?.MapFrom(src => src.YearFundation))
                .ForMember(dest => dest.TaxTypeName, opt => opt?.MapFrom(src => src.TaxTypeName.IsNullOrEmpty() == true ? src.IdCountryNavigation.TaxTypeName : src.TaxTypeName))
                .ForMember(dest => dest.IdCountry, opt => opt?.MapFrom(src => src.IdCountry == null ? 0 : src.IdCountry))
                .ForMember(dest => dest.Country, opt => opt?.MapFrom(src => src.IdCountryNavigation == null ? "" : src.IdCountryNavigation.Iso))
                .ForMember(dest => dest.FlagCountry, opt => opt?.MapFrom(src => src.IdCountryNavigation == null ? "" : src.IdCountryNavigation.FlagIso))
                .ForMember(dest => dest.HaveBalance, opt => opt?.MapFrom(src => src.FinancialBalances.Count() > 0 ? "SI" : "NO"))
                .ForMember(dest => dest.BalanceDate, opt => opt?.MapFrom(src => src.FinancialBalances.Count() > 0 && src.FinancialBalances.OrderByDescending(fb => fb.Date).FirstOrDefault().Date != null ? StaticFunctions.DateTimeToString(src.FinancialBalances.OrderByDescending(fb => fb.Date).FirstOrDefault().Date) : ""))
                .ReverseMap();
            CreateMap<Company, GetListCompanyResponseDto>()
                .ForMember(dest => dest.Id, opt => opt?.MapFrom(src => src.Id))
                .ForMember(dest => dest.Name, opt => opt?.MapFrom(src => src.Name))
                 .ForMember(dest => dest.Code, opt => opt?.MapFrom(src => string.IsNullOrEmpty(src.OldCode) ? "N" + src.Id.ToString("D10") : src.OldCode))
                .ForMember(dest => dest.CreditRisk, opt => opt?.MapFrom(src => src.IdCreditRiskNavigation!=null?src.IdCreditRiskNavigation.Identifier:string.Empty))
                .ForMember(dest => dest.Language, opt => opt?.MapFrom(src => src.Language))
                .ForMember(dest => dest.Telephone, opt => opt?.MapFrom(src => src.Telephone))
                .ForMember(dest => dest.TaxNumber, opt => opt?.MapFrom(src => src.TaxTypeCode))
                .ForMember(dest => dest.LastReportDate, opt => opt?.MapFrom(src =>StaticFunctions.DateTimeToString(src.LastSearched)))
                .ForMember(dest => dest.Country, opt => opt?.MapFrom(src => src.IdCountryNavigation!=null?src.IdCountryNavigation.Name:string.Empty))
                .ForMember(dest => dest.IsoCountry, opt => opt?.MapFrom(src => src.IdCountryNavigation != null ? src.IdCountryNavigation.Iso : string.Empty))
                .ForMember(dest => dest.FlagCountry, opt => opt?.MapFrom(src => src.IdCountryNavigation != null ? src.IdCountryNavigation.FlagIso : string.Empty))
                .ForMember(dest => dest.Quality, opt => opt?.MapFrom(src => src.Quality))
                //Falta implementar
                .ForMember(dest => dest.TraductionPercentage, opt => opt?.MapFrom(src =>GetTraductionPercentage(src.Traductions)))
                .ForMember(dest => dest.Manager, opt => opt?.MapFrom(src => string.Empty))
                .ReverseMap();

            CreateMap<Ticket, GetListCompanyResponseDto>()
               .ForMember(dest => dest.Id, opt => opt?.MapFrom(src => src.IdCompany))
               .ForMember(dest => dest.Name, opt => opt?.MapFrom(src => src.RequestedName))
               .ForMember(dest => dest.DispatchedName, opt => opt?.MapFrom(src => src.DispatchedName))
                .ForMember(dest => dest.Telephone, opt => opt?.MapFrom(src => src.Telephone))
               .ForMember(dest => dest.Language, opt => opt?.MapFrom(src => src.Language))  
               .ForMember(dest => dest.Country, opt => opt?.MapFrom(src => src.IdCountryNavigation != null ? src.IdCountryNavigation.Name : string.Empty))
               .ForMember(dest => dest.IsoCountry, opt => opt?.MapFrom(src => src.IdCountryNavigation != null ? src.IdCountryNavigation.Iso : string.Empty))
               .ForMember(dest => dest.FlagCountry, opt => opt?.MapFrom(src => src.IdCountryNavigation != null ? src.IdCountryNavigation.FlagIso : string.Empty))
               .ReverseMap();

          

            CreateMap<Traduction, TraductionDto>()
                .ForMember(dest => dest.Key, opt => opt?.MapFrom(src => src.Identifier))
                .ForMember(dest => dest.Value, opt => opt?.MapFrom(src =>src.Identifier.StartsWith("S")?src.ShortValue:src.LargeValue))
                 .ReverseMap();

            CreateMap<CompanyBackground, GetCompanyBackgroundResponseDto>()
                .ForMember(dest => dest.Traductions, opt => opt?.MapFrom(src => src.IdCompanyNavigation.Traductions))
              .ForMember(dest => dest.LastQueryRrpp, opt => opt?.MapFrom(src => StaticFunctions.DateTimeToString(src.LastQueryRrpp)))
              .ForMember(dest => dest.ConstitutionDate, opt => opt?.MapFrom(src => StaticFunctions.DateTimeToString(src.ConstitutionDate)))
              .ReverseMap();
            CreateMap<CompanyFinancialInformation, GetCompanyFinancialInformationResponseDto>()
                .ForMember(dest => dest.Traductions, opt => opt?.MapFrom(src => src.IdCompanyNavigation.Traductions))
              .ReverseMap();
            CreateMap<SalesHistory, GetListSalesHistoryResponseDto>()
                 .ForMember(dest => dest.Date, opt => opt?.MapFrom(src => StaticFunctions.DateTimeToString(src.Date)))
                .ForMember(dest => dest.Currency, opt => opt?.MapFrom(src => src.IdCurrencyNavigation!= null ? src.IdCurrencyNavigation.Abreviation : string.Empty))
                .ForMember(dest => dest.Amount, opt => opt?.MapFrom(src => src.Amount))
                .ForMember(dest => dest.ExchangeRate, opt => opt?.MapFrom(src => src.ExchangeRate))
                .ForMember(dest => dest.EquivalentToDollars, opt => opt?.MapFrom(src => src.EquivalentToDollars))
             .ReverseMap();
            CreateMap<SalesHistory, GetSaleHistoryResponseDto>()
                 .ForMember(dest => dest.IdCompany, opt => opt?.MapFrom(src => src.IdCompany == 0 ? null : src.IdCompany))
                 .ForMember(dest => dest.IdCurrency, opt => opt?.MapFrom(src => src.IdCurrency == 0 ? null : src.IdCurrency))
                 .ForMember(dest => dest.Date, opt => opt?.MapFrom(src => src.Date))
             .ReverseMap();
            CreateMap<AddOrUpdateSaleHistoryRequestDto, SalesHistory>()
                 .ForMember(dest => dest.Date, opt => opt?.MapFrom(src => src.Date))
                 .ForMember(dest => dest.IdCompany, opt => opt?.MapFrom(src => src.IdCompany == 0 ? null : src.IdCompany))
                 .ForMember(dest => dest.IdCurrency, opt => opt?.MapFrom(src => src.IdCurrency == 0 ? null : src.IdCurrency))
             .ReverseMap();
            CreateMap<AddOrUpdateFinancialBalanceRequestDto, FinancialBalance>()
                .ForMember(dest => dest.Date, opt => opt?.MapFrom(src => StaticFunctions.VerifyDate(src.Date)))
                .ForMember(dest => dest.DurationEng, opt => opt?.MapFrom(src => src.DurationEng))
                .ForMember(dest => dest.IdCompany, opt => opt?.MapFrom(src => src.IdCompany == 0 ? null : src.IdCompany))
                .ForMember(dest => dest.IdCurrency, opt => opt?.MapFrom(src => src.IdCurrency == 0 ? null : src.IdCurrency))
            .ReverseMap();
            CreateMap<FinancialBalance, GetFinancialBalanceResponseDto>()
                 .ForMember(dest => dest.IdCompany, opt => opt?.MapFrom(src => src.IdCompany == 0 ? null : src.IdCompany))
                 .ForMember(dest => dest.IdCurrency, opt => opt?.MapFrom(src => src.IdCurrency == 0 ? null : src.IdCurrency))
                 .ForMember(dest => dest.Date, opt => opt?.MapFrom(src => StaticFunctions.DateTimeToString(src.Date)))
             .ReverseMap();
            CreateMap<FinancialBalance, GetComboValueResponseDto>()
                 .ForMember(dest => dest.Id, opt => opt?.MapFrom(src => src.Id))
                 .ForMember(dest => dest.Valor, opt => opt?.MapFrom(src => StaticFunctions.DateTimeToString(src.Date)))
             .ReverseMap();
            CreateMap<AddOrUpdateProviderRequestDto, Provider>()
                .ForMember(dest => dest.IdCompany, opt => opt?.MapFrom(src => src.IdCompany == 0 ? null : src.IdCompany))
                 .ForMember(dest => dest.IdPerson, opt => opt?.MapFrom(src => src.IdPerson == 0 ? null : src.IdPerson))
                .ForMember(dest => dest.Date, opt => opt?.MapFrom(src => StaticFunctions.VerifyDate(src.Date)))
                .ForMember(dest => dest.IdCurrency, opt => opt?.MapFrom(src => src.IdCurrency == 0 ? null : src.IdCurrency))
                .ForMember(dest => dest.IdCountry, opt => opt?.MapFrom(src => src.IdCountry == 0 ? null : src.IdCountry))
             .ReverseMap(); 
            CreateMap<Provider, GetProviderResponseDto>()
                 .ForMember(dest => dest.IdCompany, opt => opt?.MapFrom(src => src.IdCompany == 0 ? null : src.IdCompany))
                 .ForMember(dest => dest.IdPerson, opt => opt?.MapFrom(src => src.IdPerson == 0 ? null : src.IdPerson))
                 .ForMember(dest => dest.IdCountry, opt => opt?.MapFrom(src => src.IdCountry == 0 ? null : src.IdCountry))
                 .ForMember(dest => dest.IdCurrency, opt => opt?.MapFrom(src => src.IdCurrency == 0 ? null : src.IdCurrency))
                 .ForMember(dest => dest.Date, opt => opt?.MapFrom(src => StaticFunctions.DateTimeToString(src.Date)))
                 .ForMember(dest => dest.DateReferent, opt => opt?.MapFrom(src => StaticFunctions.DateTimeToString(src.DateReferent)))
             .ReverseMap();
            CreateMap<Provider, GetShortProviderByTicket>()
                .ForMember(dest => dest.IdCompany, opt => opt?.MapFrom(src => src.IdCompany == null ? 0 : src.IdCompany))
                .ForMember(dest => dest.IdPerson, opt => opt?.MapFrom(src => src.IdPerson == null ? 0 : src.IdPerson))
                .ForMember(dest => dest.Country, opt => opt?.MapFrom(src => src.IdCountryNavigation != null ? src.IdCountryNavigation.Iso : ""))
                .ForMember(dest => dest.FlagCountry, opt => opt?.MapFrom(src => src.IdCountryNavigation != null ? src.IdCountryNavigation.FlagIso : ""))
                .ForMember(dest => dest.Name, opt => opt?.MapFrom(src => src.Name))
                .ForMember(dest => dest.Telephone, opt => opt?.MapFrom(src => src.Telephone))
            .ReverseMap();
            CreateMap<Provider, GetListProviderResponseDto>()
                 .ForMember(dest => dest.IdCompany, opt => opt?.MapFrom(src => src.IdCompany == 0 ? null : src.IdCompany))
                 .ForMember(dest => dest.IdPerson, opt => opt?.MapFrom(src => src.IdPerson == 0 ? null : src.IdPerson))
                 .ForMember(dest => dest.IdCountry, opt => opt?.MapFrom(src => src.IdCountry == 0 ? null : src.IdCountry))

                 .ForMember(dest => dest.Country, opt => opt?.MapFrom(src => src.IdCountryNavigation.Name))
                 .ForMember(dest => dest.FlagCountry, opt => opt?.MapFrom(src => src.IdCountryNavigation.FlagIso))
                 .ForMember(dest => dest.Enable, opt => opt?.MapFrom(src => src.Enable))
                 .ForMember(dest => dest.Date, opt => opt?.MapFrom(src => StaticFunctions.DateTimeToString(src.Date)))
                 .ForMember(dest => dest.DateReferent, opt => opt?.MapFrom(src => StaticFunctions.DateTimeToString(src.DateReferent)))
             .ReverseMap();
          
            CreateMap<AddOrUpdateComercialLatePaymentRequestDto, ComercialLatePayment>()
               .ForMember(dest => dest.IdCompany, opt => opt?.MapFrom(src => src.IdCompany == 0 ? null : src.IdCompany))
                 .ForMember(dest => dest.IdPerson, opt => opt?.MapFrom(src => src.IdPerson == 0 ? null : src.IdPerson))
               .ForMember(dest => dest.Date, opt => opt?.MapFrom(src => src.Date))
               .ForMember(dest => dest.PendingPaymentDate, opt => opt?.MapFrom(src => src.PendingPaymentDate))
           .ReverseMap();
            CreateMap<ComercialLatePayment, GetComercialLatePaymentResponseDto>()
                 .ForMember(dest => dest.IdCompany, opt => opt?.MapFrom(src => src.IdCompany == 0 ? null : src.IdCompany))
                 .ForMember(dest => dest.IdPerson, opt => opt?.MapFrom(src => src.IdPerson == 0 ? null : src.IdPerson))
                 .ForMember(dest => dest.Date, opt => opt?.MapFrom(src => src.Date))
                 .ForMember(dest => dest.PendingPaymentDate, opt => opt?.MapFrom(src => src.PendingPaymentDate))
             .ReverseMap();
            CreateMap<ComercialLatePayment, GetListComercialLatePaymentResponseDto>()
                 .ForMember(dest => dest.IdCompany, opt => opt?.MapFrom(src => src.IdCompany == 0 ? null : src.IdCompany))
                 .ForMember(dest => dest.IdPerson, opt => opt?.MapFrom(src => src.IdPerson == 0 ? null : src.IdPerson))
                 .ForMember(dest => dest.Enable, opt => opt?.MapFrom(src => src.Enable))
                 .ForMember(dest => dest.Date, opt => opt?.MapFrom(src => src.Date))
                 .ForMember(dest => dest.PendingPaymentDate, opt => opt?.MapFrom(src => src.PendingPaymentDate))
             .ReverseMap();
            CreateMap<AddOrUpdateBankDebtRequestDto, BankDebt>()
                 .ForMember(dest => dest.IdCompany, opt => opt?.MapFrom(src => src.IdCompany == 0 ? null : src.IdCompany))
                 .ForMember(dest => dest.IdPerson, opt => opt?.MapFrom(src => src.IdPerson == 0 ? null : src.IdPerson))
               .ForMember(dest => dest.DebtDate, opt => opt?.MapFrom(src => StaticFunctions.VerifyDate(src.DebtDate)))
           .ReverseMap();
            CreateMap<BankDebt, GetBankDebtResponseDto>()
                 .ForMember(dest => dest.IdCompany, opt => opt?.MapFrom(src => src.IdCompany == 0 ? null : src.IdCompany))
                 .ForMember(dest => dest.IdPerson, opt => opt?.MapFrom(src => src.IdPerson == 0 ? null : src.IdPerson))
                 .ForMember(dest => dest.DebtDate, opt => opt?.MapFrom(src => StaticFunctions.DateTimeToString(src.DebtDate)))
             .ReverseMap();
            CreateMap<BankDebt, GetListBankDebtResponseDto>()
                 .ForMember(dest => dest.IdCompany, opt => opt?.MapFrom(src => src.IdCompany == 0 ? null : src.IdCompany))
                 .ForMember(dest => dest.IdPerson, opt => opt?.MapFrom(src => src.IdPerson == 0 ? null : src.IdPerson))
                 .ForMember(dest => dest.DebtDate, opt => opt?.MapFrom(src => StaticFunctions.DateTimeToString(src.DebtDate)))
                 .ForMember(dest => dest.Enable, opt => opt?.MapFrom(src => src.Enable))
             .ReverseMap();
            CreateMap<AddOrUpdateCompanySbsRequestDto, CompanySb>()
                 .ForMember(dest => dest.IdCompany, opt => opt?.MapFrom(src => src.IdCompany == 0 ? null : src.IdCompany))
                 .ForMember(dest => dest.IdOpcionalCommentarySbs, opt => opt?.MapFrom(src => src.IdOpcionalCommentarySbs == 0 ? null : src.IdOpcionalCommentarySbs))
                 .ForMember(dest => dest.DebtRecordedDate, opt => opt?.MapFrom(src => StaticFunctions.VerifyDate(src.DebtRecordedDate)))
                 .ForMember(dest => dest.Date, opt => opt?.MapFrom(src => StaticFunctions.VerifyDate(src.Date)))
           .ReverseMap();
            CreateMap<CompanySb, GetCompanySbsResponseDto>()
                 .ForMember(dest => dest.IdCompany, opt => opt?.MapFrom(src => src.IdCompany == 0 ? null : src.IdCompany))
                 .ForMember(dest => dest.IdOpcionalCommentarySbs, opt => opt?.MapFrom(src => src.IdOpcionalCommentarySbs == 0 ? null : src.IdOpcionalCommentarySbs))
                 .ForMember(dest => dest.DebtRecordedDate, opt => opt?.MapFrom(src => StaticFunctions.DateTimeToString(src.DebtRecordedDate)))
                 .ForMember(dest => dest.Date, opt => opt?.MapFrom(src => StaticFunctions.DateTimeToString(src.Date)))
                 .ForMember(dest => dest.Traductions, opt => opt?.MapFrom(src => src.IdCompanyNavigation.Traductions))
             .ReverseMap();
            CreateMap<AddOrUpdateEndorsementsRequestDto, Endorsement>()
                .ForMember(dest => dest.IdCompany, opt => opt?.MapFrom(src => src.IdCompany == 0 ? null : src.IdCompany))
                .ForMember(dest => dest.Date, opt => opt?.MapFrom(src => StaticFunctions.VerifyDate(src.Date)))
          .ReverseMap();
            CreateMap<Endorsement, GetEndorsementsResponseDto>()
                 .ForMember(dest => dest.IdCompany, opt => opt?.MapFrom(src => src.IdCompany == 0 ? null : src.IdCompany))
                 .ForMember(dest => dest.Date, opt => opt?.MapFrom(src => StaticFunctions.DateTimeToString(src.Date)))
           .ReverseMap();
            CreateMap<AddOrUpdateCompanyCreditOpinionRequestDto, CompanyCreditOpinion>()
                .ForMember(dest => dest.IdCompany, opt => opt?.MapFrom(src => src.IdCompany == 0 ? null : src.IdCompany))
          .ReverseMap();
            CreateMap<CompanyCreditOpinion, GetCompanyCreditOpinionResponseDto>()
                 .ForMember(dest => dest.IdCompany, opt => opt?.MapFrom(src => src.IdCompany == 0 ? null : src.IdCompany))
                 .ForMember(dest => dest.Traductions, opt => opt?.MapFrom(src => src.IdCompanyNavigation.Traductions))
           .ReverseMap();
            CreateMap<AddOrUpdateCompanyGeneralInformationRequestDto, CompanyGeneralInformation>()
               .ForMember(dest => dest.IdCompany, opt => opt?.MapFrom(src => src.IdCompany == 0 ? null : src.IdCompany))
         .ReverseMap();
            CreateMap<CompanyGeneralInformation, GetCompanyGeneralInformationResponseDto>()
                 .ForMember(dest => dest.IdCompany, opt => opt?.MapFrom(src => src.IdCompany == 0 ? null : src.IdCompany))
                 .ForMember(dest => dest.Traductions, opt => opt?.MapFrom(src => src.IdCompanyNavigation.Traductions))
           .ReverseMap();
            CreateMap<AddOrUpdateCompanyImagesRequestDto, DRRCore.Domain.Entities.SQLContext.CompanyImage>()
               .ForMember(dest => dest.IdCompany, opt => opt?.MapFrom(src => src.IdCompany == 0 ? null : src.IdCompany))
         .ReverseMap();
            CreateMap<DRRCore.Domain.Entities.SQLContext.CompanyImage, GetCompanyImageResponseDto>()
                 .ForMember(dest => dest.IdCompany, opt => opt?.MapFrom(src => src.IdCompany == 0 ? null : src.IdCompany))
           .ReverseMap();

            CreateMap<ImportsAndExport, GetImportsAndExportResponseDto>()
                .ForMember(dest => dest.IdCompany, opt => opt?.MapFrom(src => src.IdCompany == 0 ? null : src.IdCompany))
          .ReverseMap();
            CreateMap<AddOrUpdateImportsAndExportsRequestDto, ImportsAndExport>()
                .ForMember(dest => dest.IdCompany, opt => opt?.MapFrom(src => src.IdCompany == 0 ? null : src.IdCompany))
          .ReverseMap();

            CreateMap<CompanyPartner, GetCompanyPartnersResponseDto>()
            .ForMember(dest => dest.IdCompany, opt => opt?.MapFrom(src => src.IdCompany == 0 ? null : src.IdCompany))
            .ForMember(dest => dest.IdPerson, opt => opt?.MapFrom(src => src.IdPerson == 0 ? null : src.IdPerson))
            .ForMember(dest => dest.Profession, opt => opt?.MapFrom(src => src.Profession))
            .ForMember(dest => dest.StartDate, opt => opt?.MapFrom(src => StaticFunctions.DateTimeToString(src.StartDate)))
      .ReverseMap();
            CreateMap<CompanyPartner, GetListCompanyPartnersResponseDto>()
            .ForMember(dest => dest.IdCompany, opt => opt?.MapFrom(src => src.IdCompany == 0 ? null : src.IdCompany))
            .ForMember(dest => dest.IdPerson, opt => opt?.MapFrom(src => src.IdPerson == 0 ? null : src.IdPerson))
            .ForMember(dest => dest.Name, opt => opt?.MapFrom(src => src.IdPersonNavigation.Fullname))
            .ForMember(dest => dest.Nationality, opt => opt?.MapFrom(src => src.IdPersonNavigation.Nationality))
            .ForMember(dest => dest.BirthDate, opt => opt?.MapFrom(src => src.IdPersonNavigation.BirthDate))
            .ForMember(dest => dest.IdentificationDocument, opt => opt?.MapFrom(src => src.IdPersonNavigation.IdDocumentTypeNavigation.Abreviation + " - " + src.IdPersonNavigation.CodeDocumentType))
            .ForMember(dest => dest.Profession, opt => opt?.MapFrom(src => src.Profession))
            .ForMember(dest => dest.StartDate, opt => opt?.MapFrom(src => StaticFunctions.DateTimeToString(src.StartDate)))
      .ReverseMap();
            CreateMap<CompanyPartner, GetListPersonPartnerResponseDto>()
            .ForMember(dest => dest.IdCompany, opt => opt?.MapFrom(src => src.IdCompany == 0 ? null : src.IdCompany))
            .ForMember(dest => dest.IdPerson, opt => opt?.MapFrom(src => src.IdPerson == 0 ? null : src.IdPerson))
            .ForMember(dest => dest.Name, opt => opt?.MapFrom(src => src.IdCompanyNavigation.Name))
            .ForMember(dest => dest.Country, opt => opt?.MapFrom(src => src.IdCompanyNavigation.IdCountryNavigation.Iso))
            .ForMember(dest => dest.FlagCountry, opt => opt?.MapFrom(src => src.IdCompanyNavigation.IdCountryNavigation.FlagIso))
            .ForMember(dest => dest.TaxTypeName, opt => opt?.MapFrom(src => src.IdCompanyNavigation.TaxTypeName))
            .ForMember(dest => dest.TaxTypeCode, opt => opt?.MapFrom(src => src.IdCompanyNavigation.TaxTypeCode))
            .ForMember(dest => dest.Situation, opt => opt?.MapFrom(src => src.IdCompanyNavigation.IdLegalRegisterSituationNavigation.Abreviation))
            .ForMember(dest => dest.Profession, opt => opt?.MapFrom(src => src.Profession))
      .ReverseMap();
            CreateMap<AddOrUpdateCompanyPartnersRequestDto, CompanyPartner>()
             .ForMember(dest => dest.IdCompany, opt => opt?.MapFrom(src => src.IdCompany == 0 ? null : src.IdCompany))
            .ForMember(dest => dest.IdPerson, opt => opt?.MapFrom(src => src.IdPerson == 0 ? null : src.IdPerson))
            .ForMember(dest => dest.Profession, opt => opt?.MapFrom(src => src.Profession))
                 .ForMember(dest => dest.StartDate, opt => opt?.MapFrom(src => StaticFunctions.VerifyDate(src.StartDate)))
          .ReverseMap();

            CreateMap<CompanyShareHolder, GetCompanyShareHolderResponseDto>()
            .ForMember(dest => dest.IdCompany, opt => opt?.MapFrom(src => src.IdCompany == 0 ? null : src.IdCompany))
            .ForMember(dest => dest.IdCompanyShareHolder, opt => opt?.MapFrom(src => src.IdCompanyShareHolder == 0 ? null : src.IdCompanyShareHolder))
            .ForMember(dest => dest.StartDate, opt => opt?.MapFrom(src => StaticFunctions.DateTimeToString(src.StartDate)))
      .ReverseMap();
            CreateMap<CompanyShareHolder, GetListCompanyShareHolderResponseDto>()
            .ForMember(dest => dest.IdCompany, opt => opt?.MapFrom(src => src.IdCompany == 0 ? null : src.IdCompany))
            .ForMember(dest => dest.IdCompanyShareHolder, opt => opt?.MapFrom(src => src.IdCompanyShareHolder == 0 ? null : src.IdCompanyShareHolder))
            .ForMember(dest => dest.Name, opt => opt?.MapFrom(src => src.IdCompanyShareHolderNavigation.Name))
            .ForMember(dest => dest.Country, opt => opt?.MapFrom(src => src.IdCompanyShareHolderNavigation.IdCountryNavigation.Iso))
            .ForMember(dest => dest.FlagCountry, opt => opt?.MapFrom(src => src.IdCompanyShareHolderNavigation.IdCountryNavigation.FlagIso))
            .ForMember(dest => dest.TaxTypeName, opt => opt?.MapFrom(src => src.IdCompanyShareHolderNavigation.TaxTypeName))
            .ForMember(dest => dest.TaxTypeCode, opt => opt?.MapFrom(src => src.IdCompanyShareHolderNavigation.TaxTypeCode))
            .ForMember(dest => dest.StartDate, opt => opt?.MapFrom(src => StaticFunctions.DateTimeToString(src.StartDate)))
      .ReverseMap();
            CreateMap<AddOrUpdateCompanyShareHolderRequestDto, CompanyShareHolder>()
            .ForMember(dest => dest.IdCompany, opt => opt?.MapFrom(src => src.IdCompany == 0 ? null : src.IdCompany))
            .ForMember(dest => dest.IdCompanyShareHolder, opt => opt?.MapFrom(src => src.IdCompanyShareHolder == 0 ? null : src.IdCompanyShareHolder))
            .ForMember(dest => dest.StartDate, opt => opt?.MapFrom(src => StaticFunctions.VerifyDate(src.StartDate)))
          .ReverseMap();
            CreateMap<WorkersHistory, GetWorkersHistoryResponseDto>()
           .ForMember(dest => dest.IdCompany, opt => opt?.MapFrom(src => src.IdCompany == 0 ? null : src.IdCompany))
     .ReverseMap();
            CreateMap<WorkersHistory, GetListWorkersHistoryResponseDto>()
            .ForMember(dest => dest.IdCompany, opt => opt?.MapFrom(src => src.IdCompany == 0 ? null : src.IdCompany))
      .ReverseMap();
            CreateMap<AddOrUpdateWorkerHistoryRequestDto, WorkersHistory>()
            .ForMember(dest => dest.IdCompany, opt => opt?.MapFrom(src => src.IdCompany == 0 ? null : src.IdCompany))
          .ReverseMap();
            CreateMap<CompanyRelation, GetCompanyRelationResponseDto>()
         .ForMember(dest => dest.IdCompany, opt => opt?.MapFrom(src => src.IdCompany == 0 ? null : src.IdCompany))
         .ForMember(dest => dest.IdCompanyRelation, opt => opt?.MapFrom(src => src.IdCompanyRelation == 0 ? null : src.IdCompanyRelation))
   .ReverseMap();
            CreateMap<CompanyRelation, GetListCompanyRelationResponseDto>()
            .ForMember(dest => dest.IdCompany, opt => opt?.MapFrom(src => src.IdCompany == 0 ? null : src.IdCompany))
            .ForMember(dest => dest.IdCompanyRelation, opt => opt?.MapFrom(src => src.IdCompanyRelation == 0 ? null : src.IdCompanyRelation))
            .ForMember(dest => dest.Name, opt => opt?.MapFrom(src => src.IdCompanyRelationNavigation.Name))
            .ForMember(dest => dest.Country, opt => opt?.MapFrom(src => src.IdCompanyRelationNavigation.IdCountryNavigation.Iso))
            .ForMember(dest => dest.FlagCountry, opt => opt?.MapFrom(src => src.IdCompanyRelationNavigation.IdCountryNavigation.FlagIso))
            .ForMember(dest => dest.TaxTypeName, opt => opt?.MapFrom(src => src.IdCompanyRelationNavigation.TaxTypeName))
            .ForMember(dest => dest.TaxTypeCode, opt => opt?.MapFrom(src => src.IdCompanyRelationNavigation.TaxTypeCode))
            .ForMember(dest => dest.Situation, opt => opt?.MapFrom(src => src.IdCompanyRelationNavigation.IdLegalRegisterSituationNavigation.Abreviation))
      .ReverseMap();
            CreateMap<AddOrUpdateCompanyRelationRequestDto, CompanyRelation>()
            .ForMember(dest => dest.IdCompany, opt => opt?.MapFrom(src => src.IdCompany == 0 ? null : src.IdCompany))
            .ForMember(dest => dest.IdCompanyRelation, opt => opt?.MapFrom(src => src.IdCompanyRelation == 0 ? null : src.IdCompanyRelation))
          .ReverseMap();
            CreateMap<CompanyXmlData, GetCompanyXmlData>()
          .ReverseMap();
        }

        private int GetTraductionPercentage(ICollection<Traduction> traductions)
        {
            int total = traductions.Count;
            int existTraduction = 0;
            foreach (var item in traductions)
            {
               if(!string.IsNullOrEmpty(item.ShortValue) || !string.IsNullOrEmpty(item.LargeValue))
                {
                    existTraduction++;
                }
            }
            if (total == 0) return 0;

            return existTraduction*100 / total;
        }
       
    }
}

using AutoMapper;
using DRRCore.Application.DTO.Core.Response;
using DRRCore.Domain.Entities.SqlCoreContext;

namespace DRRCore.Transversal.Mapper.Profiles.Core
{
    public class ComboProfile:Profile
    {
        public ComboProfile()
        {
            CreateMap<DocumentType, GetComboValueResponseDto>()
               .ForMember(dest => dest.Id, opt => opt?.MapFrom(src => src.Id))
               .ForMember(dest => dest.Valor, opt => opt?.MapFrom(src => src.Abreviation))
               .ReverseMap();
            CreateMap<Reason, GetComboValueResponseDto>()
                .ForMember(dest => dest.Id, opt => opt?.MapFrom(src => src.Id))
                .ForMember(dest => dest.Valor, opt => opt?.MapFrom(src => src.Name))
                .ReverseMap();
            CreateMap<UserLogin, GetComboNameValueResponseDto>()
                .ForMember(dest => dest.Id, opt => opt?.MapFrom(src => src.IdEmployee == null ? 0 : src.IdEmployee))
                .ForMember(dest => dest.Name, opt => opt?.MapFrom(src => src.IdEmployeeNavigation.FirstName + " " + src.IdEmployeeNavigation.LastName))
                .ForMember(dest => dest.Valor, opt => opt?.MapFrom(src => src.IdEmployeeNavigation.Email))
                .ReverseMap();
            CreateMap<CivilStatus, GetComboValueResponseDto>()
               .ForMember(dest => dest.Id, opt => opt?.MapFrom(src => src.Id))
               .ForMember(dest => dest.Valor, opt => opt?.MapFrom(src => src.Name))
               .ReverseMap();

            CreateMap<Continent, GetComboValueResponseDto>()
              .ForMember(dest => dest.Id, opt => opt?.MapFrom(src => src.Id))
              .ForMember(dest => dest.Valor, opt => opt?.MapFrom(src => src.Name))
              .ReverseMap();

            CreateMap<JobDepartment, GetComboValueResponseDto>()
              .ForMember(dest => dest.Id, opt => opt?.MapFrom(src => src.Id))
              .ForMember(dest => dest.Valor, opt => opt?.MapFrom(src => src.Name))
              .ReverseMap();

            CreateMap<Job, GetComboValueResponseDto>()
            .ForMember(dest => dest.Id, opt => opt?.MapFrom(src => src.Id))
            .ForMember(dest => dest.Valor, opt => opt?.MapFrom(src => src.Name))
            .ReverseMap();

            CreateMap<BankAccountType, GetComboValueResponseDto>()
          .ForMember(dest => dest.Id, opt => opt?.MapFrom(src => src.Id))
          .ForMember(dest => dest.Valor, opt => opt?.MapFrom(src => src.Name))
          .ReverseMap();

            CreateMap<LegalPersonType, GetComboValueResponseDto>()
         .ForMember(dest => dest.Id, opt => opt?.MapFrom(src => src.Id))
         .ForMember(dest => dest.Valor, opt => opt?.MapFrom(src => src.Name))
         .ReverseMap();

            CreateMap<FamilyBondType, GetComboValueResponseDto>()
         .ForMember(dest => dest.Id, opt => opt?.MapFrom(src => src.Id))
         .ForMember(dest => dest.Valor, opt => opt?.MapFrom(src => src.Name))
         .ReverseMap();

            CreateMap<LegalRegisterSituation, GetComboValueResponseDto>()
        .ForMember(dest => dest.Id, opt => opt?.MapFrom(src => src.Id))
        .ForMember(dest => dest.Valor, opt => opt?.MapFrom(src => src.Name))
        .ReverseMap();

            CreateMap<Currency, GetComboValueResponseDto>()
        .ForMember(dest => dest.Id, opt => opt?.MapFrom(src => src.Id))
        .ForMember(dest => dest.Valor, opt => opt?.MapFrom(src => src.Abreviation + "-"+src.Name+"("+src.Symbol+")"))
        .ReverseMap();

            CreateMap<CreditRisk, GetComboCreditRiskResponseDto>()
       .ForMember(dest => dest.Id, opt => opt?.MapFrom(src => src.Id))
       .ForMember(dest => dest.Valor, opt => opt?.MapFrom(src =>  src.Name))
       .ForMember(dest => dest.Rate, opt => opt?.MapFrom(src => src.Rate))
       .ForMember(dest => dest.Color, opt => opt?.MapFrom(src => src.Color))
       .ForMember(dest => dest.Identifier, opt => opt?.MapFrom(src => src.Identifier))
       .ForMember(dest => dest.Abreviation, opt => opt?.MapFrom(src => src.Abreviation))
       .ReverseMap();

            CreateMap<Reputation, GetComboColorResponseDto>()
     .ForMember(dest => dest.Id, opt => opt?.MapFrom(src => src.Id))
     .ForMember(dest => dest.Valor, opt => opt?.MapFrom(src => src.Name))     
     .ForMember(dest => dest.Color, opt => opt?.MapFrom(src => src.Color))    
     .ReverseMap();

            CreateMap<PaymentPolicy, GetComboColorResponseDto>()
    .ForMember(dest => dest.Id, opt => opt?.MapFrom(src => src.Id))
    .ForMember(dest => dest.Valor, opt => opt?.MapFrom(src => src.Name))
    .ForMember(dest => dest.Color, opt => opt?.MapFrom(src => src.Color))
    .ReverseMap();

       

            CreateMap<Country, GetComboValueFlagResponseDto>()
             .ForMember(dest => dest.Id, opt => opt?.MapFrom(src => src.Id))
             .ForMember(dest => dest.Valor, opt => opt?.MapFrom(src => src.Name))
             .ForMember(dest => dest.Abreviation, opt => opt?.MapFrom(src => src.Iso))
             .ForMember(dest => dest.Bandera, opt => opt?.MapFrom(src => src.FlagIso))
             .ForMember(dest => dest.Regtrib, opt => opt?.MapFrom(src => src.TaxTypeName))
             .ForMember(dest => dest.CodCel, opt => opt?.MapFrom(src => src.CodePhone))
             .ReverseMap();
            CreateMap<SubscriberCategory, GetComboValueResponseDto>()
            .ForMember(dest => dest.Id, opt => opt?.MapFrom(src => src.Id))
            .ForMember(dest => dest.Valor, opt => opt?.MapFrom(src => src.Name))
            .ReverseMap();
            CreateMap<FinancialSituacion, GetFinancialSituationResponseDto>()
           .ForMember(dest => dest.Id, opt => opt?.MapFrom(src => src.Id))
           .ForMember(dest => dest.Valor, opt => opt?.MapFrom(src => src.Name))
           .ForMember(dest => dest.reportCommentWithBalance, opt => opt?.MapFrom(src => src.ReportCommentWithBalance))
           .ForMember(dest => dest.reportCommentWithoutBalance, opt => opt?.MapFrom(src => src.ReportCommentWithoutBalance))
           .ReverseMap();
            CreateMap<CollaborationDegree, GetComboValueResponseDto>()
           .ForMember(dest => dest.Id, opt => opt?.MapFrom(src => src.Id))
           .ForMember(dest => dest.Valor, opt => opt?.MapFrom(src => src.Name))
           .ReverseMap();
            CreateMap<OpcionalCommentarySb, GetComboValueResponseDto>()
         .ForMember(dest => dest.Id, opt => opt?.MapFrom(src => src.Id))
         .ForMember(dest => dest.Valor, opt => opt?.MapFrom(src => src.Name))
         .ReverseMap();
            CreateMap<BranchSector, GetComboValueResponseDto>()
         .ForMember(dest => dest.Id, opt => opt?.MapFrom(src => src.Id))
         .ForMember(dest => dest.Valor, opt => opt?.MapFrom(src => src.Name))
         .ReverseMap();
            CreateMap<BusinessBranch, GetComboValueResponseDto>()
         .ForMember(dest => dest.Id, opt => opt?.MapFrom(src => src.Id))
         .ForMember(dest => dest.Valor, opt => opt?.MapFrom(src => src.Name))
         .ReverseMap();
            CreateMap<BusineesActivity, GetComboValueEngResponseDto>()
         .ForMember(dest => dest.Id, opt => opt?.MapFrom(src => src.Id))
         .ForMember(dest => dest.Valor, opt => opt?.MapFrom(src => src.Name))
         .ForMember(dest => dest.ValorEng, opt => opt?.MapFrom(src => src.EnglishName))
         .ReverseMap();
            CreateMap<LandOwnership, GetComboValueResponseDto>()
         .ForMember(dest => dest.Id, opt => opt?.MapFrom(src => src.Id))
         .ForMember(dest => dest.Valor, opt => opt?.MapFrom(src => src.Name))
         .ReverseMap();
            CreateMap<PersonSituation, GetComboValueResponseDto>()
         .ForMember(dest => dest.Id, opt => opt?.MapFrom(src => src.Id))
         .ForMember(dest => dest.Valor, opt => opt?.MapFrom(src => src.Name))
         .ReverseMap();
            CreateMap<Profession, GetComboValueResponseDto>()
         .ForMember(dest => dest.Id, opt => opt?.MapFrom(src => src.Id))
         .ForMember(dest => dest.Valor, opt => opt?.MapFrom(src => src.Name))
         .ReverseMap();
        }
    }
}

using AutoMapper;
using DRRCore.Application.DTO.Core.Request;
using DRRCore.Application.DTO.Core.Response;
using DRRCore.Domain.Entities.SqlCoreContext;
using DRRCore.Transversal.Common;
using Microsoft.IdentityModel.Tokens;

namespace DRRCore.Transversal.Mapper.Profiles.Core
{
    public class PersonProfile : Profile
    {
        public PersonProfile()
        {
            CreateMap<AddOrUpdatePersonRequestDto, Person>()
                 .ForMember(dest => dest.IdCivilStatus, opt => opt?.MapFrom(src => src.IdCivilStatus == 0 ? null : src.IdCivilStatus))
                 .ForMember(dest => dest.IdLegalRegisterSituation, opt => opt?.MapFrom(src => src.IdLegalRegisterSituation == 0 ? null : src.IdLegalRegisterSituation))
                 .ForMember(dest => dest.IdCreditRisk, opt => opt?.MapFrom(src => src.IdCreditRisk == 0 ? null : src.IdCreditRisk))
                 .ForMember(dest => dest.IdPaymentPolicy, opt => opt?.MapFrom(src => src.IdPaymentPolicy == 0 ? null : src.IdPaymentPolicy))
                 .ForMember(dest => dest.IdReputation, opt => opt?.MapFrom(src => src.IdReputation == 0 ? null : src.IdReputation))
                 .ForMember(dest => dest.IdCountry, opt => opt?.MapFrom(src => src.IdCountry == 0 ? null : src.IdCountry))
                 .ForMember(dest => dest.IdDocumentType, opt => opt?.MapFrom(src => src.IdDocumentType == 0 ? null : src.IdDocumentType))
                 .ForMember(dest => dest.RelationshipDocumentType, opt => opt?.MapFrom(src => src.RelationshipDocumentType == 0 ? null : src.RelationshipDocumentType))
                 .ForMember(dest => dest.IdPersonSituation, opt => opt?.MapFrom(src => src.IdPersonSituation == 0 ? null : src.IdPersonSituation))
                 .ForMember(dest => dest.LastSearched, opt => opt?.MapFrom(src => StaticFunctions.VerifyDate(src.LastSearched)))
                 .ForMember(dest => dest.BirthDate, opt => opt?.MapFrom(src => src.BirthDate))
              .ReverseMap();
            CreateMap<Person, GetPersonResponseDto>()
                 .ForMember(dest => dest.IdCivilStatus, opt => opt?.MapFrom(src => src.IdCivilStatus == null ? 0 : src.IdCivilStatus))
                 .ForMember(dest => dest.IdLegalRegisterSituation, opt => opt?.MapFrom(src => src.IdLegalRegisterSituation == null ? 0 : src.IdLegalRegisterSituation))
                 .ForMember(dest => dest.IdCreditRisk, opt => opt?.MapFrom(src => src.IdCreditRisk == null ? 0 : src.IdCreditRisk))
                 .ForMember(dest => dest.IdPaymentPolicy, opt => opt?.MapFrom(src => src.IdPaymentPolicy == null ? 0 : src.IdPaymentPolicy))
                 .ForMember(dest => dest.IdReputation, opt => opt?.MapFrom(src => src.IdReputation == null ? 0 : src.IdReputation))
                 .ForMember(dest => dest.IdCountry, opt => opt?.MapFrom(src => src.IdCountry == null ? 0 : src.IdCountry))
                 .ForMember(dest => dest.IdContinent, opt => opt?.MapFrom(src => src.IdCountry == null ?  0: src.IdCountryNavigation.IdContinent))
                 .ForMember(dest => dest.TaxTypeName, opt => opt?.MapFrom(src => src.IdCountry == null ? "" : src.IdCountryNavigation.TaxTypeName))
                 .ForMember(dest => dest.TaxTypeByCountry, opt => opt?.MapFrom(src => src.IdCountry == null ? "" : src.IdCountryNavigation.TaxTypeName))
                 .ForMember(dest => dest.IdDocumentType, opt => opt?.MapFrom(src => src.IdDocumentType == null ? 0 : src.IdDocumentType))
                 .ForMember(dest => dest.RelationshipDocumentType, opt => opt?.MapFrom(src => src.RelationshipDocumentType == null ? 0 : src.RelationshipDocumentType))
                 .ForMember(dest => dest.Profession, opt => opt?.MapFrom(src => src.Profession))
                 .ForMember(dest => dest.IdPersonSituation, opt => opt?.MapFrom(src => src.IdPersonSituation == null ? 0 : src.IdPersonSituation))
                 .ForMember(dest => dest.LastSearched, opt => opt?.MapFrom(src => StaticFunctions.DateTimeToString(src.LastSearched)))
                 .ForMember(dest => dest.BirthDate, opt => opt?.MapFrom(src => src.BirthDate))
              .ReverseMap();
            CreateMap<Person, GetListPersonResponseDto>()
                 .ForMember(dest => dest.CreditRisk, opt => opt?.MapFrom(src => src.IdCreditRiskNavigation.Identifier))
                 .ForMember(dest => dest.Country, opt => opt?.MapFrom(src => src.IdCountryNavigation.Iso))
                 .ForMember(dest => dest.FlagCountry, opt => opt?.MapFrom(src => src.IdCountryNavigation.FlagIso))
                 .ForMember(dest => dest.DocumentType, opt => opt?.MapFrom(src => src.IdDocumentTypeNavigation.Abreviation))
                 .ForMember(dest => dest.Cellphone, opt => opt?.MapFrom(src => src.Cellphone))
                 .ForMember(dest => dest.SocialName, opt => opt?.MapFrom(src => src.TradeName))
                 .ForMember(dest => dest.TraductionPercentage, opt => opt?.MapFrom(src => GetTraductionPersonPercentage(src.TraductionPeople.FirstOrDefault())))
                 .ForMember(dest => dest.Profession, opt => opt?.MapFrom(src => src.Profession))
                 .ForMember(dest => dest.LastSearched, opt => opt?.MapFrom(src => StaticFunctions.DateTimeToString(src.LastSearched)))
                 .ForMember(dest => dest.BirthDate, opt => opt?.MapFrom(src => src.BirthDate))
                 .ForMember(dest => dest.OnWeb, opt => opt?.MapFrom(src => src.OnWeb))
                 .ForMember(dest => dest.Enable, opt => opt?.MapFrom(src => src.Enable))
              .ReverseMap();
            CreateMap<PersonHome, GetPersonHomeResponseDto>()
                .ForMember(dest => dest.Traductions, opt => opt?.MapFrom(src => src.IdPersonNavigation.Traductions))
              .ReverseMap();
            CreateMap<AddOrUpdatePersonHomeRequestDto, PersonHome>()
                 .ForMember(dest => dest.IdPerson, opt => opt?.MapFrom(src => src.IdPerson == 0 ? null : src.IdPerson))
              .ReverseMap();
            CreateMap<PersonActivity, GetPersonActivitiesResponseDto>()
               .ForMember(dest => dest.Traductions, opt => opt?.MapFrom(src => src.IdPersonNavigation.Traductions))
             .ReverseMap();
            CreateMap<AddOrUpdatePersonActivitiesRequestDto, PersonActivity>()
                 .ForMember(dest => dest.IdPerson, opt => opt?.MapFrom(src => src.IdPerson == 0 ? null : src.IdPerson))
              .ReverseMap();
            CreateMap<PersonProperty, GetPersonPropertyResponseDto>()
               .ForMember(dest => dest.Traductions, opt => opt?.MapFrom(src => src.IdPersonNavigation.Traductions))
             .ReverseMap();
            CreateMap<AddOrUpdatePersonPropertyRequestDto, PersonProperty>()
                 .ForMember(dest => dest.IdPerson, opt => opt?.MapFrom(src => src.IdPerson == 0 ? null : src.IdPerson))
              .ReverseMap();
            CreateMap<PersonHistory, GetPersonHistoryResponseDto>()
               .ForMember(dest => dest.Traductions, opt => opt?.MapFrom(src => src.IdPersonNavigation.Traductions))
             .ReverseMap();
            CreateMap<AddOrUpdatePersonHistoryRequestDto, PersonHistory>()
                 .ForMember(dest => dest.IdPerson, opt => opt?.MapFrom(src => src.IdPerson == 0 ? null : src.IdPerson))
              .ReverseMap();
            CreateMap<PersonGeneralInformation, GetPersonGeneralInfoResponseDto>()
               .ForMember(dest => dest.Traductions, opt => opt?.MapFrom(src => src.IdPersonNavigation.Traductions))
             .ReverseMap();
            CreateMap<AddOrUpdatePersonGeneralInfoRequestDto, PersonGeneralInformation>()
                 .ForMember(dest => dest.IdPerson, opt => opt?.MapFrom(src => src.IdPerson == 0 ? null : src.IdPerson))
              .ReverseMap();
            CreateMap<PersonJob, GetPersonJobResponseDto>()
               .ForMember(dest => dest.Traductions, opt => opt?.MapFrom(src => src.IdPersonNavigation.Traductions))
               .ForMember(dest => dest.Name, opt => opt?.MapFrom(src => src.IdCompanyNavigation.Name))
               .ForMember(dest => dest.Address, opt => opt?.MapFrom(src => src.IdCompanyNavigation.Address))
               .ForMember(dest => dest.TaxTypeCode, opt => opt?.MapFrom(src => src.IdCompanyNavigation.TaxTypeCode))
               .ForMember(dest => dest.TaxTypeName, opt => opt?.MapFrom(src => src.IdCompanyNavigation.TaxTypeName))
               .ForMember(dest => dest.SubTelephone, opt => opt?.MapFrom(src => src.IdCompanyNavigation.SubTelephone))
               .ForMember(dest => dest.Telephone, opt => opt?.MapFrom(src => src.IdCompanyNavigation.Telephone))
               .ForMember(dest => dest.StartDate, opt => opt?.MapFrom(src => src.StartDate))
               .ForMember(dest => dest.EndDate, opt => opt?.MapFrom(src => src.EndDate))
             .ReverseMap();
            CreateMap<AddOrUpdatePersonJobRequestDto, PersonJob>()
                 .ForMember(dest => dest.IdPerson, opt => opt?.MapFrom(src => src.IdPerson == 0 ? null : src.IdPerson))
                 .ForMember(dest => dest.IdCompany, opt => opt?.MapFrom(src => src.IdCompany == 0 ? null : src.IdCompany))
                 .ForMember(dest => dest.StartDate, opt => opt?.MapFrom(src => src.StartDate))
                 .ForMember(dest => dest.EndDate, opt => opt?.MapFrom(src => src.EndDate))
              .ReverseMap();
            CreateMap<AddOrUpdatePersonImagesRequestDto, PersonImage>()
             .ForMember(dest => dest.IdPerson, opt => opt?.MapFrom(src => src.IdPerson == 0 ? null : src.IdPerson))
       .ReverseMap();
            CreateMap<PersonImage, GetPersonImagesResponseDto>()
                 .ForMember(dest => dest.IdPerson, opt => opt?.MapFrom(src => src.IdPerson == 0 ? null : src.IdPerson))
                 .ForMember(dest => dest.Traductions, opt => opt?.MapFrom(src => src.IdPersonNavigation.Traductions))
           .ReverseMap();
            CreateMap<AddOrUpdatePersonSbsRequestDto, PersonSb>()
                .ForMember(dest => dest.IdPerson, opt => opt?.MapFrom(src => src.IdPerson == 0 ? null : src.IdPerson))
                .ForMember(dest => dest.DebtRecordedDate, opt => opt?.MapFrom(src => src.DebtRecordedDate))
                .ForMember(dest => dest.Date, opt => opt?.MapFrom(src => StaticFunctions.VerifyDate(src.Date)))
          .ReverseMap();
            CreateMap<PersonSb, GetPersonSbsResponseDto>()
                 .ForMember(dest => dest.IdPerson, opt => opt?.MapFrom(src => src.IdPerson == 0 ? null : src.IdPerson))
                 .ForMember(dest => dest.DebtRecordedDate, opt => opt?.MapFrom(src => src.DebtRecordedDate))
                 .ForMember(dest => dest.Date, opt => opt?.MapFrom(src => StaticFunctions.DateTimeToString(src.Date)))
                 .ForMember(dest => dest.Traductions, opt => opt?.MapFrom(src => src.IdPersonNavigation.Traductions))
             .ReverseMap();
            CreateMap<PhotoPerson, GetPersonPhotoResponseDto>()
                 .ForMember(dest => dest.IdPerson, opt => opt?.MapFrom(src => src.IdPerson == 0 ? null : src.IdPerson))
             .ReverseMap();
            CreateMap<AddOrUpdatePersonPhotoRequestDto, PhotoPerson>()
               .ForMember(dest => dest.IdPerson, opt => opt?.MapFrom(src => src.IdPerson == 0 ? null : src.IdPerson))
         .ReverseMap();


            CreateMap<Traduction, TraductionDto>()
                .ForMember(dest => dest.Key, opt => opt?.MapFrom(src => src.Identifier))
                .ForMember(dest => dest.Value, opt => opt?.MapFrom(src => src.Identifier.StartsWith("S") ? src.ShortValue : src.LargeValue))
                 .ReverseMap();

            CreateMap<Ticket, GetListPersonResponseDto>()
              .ForMember(dest => dest.Id, opt => opt?.MapFrom(src => src.IdCompany))
              .ForMember(dest => dest.Fullname, opt => opt?.MapFrom(src => src.RequestedName))
              .ForMember(dest => dest.DispatchName, opt => opt?.MapFrom(src => src.DispatchedName))
              .ForMember(dest => dest.Language, opt => opt?.MapFrom(src => src.Language))
              .ForMember(dest => dest.Cellphone, opt => opt?.MapFrom(src => src.Telephone))
              .ForMember(dest => dest.Country, opt => opt?.MapFrom(src => src.IdCountryNavigation != null ? src.IdCountryNavigation.Name : string.Empty))
              .ForMember(dest => dest.IsoCountry, opt => opt?.MapFrom(src => src.IdCountryNavigation != null ? src.IdCountryNavigation.Iso : string.Empty))
              .ForMember(dest => dest.FlagCountry, opt => opt?.MapFrom(src => src.IdCountryNavigation != null ? src.IdCountryNavigation.FlagIso : string.Empty))
              .ReverseMap();

        }
        private int GetTraductionPersonPercentage(TraductionPerson traductions)
        {
            int total = 22;
            int existTraduction = 0;
            if (traductions != null)
            {
                if (traductions.TPnacionality.IsNullOrEmpty() == false) existTraduction++;
                if (traductions.TPbirthPlace.IsNullOrEmpty() == false) existTraduction++;
                if (traductions.TPmarriedTo.IsNullOrEmpty() == false) existTraduction++;
                if (traductions.TPprofession.IsNullOrEmpty() == false) existTraduction++;
                if (traductions.TPnewcomm.IsNullOrEmpty() == false) existTraduction++;
                if (traductions.TPreputation.IsNullOrEmpty() == false) existTraduction++;
                if (traductions.TDvalue.IsNullOrEmpty() == false) existTraduction++;
                if (traductions.TDresidence.IsNullOrEmpty() == false) existTraduction++;
                if (traductions.TCcurjob.IsNullOrEmpty() == false) existTraduction++;
                if (traductions.TCstartDate.IsNullOrEmpty() == false) existTraduction++;
                if (traductions.TCenddt.IsNullOrEmpty() == false) existTraduction++;
                if (traductions.TCincome.IsNullOrEmpty() == false) existTraduction++;
                if (traductions.TCdetails.IsNullOrEmpty() == false) existTraduction++;
                if (traductions.TAotherAct.IsNullOrEmpty() == false) existTraduction++;
                if (traductions.TPrdetails.IsNullOrEmpty() == false) existTraduction++;
                if (traductions.TSbsantecedente.IsNullOrEmpty() == false) existTraduction++;
                if (traductions.TSbsrickCnt.IsNullOrEmpty() == false) existTraduction++;
                if (traductions.TSbscommentSbs.IsNullOrEmpty() == false) existTraduction++;
                if (traductions.TSbscommentBank.IsNullOrEmpty() == false) existTraduction++;
                if (traductions.TSbslitig.IsNullOrEmpty() == false) existTraduction++;
                if (traductions.THdetails.IsNullOrEmpty() == false) existTraduction++;
                if (traductions.TIgdetails.IsNullOrEmpty() == false) existTraduction++;
            }
           
            if (total == 0) return 0;

            return existTraduction * 100 / total;
        }
    }
}

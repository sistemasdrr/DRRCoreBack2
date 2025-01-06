using AutoMapper;
using DRRCore.Application.DTO.Core.Request;
using DRRCore.Application.DTO.Core.Response;
using DRRCore.Application.DTO.Enum;
using DRRCore.Domain.Entities.MYSQLContext;
using DRRCore.Domain.Entities.SqlCoreContext;
using DRRCore.Transversal.Common;
using Microsoft.IdentityModel.Tokens;

namespace DRRCore.Transversal.Mapper.Profiles.Core
{
    public class TicketProfile:Profile
    {
        public TicketProfile() {


            
            CreateMap<Company, GetSearchSituationResponseDto>()
                   .ForMember(dest => dest.IdCompany, opt => opt?.MapFrom(src => src.Id))
                   .ForMember(dest => dest.OldCode, opt => opt?.MapFrom(src => src.OldCode))
                   .ForMember(dest => dest.Name, opt => opt?.MapFrom(src => src.Name))
                   .ForMember(dest => dest.SocialName, opt => opt?.MapFrom(src => src.SocialName))
                   .ForMember(dest => dest.TaxName, opt => opt?.MapFrom(src => src.TaxTypeName))
                   .ForMember(dest => dest.TaxCode, opt => opt?.MapFrom(src => src.TaxTypeCode))
                   .ForMember(dest => dest.Telephone, opt => opt?.MapFrom(src => src.Telephone))
                   .ForMember(dest => dest.IdCountry, opt => opt?.MapFrom(src => src.IdCountry))
                   .ForMember(dest => dest.Country, opt => opt?.MapFrom(src => src.IdCountryNavigation != null ? src.IdCountryNavigation.Iso : ""))
                   .ForMember(dest => dest.FlagCountry, opt => opt?.MapFrom(src => src.IdCountryNavigation != null ? src.IdCountryNavigation.FlagIso : "" ))
                   .ReverseMap();

            CreateMap<Person, GetSearchSituationResponseDto>()
                   .ForMember(dest => dest.IdCompany, opt => opt?.MapFrom(src => src.Id))
                   .ForMember(dest => dest.OldCode, opt => opt?.MapFrom(src => src.OldCode))
                   .ForMember(dest => dest.Name, opt => opt?.MapFrom(src => src.Fullname))
                   .ForMember(dest => dest.SocialName, opt => opt?.MapFrom(src => src.TradeName))
                   .ForMember(dest => dest.TaxName, opt => opt?.MapFrom(src => src.TaxTypeName))
                   .ForMember(dest => dest.TaxCode, opt => opt?.MapFrom(src => src.TaxTypeCode))
                   .ForMember(dest => dest.Telephone, opt => opt?.MapFrom(src => src.Cellphone))
                   .ForMember(dest => dest.IdCountry, opt => opt?.MapFrom(src => src.IdCountry))
                   .ForMember(dest => dest.Country, opt => opt?.MapFrom(src => src.IdCountryNavigation != null ? src.IdCountryNavigation.Iso : ""))
                   .ForMember(dest => dest.FlagCountry, opt => opt?.MapFrom(src => src.IdCountryNavigation != null ? src.IdCountryNavigation.FlagIso : ""))
                   .ReverseMap();

            CreateMap<AddOrUpdateTicketRequestDto, Ticket>()
                   .ForMember(dest => dest.OrderDate, opt => opt?.MapFrom(src => src.OrderDate))
                   .ForMember(dest => dest.ExpireDate, opt => opt?.MapFrom(src => src.ExpireDate))
                   .ForMember(dest => dest.RealExpireDate, opt => opt?.MapFrom(src => src.RealExpireDate))
                   .ForMember(dest => dest.WebPage, opt => opt?.MapFrom(src => src.WebPage))

                    // .ForMember(dest => dest.SubscriberIndications, opt => opt?.MapFrom(src => src.SubscriberIndications))
                    .ForMember(dest => dest.IdPerson, opt => opt?.MapFrom(src => src.IdPerson==0?null:src.IdPerson))
                    .ForMember(dest => dest.IdCompany, opt => opt?.MapFrom(src => src.IdCompany == 0 ? null : src.IdCompany))
                    .ForMember(dest => dest.IdCountry, opt => opt?.MapFrom(src => src.IdCountry == 0 ? null : src.IdCountry))
                    .ForMember(dest => dest.IdContinent, opt => opt?.MapFrom(src => src.IdContinent == 0 ? null : src.IdContinent))

                   .ReverseMap();

            CreateMap<TicketHistory, GetTicketHistoryResponseDto>()
                   .ForMember(dest => dest.IdStatusTicket, opt => opt?.MapFrom(src => src.IdStatusTicket != null ? src.IdStatusTicket : null))
                   .ForMember(dest => dest.IdTicket, opt => opt?.MapFrom(src => src.IdTicket != null ? src.IdTicket : null))
                .ReverseMap();

            CreateMap<Ticket, GetListSameSearchedReportResponseDto>()
                  .ForMember(dest => dest.TypeReport, opt => opt?.MapFrom(src => src.ReportType))
                  .ForMember(dest => dest.DispatchtDate, opt => opt?.MapFrom(src => src.DispatchtDate))
                  .ForMember(dest => dest.DispatchtDateString, opt => opt?.MapFrom(src => StaticFunctions.DateTimeToString(src.DispatchtDate)))
                  .ForMember(dest => dest.IsPending, opt => opt?.MapFrom(src => src.IdStatusTicket==(int?)TicketStatusEnum.Pendiente))
                  .ForMember(dest => dest.TicketNumber, opt => opt?.MapFrom(src =>"N-"+ src.Number.ToString("D6")))
                  .ForMember(dest => dest.RequestedName, opt => opt?.MapFrom(src => src.RequestedName.IsNullOrEmpty() == true ? src.BusineesName : src.RequestedName))
                  .ForMember(dest => dest.Dispatch, opt => opt?.MapFrom(src => src.DispatchedName))
                  .ForMember(dest => dest.Subscriber, opt => opt?.MapFrom(src => src.IdSubscriberNavigation.Code))
                  .ForMember(dest => dest.Procedure, opt => opt?.MapFrom(src => src.ProcedureType))
                  .ReverseMap(); 

            CreateMap<Ticket, GetTicketHistorySubscriberResponseDto>()
                  .ForMember(dest => dest.Name, opt => opt?.MapFrom(src => src.RequestedName))
                  .ForMember(dest => dest.IdCompany, opt => opt?.MapFrom(src => src.IdCompany != null ? src.IdCompany : 0))
                  .ForMember(dest => dest.Ticket, opt => opt?.MapFrom(src => src.Number.ToString("D6")))
                  .ForMember(dest => dest.DispatchDate, opt => opt?.MapFrom(src => StaticFunctions.DateTimeToString(src.DispatchtDate)))
                  .ForMember(dest => dest.IdCountry, opt => opt?.MapFrom(src => src.IdCountry == null ? 0 : src.IdCountry))
                  .ForMember(dest => dest.Country, opt => opt?.MapFrom(src => src.IdCountryNavigation == null ? "" : src.IdCountryNavigation.Name))
                  .ForMember(dest => dest.FlagCountry, opt => opt?.MapFrom(src => src.IdCountryNavigation == null ? "" : src.IdCountryNavigation.FlagIso))
                  .ReverseMap();

            CreateMap<OldTicket, GetListSameSearchedReportResponseDto>()
                  .ForMember(dest => dest.TypeReport, opt => opt?.MapFrom(src => src.TipoInforme))
                  .ForMember(dest => dest.DispatchtDate, opt => opt?.MapFrom(src =>src.FechaDespacho))
                  .ForMember(dest => dest.DispatchtDateString, opt => opt?.MapFrom(src => StaticFunctions.DateTimeToString(src.FechaDespacho)))
                  .ForMember(dest => dest.IsPending, opt => opt?.MapFrom(src => false))
                  .ForMember(dest => dest.TicketNumber, opt => opt?.MapFrom(src =>"A-"+ src.Cupcodigo))
                  .ForMember(dest => dest.RequestedName, opt => opt?.MapFrom(src => src.NombreSolicitado))
                  .ForMember(dest => dest.Dispatch, opt => opt?.MapFrom(src => src.NombreDespachado))
                  .ForMember(dest => dest.Subscriber, opt => opt?.MapFrom(src => src.Abonado))
                  .ForMember(dest => dest.Procedure, opt => opt?.MapFrom(src => src.Tramite))
                  .ReverseMap();
            
            CreateMap<Ticket, GetTicketRequestDto>()
                 .ForMember(dest => dest.IdSubscriber, opt => opt?.MapFrom(src => src.IdSubscriber == null ? 0 : src.IdSubscriber))
                 .ForMember(dest => dest.IdContinent, opt => opt?.MapFrom(src => src.IdContinent == null ? 0 : src.IdContinent))
                 .ForMember(dest => dest.IdCountry, opt => opt?.MapFrom(src => src.IdCountry == null ? 0 : src.IdCountry))
                 .ForMember(dest => dest.IdCompany, opt => opt?.MapFrom(src => src.IdCompany == null ? 0 : src.IdCompany))
                 .ForMember(dest => dest.IdPerson, opt => opt?.MapFrom(src => src.IdPerson == null ? 0 : src.IdPerson))
                 .ForMember(dest => dest.Commentary, opt => opt?.MapFrom(src => src.TicketAssignation.Commentary))
                 .ForMember(dest => dest.WebPage, opt => opt?.MapFrom(src => src.WebPage))
                 .ReverseMap();
            CreateMap<TicketHistory, GetEmployeeAssignated>()
                .ForMember(dest => dest.Code, opt => opt?.MapFrom(src => src.AsignedTo))
                .ReverseMap();
            CreateMap<Ticket, GetListTicketResponseDto>()
                 .ForMember(dest => dest.Id, opt => opt?.MapFrom(src => src.Id))
                 .ForMember(dest => dest.IdTicket, opt => opt?.MapFrom(src => src.Id))
                 .ForMember(dest => dest.IdSubscriber, opt => opt?.MapFrom(src => src.IdSubscriber == null ? 0 : src.IdSubscriber))
                 .ForMember(dest => dest.ProcedureType, opt => opt?.MapFrom(src => src.ProcedureType == null ? string.Empty : src.ProcedureType.Trim()))
                 .ForMember(dest => dest.IdContinent, opt => opt?.MapFrom(src => src.IdContinent == null ? 0 : src.IdContinent))
                 .ForMember(dest => dest.IdCountry, opt => opt?.MapFrom(src => src.IdCountry == null ? 0 : src.IdCountry))
                 .ForMember(dest => dest.IdCompany, opt => opt?.MapFrom(src => src.IdCompany == null ? 0 : src.IdCompany))
                 .ForMember(dest => dest.IdPerson, opt => opt?.MapFrom(src => src.IdPerson == null ? 0 : src.IdPerson))
                 .ForMember(dest => dest.BusineesName, opt => opt?.MapFrom(src => src.BusineesName.IsNullOrEmpty() == false ? src.BusineesName : src.RequestedName))
                 .ForMember(dest => dest.Number, opt => opt?.MapFrom(src => src.About + " - " + src.Number.ToString("D6") + (src.IsComplement == true ? " (C)" : "")))
                 .ForMember(dest => dest.Status, opt => opt?.MapFrom(src => src.IdStatusTicketNavigation.Abrev))
                 .ForMember(dest => dest.StatusColor, opt => opt?.MapFrom(src => src.IdStatusTicketNavigation.Color))
                 .ForMember(dest => dest.StatusFinalOwner, opt => opt?.MapFrom(src => GetStatusFinalOwner(src.TicketHistories)))

                 .ForMember(dest => dest.SubscriberCode, opt => opt?.MapFrom(src => src.IdSubscriberNavigation.Code))
                 .ForMember(dest => dest.SubscriberName, opt => opt?.MapFrom(src => src.IdSubscriberNavigation.Name))
                 .ForMember(dest => dest.SubscriberCountry, opt => opt?.MapFrom(src => src.IdSubscriberNavigation.IdCountryNavigation.Name))
                 .ForMember(dest => dest.SubscriberFlag, opt => opt?.MapFrom(src => src.IdSubscriberNavigation.IdCountryNavigation.FlagIso))
                 .ForMember(dest => dest.SubscriberIndications, opt => opt?.MapFrom(src => src.IdSubscriberNavigation.Indications))

                 .ForMember(dest => dest.InvestigatedContinent, opt => opt?.MapFrom(src => src.About == "E" ? (src.IdCountryNavigation.IdContinentNavigation != null ? src.IdCountryNavigation.IdContinentNavigation.Name : "") : (src.IdCountryNavigation.IdContinentNavigation != null ? src.IdCountryNavigation.IdContinentNavigation.Name : "")))
                 .ForMember(dest => dest.InvestigatedCountry, opt => opt?.MapFrom(src => src.About == "E" ? (src.IdCountryNavigation != null ? src.IdCountryNavigation.Iso : "") : (src.IdCountryNavigation != null ? src.IdCountryNavigation.Iso : "")))
                 .ForMember(dest => dest.InvestigatedIsoCountry, opt => opt?.MapFrom(src => src.About == "E" ? (src.IdCountryNavigation != null ? src.IdCountryNavigation.Iso : "") : (src.IdCountryNavigation != null ? src.IdCountryNavigation.Iso : "")))
                 .ForMember(dest => dest.InvestigatedFlag, opt => opt?.MapFrom(src => src.About == "E" ? (src.IdCountryNavigation != null ? src.IdCountryNavigation.FlagIso : "") : (src.IdCountryNavigation != null ? src.IdCountryNavigation.FlagIso : "")))

                 .ForMember(dest => dest.Files, opt => opt?.MapFrom(src => src.TicketFiles))
                 .ForMember(dest => dest.OrderDate, opt => opt?.MapFrom(src => StaticFunctions.DateTimeToString(src.OrderDate)))
                 .ForMember(dest => dest.ExpireDate, opt => opt?.MapFrom(src => StaticFunctions.DateTimeToString(src.ExpireDate)))
                 .ForMember(dest => dest.RealExpireDate, opt => opt?.MapFrom(src => StaticFunctions.DateTimeToString(src.RealExpireDate)))

                 .ForMember(dest => dest.Price, opt => opt?.MapFrom(src => src.Price == null ? 0 : src.Price))
                 .ForMember(dest => dest.Quality, opt => opt.MapFrom(src => src.Quality ?? ""))
                .ForMember(dest => dest.QualityTypist, opt => opt.MapFrom(src => src.QualityTypist ?? ""))
                .ForMember(dest => dest.QualityTranslator, opt => opt.MapFrom(src => src.QualityTranslator ?? ""))
                .ForMember(dest => dest.QualityReport, opt => opt.MapFrom(src => src.About == "E" ? src.IdCompanyNavigation.Quality : src.IdPersonNavigation.Quality))

                 .ForMember(dest => dest.IsComplement, opt => opt.MapFrom(src => src.IsComplement ))
                 .ForMember(dest => dest.ComplementQuality, opt => opt.MapFrom(src => src.IsComplement == true ? src.IdTicketComplementNavigation.Quality : ""))
                 .ForMember(dest => dest.ComplementQualityTypist, opt => opt.MapFrom(src => src.IsComplement == true ? src.IdTicketComplementNavigation.QualityTranslator : ""))
                 .ForMember(dest => dest.ComplementQualityTranslator, opt => opt.MapFrom(src => src.IsComplement == true ? src.IdTicketComplementNavigation.QualityTypist : ""))


                 .ForMember(dest => dest.DispatchDate, opt => opt?.MapFrom(src => StaticFunctions.DateTimeToString(src.DispatchtDate)))
                 .ForMember(dest => dest.StatusQuery, opt => opt?.MapFrom(src => src.TicketQuery != null ? src.TicketQuery.Status : 0))
                 .ForMember(dest => dest.HasQuery, opt => opt?.MapFrom(src => src.TicketQuery != null))
                 .ForMember(dest => dest.Commentary, opt => opt.MapFrom(src => src.TicketAssignation != null ? src.TicketAssignation.Commentary : "" ))

                 //.ForMember(dest => dest.Commentary, opt => opt?.MapFrom(src => src.TicketAssignation == null ? string.Empty : src.TicketAssignation.Commentary ?? string.Empty))
                 
                 
                 .ForMember(dest => dest.Receptor2, opt => opt?.MapFrom(src => src.TicketAssignation == null ? 0 : src.TicketAssignation.IdUserLogin))
                 
                 
                 .ForMember(dest => dest.HasFiles, opt => opt?.MapFrom(src => src.TicketFiles.Count > 0))
                 .ForMember(dest => dest.WebPage, opt => opt?.MapFrom(src => src.IdCompanyNavigation.WebPage ?? ""))
                 .ForMember(dest => dest.Files, opt => opt?.MapFrom(src => src.TicketFiles))
                 .ForMember(dest => dest.Origen, opt => opt?.MapFrom(src => src.Web == false ? "E&E" : "WEB"))

                  .ReverseMap();
            CreateMap<TicketHistory, GetListTicketResponseDto>()
                 .ForMember(dest => dest.IdTicket, opt => opt?.MapFrom(src => src.IdTicket))
                 .ForMember(dest => dest.Id, opt => opt?.MapFrom(src => src.IdTicket))
                 .ForMember(dest => dest.IdSubscriber, opt => opt?.MapFrom(src => src.IdTicketNavigation.IdSubscriber == null ? 0 : src.IdTicketNavigation.IdSubscriber))
                 .ForMember(dest => dest.ProcedureType, opt => opt?.MapFrom(src => src.IdTicketNavigation.ProcedureType == null ? string.Empty : src.IdTicketNavigation.ProcedureType.Trim()))
                 .ForMember(dest => dest.IdContinent, opt => opt?.MapFrom(src => src.IdTicketNavigation.IdContinent == null ? 0 : src.IdTicketNavigation.IdContinent))
                 .ForMember(dest => dest.IdCountry, opt => opt?.MapFrom(src => src.IdTicketNavigation.IdCountry == null ? 0 : src.IdTicketNavigation.IdCountry))
                 .ForMember(dest => dest.IdCompany, opt => opt?.MapFrom(src => src.IdTicketNavigation.IdCompany == null ? 0 : src.IdTicketNavigation.IdCompany))
                 .ForMember(dest => dest.IdPerson, opt => opt?.MapFrom(src => src.IdTicketNavigation.IdPerson == null ? 0 : src.IdTicketNavigation.IdPerson))
                 .ForMember(dest => dest.Number, opt => opt?.MapFrom(src => src.IdTicketNavigation.About + " - " + src.IdTicketNavigation.Number.ToString("D6")))
                 .ForMember(dest => dest.Status, opt => opt?.MapFrom(src => src.IdStatusTicketNavigation.Abrev))
                 .ForMember(dest => dest.StatusColor, opt => opt?.MapFrom(src => src.IdStatusTicketNavigation.Color))
                 .ForMember(dest => dest.StatusFinalOwner, opt => opt?.MapFrom(src => GetStatusFinalOwner(src.IdTicketNavigation.TicketHistories)))
                 .ForMember(dest => dest.Language, opt => opt?.MapFrom(src => src.IdTicketNavigation.IdCompanyNavigation.Language))
                 .ForMember(dest => dest.About, opt => opt?.MapFrom(src => src.IdTicketNavigation.About))
                 .ForMember(dest => dest.AsignedTo, opt => opt?.MapFrom(src => src.AsignedTo == null ? "" : src.AsignedTo))
                 .ForMember(dest => dest.QueryCredit, opt => opt?.MapFrom(src => src.IdTicketNavigation.QueryCredit == null ? "" : src.IdTicketNavigation.QueryCredit))
                 .ForMember(dest => dest.TimeLimit, opt => opt?.MapFrom(src => src.IdTicketNavigation.TimeLimit == null ? "" : src.IdTicketNavigation.TimeLimit))
                 .ForMember(dest => dest.RevealName, opt => opt?.MapFrom(src => src.IdTicketNavigation.RevealName))
                 .ForMember(dest => dest.NameRevealed, opt => opt?.MapFrom(src => src.IdTicketNavigation.NameRevealed == null ? "" : src.IdTicketNavigation.NameRevealed))
                 .ForMember(dest => dest.ReferenceNumber, opt => opt?.MapFrom(src => src.IdTicketNavigation.ReferenceNumber == null ? "" : src.IdTicketNavigation.ReferenceNumber))
                 .ForMember(dest => dest.AditionalData, opt => opt?.MapFrom(src => src.IdTicketNavigation.AditionalData == null ? "" : src.IdTicketNavigation.AditionalData))
                 .ForMember(dest => dest.BusineesName, opt => opt?.MapFrom(src => src.IdTicketNavigation.BusineesName.IsNullOrEmpty() == false ? src.IdTicketNavigation.BusineesName : src.IdTicketNavigation.RequestedName))
                 .ForMember(dest => dest.ComercialName, opt => opt?.MapFrom(src => src.IdTicketNavigation.ComercialName == null ? "" : src.IdTicketNavigation.ComercialName))
                 .ForMember(dest => dest.RequestedName, opt => opt?.MapFrom(src => src.IdTicketNavigation.RequestedName == null ? "" : src.IdTicketNavigation.RequestedName))
                 .ForMember(dest => dest.TaxType, opt => opt?.MapFrom(src => src.IdTicketNavigation.TaxType == null ? "" : src.IdTicketNavigation.TaxType))
                 .ForMember(dest => dest.TaxCode, opt => opt?.MapFrom(src => src.IdTicketNavigation.TaxCode == null ? "" : src.IdTicketNavigation.TaxCode))
                 .ForMember(dest => dest.City, opt => opt?.MapFrom(src => src.IdTicketNavigation.City == null ? "" : src.IdTicketNavigation.City))
                 .ForMember(dest => dest.Email, opt => opt?.MapFrom(src => src.IdTicketNavigation.Email == null ? "" : src.IdTicketNavigation.Email))
                 .ForMember(dest => dest.Address, opt => opt?.MapFrom(src => src.IdTicketNavigation.Address == null ? "" : src.IdTicketNavigation.Address))
                 .ForMember(dest => dest.Telephone, opt => opt?.MapFrom(src => src.IdTicketNavigation.Telephone == null ? "" : src.IdTicketNavigation.Telephone))
                 .ForMember(dest => dest.ReportType, opt => opt?.MapFrom(src => src.IdTicketNavigation.ReportType == null ? "" : src.IdTicketNavigation.ReportType))
                 .ForMember(dest => dest.DispatchDate, opt => opt?.MapFrom(src => StaticFunctions.DateTimeToString(src.IdTicketNavigation.DispatchtDate)))
                 .ForMember(dest => dest.Creditrisk, opt => opt?.MapFrom(src => src.IdTicketNavigation.IdCompanyNavigation.IdCreditRisk == null ? 0 : src.IdTicketNavigation.IdCompanyNavigation.IdCreditRisk))

                 .ForMember(dest => dest.SubscriberCode, opt => opt?.MapFrom(src => src.IdTicketNavigation.IdSubscriberNavigation.Code))
                 .ForMember(dest => dest.SubscriberName, opt => opt?.MapFrom(src => src.IdTicketNavigation.IdSubscriberNavigation.Name))
                 .ForMember(dest => dest.SubscriberCountry, opt => opt?.MapFrom(src => src.IdTicketNavigation.IdSubscriberNavigation.IdCountryNavigation.Name))
                 .ForMember(dest => dest.SubscriberFlag, opt => opt?.MapFrom(src => src.IdTicketNavigation.IdSubscriberNavigation.IdCountryNavigation.FlagIso))
                 .ForMember(dest => dest.SubscriberIndications, opt => opt?.MapFrom(src => src.IdTicketNavigation.IdSubscriberNavigation.Indications))
                 .ForMember(dest => dest.InvestigatedContinent, opt => opt.MapFrom(src => src.IdTicketNavigation.About == "E" ? src.IdTicketNavigation.IdCompanyNavigation.IdCountryNavigation.IdContinentNavigation.Name : src.IdTicketNavigation.IdPersonNavigation.IdCountryNavigation.IdContinentNavigation.Name))

                .ForMember(dest => dest.InvestigatedIsoCountry, opt => opt.MapFrom(src => src.IdTicketNavigation.About == "E" ? src.IdTicketNavigation.IdCompanyNavigation.IdCountryNavigation.Iso : src.IdTicketNavigation.IdPersonNavigation.IdCountryNavigation.Iso))
                .ForMember(dest => dest.InvestigatedCountry, opt => opt.MapFrom(src => src.IdTicketNavigation.About == "E" ? src.IdTicketNavigation.IdCompanyNavigation.IdCountryNavigation.Iso : src.IdTicketNavigation.IdPersonNavigation.IdCountryNavigation.Iso))
                .ForMember(dest => dest.InvestigatedFlag, opt => opt.MapFrom(src => src.IdTicketNavigation.About == "E" ? src.IdTicketNavigation.IdCompanyNavigation.IdCountryNavigation.FlagIso : src.IdTicketNavigation.IdPersonNavigation.IdCountryNavigation.FlagIso))


                 .ForMember(dest => dest.OrderDate, opt => opt?.MapFrom(src => StaticFunctions.DateTimeToString(src.IdTicketNavigation.OrderDate)))
                 .ForMember(dest => dest.ExpireDate, opt => opt?.MapFrom(src => StaticFunctions.DateTimeToString(src.IdTicketNavigation.ExpireDate)))
                 .ForMember(dest => dest.RealExpireDate, opt => opt?.MapFrom(src => StaticFunctions.DateTimeToString(src.IdTicketNavigation.RealExpireDate)))

                 .ForMember(dest => dest.Price, opt => opt?.MapFrom(src => src.IdTicketNavigation.Price == null ? 0 : src.IdTicketNavigation.Price))
                 .ForMember(dest => dest.Quality, opt => opt?.MapFrom(src => src.IdTicketNavigation.Quality))
                 .ForMember(dest => dest.DispatchDate, opt => opt?.MapFrom(src => StaticFunctions.DateTimeToString(src.IdTicketNavigation.DispatchtDate)))
                 .ForMember(dest => dest.StatusQuery, opt => opt?.MapFrom(src => src.IdTicketNavigation.TicketQuery != null ? src.IdTicketNavigation.TicketQuery.Status : 0))
                  .ForMember(dest => dest.HasQuery, opt => opt?.MapFrom(src => src.IdTicketNavigation.TicketQuery != null))

                   .ForMember(dest => dest.Commentary, opt => opt?.MapFrom(src => src.IdTicketNavigation.TicketAssignation == null ? string.Empty : src.IdTicketNavigation.TicketAssignation.Commentary ?? string.Empty))
                .ForMember(dest => dest.Receptor, opt => opt?.MapFrom(src => src.IdTicketNavigation.TicketAssignation == null ? 0 : src.IdTicketNavigation.TicketAssignation.IdEmployeeNavigation.UserLogins.FirstOrDefault().Id))
                .ForMember(dest => dest.Receptor2, opt => opt?.MapFrom(src => src.IdTicketNavigation.TicketAssignation == null ? 0 : src.IdTicketNavigation.TicketAssignation.IdUserLogin))
                .ForMember(dest => dest.HasFiles, opt => opt?.MapFrom(src => src.IdTicketNavigation.TicketFiles.Count > 0))
                .ForMember(dest => dest.Files, opt => opt?.MapFrom(src => src.IdTicketNavigation.TicketFiles))
                .ForMember(dest => dest.AssinedTo, opt => opt?.MapFrom(src => src.AsignedTo))
                .ForMember(dest => dest.NumberAssign, opt => opt?.MapFrom(src => src.NumberAssign))
                .ForMember(dest => dest.Origen, opt => opt?.MapFrom(src => src.IdTicketNavigation.Web == false ? "E&E" : "WEB"))
                .ForMember(dest => dest.Observations, opt => opt?.MapFrom(src => src.Observations))
                .ForMember(dest => dest.StartDate, opt => opt?.MapFrom(src => StaticFunctions.DateTimeToString(src.StartDate)))
                .ForMember(dest => dest.EndDate, opt => opt?.MapFrom(src => StaticFunctions.DateTimeToString(src.EndDate)))
                .ForMember(dest => dest.References, opt => opt?.MapFrom(src => GetReferencesValue(src)))

                .ForMember(dest => dest.IsComplement, opt => opt.MapFrom(src => src.IdTicketNavigation.IsComplement))
                .ForMember(dest => dest.ComplementQuality, opt => opt.MapFrom(src => src.IdTicketNavigation.IsComplement == true ? src.IdTicketNavigation.IdTicketComplementNavigation.Quality : ""))
                .ForMember(dest => dest.ComplementQualityTranslator, opt => opt.MapFrom(src => src.IdTicketNavigation.IsComplement == true ? src.IdTicketNavigation.IdTicketComplementNavigation.QualityTranslator : ""))
                .ForMember(dest => dest.ComplementQualityTypist, opt => opt.MapFrom(src => src.IdTicketNavigation.IsComplement == true ? src.IdTicketNavigation.IdTicketComplementNavigation.QualityTypist : ""))

                  .ReverseMap();
        

            CreateMap<TicketHistory, GetListTicketResponseDto2>()
                .ForMember(dest => dest.IsAgent, opt => opt.MapFrom(src =>  src.IdTicketNavigation.TicketHistories != null ? GetIsAgent(src.IdTicketNavigation.TicketHistories) : default))
                .ForMember(dest => dest.AgentFrom, opt => opt.MapFrom(src => src.IdTicketNavigation.TicketHistories != null ? GetAgentFrom(src.IdTicketNavigation.TicketHistories) : default))
                .ForMember(dest => dest.StatusFinalOwner, opt => opt.MapFrom(src => src.IdTicketNavigation.TicketHistories != null ? GetStatusFinalOwner(src.IdTicketNavigation.TicketHistories) : default))
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.IdTicket, opt => opt.MapFrom(src => src.IdTicket))
                .ForMember(dest => dest.IdSubscriber, opt => opt.MapFrom(src => src.IdTicketNavigation.IdSubscriber ?? 0))
                .ForMember(dest => dest.ProcedureType, opt => opt.MapFrom(src => src.IdTicketNavigation.ProcedureType.Trim() ?? string.Empty))
                .ForMember(dest => dest.IdContinent, opt => opt.MapFrom(src => src.IdTicketNavigation.IdContinent ?? 0))
                .ForMember(dest => dest.IdCountry, opt => opt.MapFrom(src => src.IdTicketNavigation.IdCountry ?? 0))
                .ForMember(dest => dest.IdCompany, opt => opt.MapFrom(src => src.IdTicketNavigation.IdCompany ?? 0))
                .ForMember(dest => dest.IdPerson, opt => opt.MapFrom(src => src.IdTicketNavigation.IdPerson ?? 0))
                .ForMember(dest => dest.Number, opt => opt.MapFrom(src => src.IdTicketNavigation.IsComplement == true ? src.IdTicketNavigation.About + " - " + src.IdTicketNavigation.Number.ToString("D6") + " (C) " : src.IdTicketNavigation.About + " - " + src.IdTicketNavigation.Number.ToString("D6")))
                .ForMember(dest => dest.Status, opt => opt.MapFrom(src => src.IdStatusTicketNavigation.Abrev ?? string.Empty))
                .ForMember(dest => dest.StatusColor, opt => opt.MapFrom(src => src.IdStatusTicketNavigation.Color ?? string.Empty))
                .ForMember(dest => dest.Language, opt => opt.MapFrom(src => src.IdTicketNavigation.Language ?? string.Empty))
                .ForMember(dest => dest.About, opt => opt.MapFrom(src => src.IdTicketNavigation.About ?? string.Empty))
                .ForMember(dest => dest.AsignedTo, opt => opt.MapFrom(src => src.AsignedTo ?? string.Empty))
                .ForMember(dest => dest.QueryCredit, opt => opt.MapFrom(src => src.IdTicketNavigation.QueryCredit ?? string.Empty))
                .ForMember(dest => dest.TimeLimit, opt => opt.MapFrom(src => src.IdTicketNavigation.TimeLimit ?? string.Empty))
                .ForMember(dest => dest.RevealName, opt => opt.MapFrom(src => src.IdTicketNavigation.RevealName ?? false))
                .ForMember(dest => dest.NameRevealed, opt => opt.MapFrom(src => src.IdTicketNavigation.NameRevealed ?? string.Empty))
                .ForMember(dest => dest.ReferenceNumber, opt => opt.MapFrom(src => src.IdTicketNavigation.ReferenceNumber ?? string.Empty))
                .ForMember(dest => dest.AditionalData, opt => opt.MapFrom(src => src.IdTicketNavigation.AditionalData ?? string.Empty))
                .ForMember(dest => dest.BusineesName, opt => opt.MapFrom(src => src.IdTicketNavigation.RequestedName ?? string.Empty))
                .ForMember(dest => dest.ComercialName, opt => opt.MapFrom(src => src.IdTicketNavigation.ComercialName ?? string.Empty))
                .ForMember(dest => dest.RequestedName, opt => opt.MapFrom(src => src.IdTicketNavigation.RequestedName ?? string.Empty))
                .ForMember(dest => dest.TaxType, opt => opt.MapFrom(src => src.IdTicketNavigation.TaxType ?? string.Empty))
                .ForMember(dest => dest.TaxCode, opt => opt.MapFrom(src => src.IdTicketNavigation.TaxCode ?? string.Empty))
                .ForMember(dest => dest.City, opt => opt.MapFrom(src => src.IdTicketNavigation.City ?? string.Empty))
                .ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.IdTicketNavigation.Email ?? string.Empty))
                .ForMember(dest => dest.Address, opt => opt.MapFrom(src => src.IdTicketNavigation.Address ?? string.Empty))
                .ForMember(dest => dest.Telephone, opt => opt.MapFrom(src => src.IdTicketNavigation.Telephone ?? string.Empty))
                .ForMember(dest => dest.ReportType, opt => opt.MapFrom(src => src.IdTicketNavigation.ReportType ?? string.Empty))
                .ForMember(dest => dest.HasBalance, opt => opt.MapFrom(src => src.IdTicketNavigation.HasBalance ?? null))
                .ForMember(dest => dest.DispatchDate, opt => opt.MapFrom(src => StaticFunctions.DateTimeToString(src.IdTicketNavigation.DispatchtDate) ?? string.Empty))

                .ForMember(dest => dest.SubscriberCode, opt => opt.MapFrom(src => src.IdTicketNavigation.IdSubscriberNavigation.Code ?? string.Empty))
                .ForMember(dest => dest.SubscriberName, opt => opt.MapFrom(src => src.IdTicketNavigation.IdSubscriberNavigation.Name ?? string.Empty))
                .ForMember(dest => dest.SubscriberCountry, opt => opt.MapFrom(src => src.IdTicketNavigation.IdSubscriberNavigation.IdCountryNavigation.Name ?? string.Empty))
                .ForMember(dest => dest.SubscriberFlag, opt => opt.MapFrom(src => src.IdTicketNavigation.IdSubscriberNavigation.IdCountryNavigation.FlagIso ?? string.Empty))
                .ForMember(dest => dest.SubscriberIndications, opt => opt.MapFrom(src => src.IdTicketNavigation.IdSubscriberNavigation.Indications ?? string.Empty))

                .ForMember(dest => dest.InvestigatedContinent, opt => opt.MapFrom(src => src.IdTicketNavigation.About == "E" ? src.IdTicketNavigation.IdCompanyNavigation.IdCountryNavigation.IdContinentNavigation.Name : src.IdTicketNavigation.IdPersonNavigation.IdCountryNavigation.IdContinentNavigation.Name))

                .ForMember(dest => dest.InvestigatedIsoCountry, opt => opt.MapFrom(src => src.IdTicketNavigation.About == "E" ? src.IdTicketNavigation.IdCompanyNavigation.IdCountryNavigation.Iso : src.IdTicketNavigation.IdPersonNavigation.IdCountryNavigation.Iso))
                .ForMember(dest => dest.InvestigatedCountry, opt => opt.MapFrom(src => src.IdTicketNavigation.About == "E" ? src.IdTicketNavigation.IdCompanyNavigation.IdCountryNavigation.Name : src.IdTicketNavigation.IdPersonNavigation.IdCountryNavigation.Name))
                .ForMember(dest => dest.InvestigatedFlag, opt => opt.MapFrom(src => src.IdTicketNavigation.About == "E" ? src.IdTicketNavigation.IdCompanyNavigation.IdCountryNavigation.FlagIso : src.IdTicketNavigation.IdPersonNavigation.IdCountryNavigation.FlagIso))
                .ForMember(dest => dest.OrderDate, opt => opt.MapFrom(src => StaticFunctions.DateTimeToString(src.IdTicketNavigation.OrderDate) ?? string.Empty))
                .ForMember(dest => dest.ExpireDate, opt => opt.MapFrom(src => StaticFunctions.DateTimeToString(src.IdTicketNavigation.ExpireDate) ?? string.Empty))
                .ForMember(dest => dest.RealExpireDate, opt => opt.MapFrom(src => StaticFunctions.DateTimeToString(src.IdTicketNavigation.RealExpireDate) ?? string.Empty))
                .ForMember(dest => dest.Price, opt => opt.MapFrom(src => src.IdTicketNavigation.Price ?? 0))
                .ForMember(dest => dest.Quality, opt => opt.MapFrom(src => src.IdTicketNavigation.Quality ?? ""))
                .ForMember(dest => dest.QualityTypist, opt => opt.MapFrom(src => src.IdTicketNavigation.QualityTypist ?? ""))
                .ForMember(dest => dest.QualityTranslator, opt => opt.MapFrom(src => src.IdTicketNavigation.QualityTranslator ?? ""))
                .ForMember(dest => dest.QualityReport, opt => opt.MapFrom(src => src.IdTicketNavigation.About == "E" ? src.IdTicketNavigation.IdCompanyNavigation.Quality : src.IdTicketNavigation.IdPersonNavigation.Quality))

                .ForMember(dest => dest.StatusQuery, opt => opt.MapFrom(src => src.IdTicketNavigation.TicketQuery != null ? src.IdTicketNavigation.TicketQuery.Status : 0))
                .ForMember(dest => dest.HasQuery, opt => opt.MapFrom(src => src.IdTicketNavigation.TicketQuery != null))
                .ForMember(dest => dest.Commentary, opt => opt.MapFrom(src => src.ReturnMessage.IsNullOrEmpty() == false ? (src.IdTicketNavigation.TicketAssignation != null ? src.IdTicketNavigation.TicketAssignation.Commentary : "") + "" + src.ReturnMessage : (src.IdTicketNavigation.TicketAssignation != null ? src.IdTicketNavigation.TicketAssignation.Commentary : "") + ""))
                .ForMember(dest => dest.Receptor, opt => opt.MapFrom(src => src.IdTicketNavigation.TicketAssignation.IdEmployeeNavigation != null && src.IdTicketNavigation.TicketAssignation.IdEmployeeNavigation.UserLogins != null ? src.IdTicketNavigation.TicketAssignation.IdEmployeeNavigation.UserLogins.FirstOrDefault().Id : 0))
                .ForMember(dest => dest.Receptor2, opt => opt.MapFrom(src => src.IdTicketNavigation.TicketAssignation.IdUserLogin ?? 0))
                .ForMember(dest => dest.HasFiles, opt => opt.MapFrom(src => src.IdTicketNavigation.TicketFiles != null && src.IdTicketNavigation.TicketFiles.Count > 0))

                .ForMember(dest => dest.Files, opt => opt.MapFrom(src => src.IdTicketNavigation.TicketFiles))
                .ForMember(dest => dest.AssinedTo, opt => opt.MapFrom(src => src.AsignedTo ?? string.Empty))
                .ForMember(dest => dest.NumberAssign, opt => opt.MapFrom(src => src.NumberAssign))

                .ForMember(dest => dest.References, opt => opt?.MapFrom(src => GetReferencesValue(src)))
                .ForMember(dest => dest.Origen, opt => opt.MapFrom(src => src.IdTicketNavigation.Web == false ? "E&E" : "WEB"))
                .ForMember(dest => dest.Observations, opt => opt.MapFrom(src => src.Observations  ?? string.Empty))
                .ForMember(dest => dest.StartDate, opt => opt.MapFrom(src => StaticFunctions.DateTimeToString(src.StartDate)))
                .ForMember(dest => dest.EndDate, opt => opt.MapFrom(src => StaticFunctions.DateTimeToString(src.EndDate)))
                .ForMember(dest => dest.WebPage, opt => opt.MapFrom(src => src.IdTicketNavigation.About == "E" ? src.IdTicketNavigation.IdCompanyNavigation.WebPage ?? string.Empty : string.Empty))

                .ForMember(dest => dest.IsComplement, opt => opt.MapFrom(src => src.IdTicketNavigation.IsComplement))
                .ForMember(dest => dest.ComplementQuality, opt => opt.MapFrom(src => src.IdTicketNavigation.IsComplement == true ? src.IdTicketNavigation.IdTicketComplementNavigation.Quality : ""))
                .ForMember(dest => dest.ComplementQualityTranslator, opt => opt.MapFrom(src => src.IdTicketNavigation.IsComplement == true ? src.IdTicketNavigation.IdTicketComplementNavigation.QualityTranslator : ""))
                .ForMember(dest => dest.ComplementQualityTypist, opt => opt.MapFrom(src => src.IdTicketNavigation.IsComplement == true ? src.IdTicketNavigation.IdTicketComplementNavigation.QualityTypist : ""))
                .ReverseMap();


            CreateMap<Ticket, GetListPendingTicketResponseDto>()
                .ForMember(dest => dest.ProcedureType, opt => opt?.MapFrom(src => src.ProcedureType == null ? string.Empty : src.ProcedureType.Trim()))
                .ForMember(dest => dest.Number, opt => opt?.MapFrom(src => src.Number.ToString("D6")))
                .ForMember(dest => dest.Name, opt => opt?.MapFrom(src => src.BusineesName))
                .ForMember(dest => dest.Commentary, opt => opt?.MapFrom(src => src.TicketAssignation==null?string.Empty:src.TicketAssignation.Commentary??string.Empty))
                .ForMember(dest => dest.Receptor, opt => opt?.MapFrom(src => src.TicketAssignation == null?0:src.TicketAssignation.IdEmployeeNavigation.UserLogins.FirstOrDefault().Id))
              //  .ForMember(dest => dest.Receptor2, opt => opt?.MapFrom(src => src.TicketAssignation == null ? 0 : src.TicketAssignation.IdUserLogin))
                .ForMember(dest => dest.HasFiles, opt => opt?.MapFrom(src => src.TicketFiles.Count>0))
                .ForMember(dest => dest.Files, opt => opt?.MapFrom(src => src.TicketFiles))
                .ForMember(dest => dest.OrderDate, opt => opt?.MapFrom(src => StaticFunctions.DateTimeToString(src.OrderDate)))
                .ForMember(dest => dest.ExpireDate, opt => opt?.MapFrom(src => StaticFunctions.DateTimeToString(src.ExpireDate)))
                
                .ReverseMap();
            CreateMap<Personal, GetPersonalAssignationResponseDto>()
                .ForMember(dest => dest.IdEmployee, opt => opt?.MapFrom(src => src.IdEmployee == null ? 0 : src.IdEmployee))
                .ForMember(dest => dest.Fullname, opt => opt?.MapFrom(src => src.IdEmployeeNavigation == null ? "" : src.IdEmployeeNavigation.FirstName.ToUpper() + " " + src.IdEmployeeNavigation.LastName.ToUpper()))
                .ForMember(dest => dest.Type, opt => opt?.MapFrom(src => src.Type))
                .ForMember(dest => dest.Code, opt => opt?.MapFrom(src => src.Code == null ? "" : src.Code))
                .ForMember(dest => dest.IdUserLogin, opt => opt?.MapFrom(src => src.IdEmployeeNavigation != null ? src.IdEmployeeNavigation.UserLogins.FirstOrDefault().Id : 0))
                .ForMember(dest => dest.Internal, opt => opt?.MapFrom(src => src.Internal))
                .ReverseMap();

            CreateMap<Company, GetSearchSituationResponseDto>()
               .ForMember(dest => dest.IdPerson, opt => opt?.MapFrom(src => 0))
               .ForMember(dest => dest.IdCompany, opt => opt?.MapFrom(src => src.Id == null ? 0 : src.Id))
               .ForMember(dest => dest.OldCode, opt => opt?.MapFrom(src => src.OldCode))
               .ForMember(dest => dest.Name, opt => opt?.MapFrom(src => src.Name))
               .ForMember(dest => dest.TaxName, opt => opt?.MapFrom(src => src.TaxTypeName == null ? "" : src.TaxTypeName))
               .ForMember(dest => dest.TaxCode, opt => opt?.MapFrom(src => src.TaxTypeCode == null ? "" : src.TaxTypeCode))
               .ForMember(dest => dest.Telephone, opt => opt?.MapFrom(src => src.Cellphone))
               .ForMember(dest => dest.IdCountry, opt => opt?.MapFrom(src => src.IdCountry == null ? 0 : src.IdCountry))
               .ForMember(dest => dest.Country, opt => opt?.MapFrom(src => src.IdCountry == null ? "" : src.IdCountryNavigation.Name))
               .ForMember(dest => dest.FlagCountry, opt => opt?.MapFrom(src => src.IdCountry == null ? "" : src.IdCountryNavigation.FlagIso))
               .ReverseMap(); 
            CreateMap<Person, GetSearchSituationResponseDto>()
               .ForMember(dest => dest.IdPerson, opt => opt?.MapFrom(src => src.Id == null ? 0 : src.Id))
               .ForMember(dest => dest.IdCompany, opt => opt?.MapFrom(src => 0))
               .ForMember(dest => dest.OldCode, opt => opt?.MapFrom(src => src.OldCode))
               .ForMember(dest => dest.Name, opt => opt?.MapFrom(src => src.Fullname))
               .ForMember(dest => dest.TaxName, opt => opt?.MapFrom(src => src.TaxTypeName == null ? "" : src.TaxTypeName))
               .ForMember(dest => dest.TaxCode, opt => opt?.MapFrom(src => src.TaxTypeCode == null ? "" : src.TaxTypeCode))
               .ForMember(dest => dest.Telephone, opt => opt?.MapFrom(src => src.Cellphone))
               .ForMember(dest => dest.IdCountry, opt => opt?.MapFrom(src => src.IdCountry == null ? 0 : src.IdCountry))
               .ForMember(dest => dest.Country, opt => opt?.MapFrom(src => src.IdCountry == null ? "" : src.IdCountryNavigation.Name))
               .ForMember(dest => dest.FlagCountry, opt => opt?.MapFrom(src => src.IdCountry == null ? "" : src.IdCountryNavigation.FlagIso))
               .ReverseMap();
            CreateMap<Ticket, GetTicketsByCompanyOrPersonResponseDto>()
              .ForMember(dest => dest.Id, opt => opt?.MapFrom(src => src.Id == null ? 0 : src.Id))
              .ForMember(dest => dest.Ticket, opt => opt?.MapFrom(src => src.IsComplement == true ? "N - " + src.Number.ToString("D6") + " (C) " : "N - " + src.Number.ToString("D6")))
              .ForMember(dest => dest.IdStatusTicket, opt => opt?.MapFrom(src => src.IdStatusTicket == null ? 0 : src.IdStatusTicket))
              .ForMember(dest => dest.Status, opt => opt?.MapFrom(src => src.IdStatusTicketNavigation.Abrev))
              .ForMember(dest => dest.Color, opt => opt?.MapFrom(src => src.IdStatusTicketNavigation.Color))
              .ForMember(dest => dest.RequestedName, opt => opt?.MapFrom(src => src.RequestedName.IsNullOrEmpty() == true ? src.BusineesName : src.RequestedName))
              .ForMember(dest => dest.SubscriberCode, opt => opt?.MapFrom(src => src.IdSubscriberNavigation.Code))
              .ForMember(dest => dest.ProcedureType, opt => opt?.MapFrom(src => src.ProcedureType))
              .ForMember(dest => dest.ReportType, opt => opt?.MapFrom(src => src.ReportType))
              .ForMember(dest => dest.Language, opt => opt?.MapFrom(src => src.Language))
              .ForMember(dest => dest.OrderDate, opt => opt?.MapFrom(src => StaticFunctions.DateTimeToString(src.OrderDate)))
              .ForMember(dest => dest.EndDate, opt => opt?.MapFrom(src => StaticFunctions.DateTimeToString(src.ExpireDate)))
              .ForMember(dest => dest.DispatchDate, opt => opt?.MapFrom(src => StaticFunctions.DateTimeToString(src.DispatchtDate)))
              .ReverseMap(); 
            CreateMap<Agent, GetPersonalAssignationResponseDto>()
                .ForMember(dest => dest.IdEmployee, opt => opt?.MapFrom(src => src.Id == null ? 0 : src.Id))
                .ForMember(dest => dest.IdUserLogin, opt => opt?.MapFrom(src => src.Id == null ? 0 : src.Id))
                .ForMember(dest => dest.Fullname, opt => opt?.MapFrom(src => src.Name == null ? "" : src.Name.ToUpper()))
                .ForMember(dest => dest.Type, opt => opt?.MapFrom(src => "AG"))
                .ForMember(dest => dest.Code, opt => opt?.MapFrom(src => src.Code == null ? "" : src.Code))
                .ForMember(dest => dest.Internal, opt => opt?.MapFrom(src => src.Internal))
                .ReverseMap();
            CreateMap<TicketHistory, GetTimeLineTicketHistoryResponseDto>()
                .ForMember(dest => dest.Id, opt => opt?.MapFrom(src => src.Id == null ? 0 : src.Id))
                .ForMember(dest => dest.AssignedTo, opt => opt?.MapFrom(src => src.AsignedTo == null ? "" : src.AsignedTo.ToUpper()))
                .ForMember(dest => dest.Date, opt => opt?.MapFrom(src => StaticFunctions.DateTimeToString(src.CreationDate)))
                .ForMember(dest => dest.Time, opt => opt?.MapFrom(src => src.CreationDate.Hour.ToString("00") + ":" + src.CreationDate.Minute.ToString("00")))
                .ForMember(dest => dest.Status, opt => opt?.MapFrom(src => src.IdStatusTicketNavigation.Description))
                .ReverseMap();
            CreateMap<TicketFileResponseDto, TicketFile>().ReverseMap();
            CreateMap<GetTicketFileResponseDto, TicketFile>().ReverseMap();
            CreateMap<TicketQuery, GetTicketQueryResponseDto>()
             .ForMember(dest => dest.QueryDate, opt => opt?.MapFrom(src => StaticFunctions.DateTimeToString(src.QueryDate)))
             .ForMember(dest => dest.SubscriberName, opt => opt?.MapFrom(src =>src.IdSubscriberNavigation==null?string.Empty: src.IdSubscriberNavigation.Code +"||"+src.IdSubscriberNavigation.Name))
             .ForMember(dest => dest.Report, opt => opt?.MapFrom(src => src.IdTicketNavigation == null ? string.Empty : src.IdTicketNavigation.RequestedName))
             .ForMember(dest => dest.Response, opt => opt?.MapFrom(src => src.IdTicketNavigation == null ? string.Empty : src.Response))
            .ReverseMap();

            CreateMap<SendTicketQueryRequestDto, TicketQuery>()
            .ForMember(dest => dest.QueryDate, opt => opt?.MapFrom(src => StaticFunctions.VerifyDate(src.QueryDate)))
            .ForMember(dest => dest.Status, opt => opt?.MapFrom(src =>(int?)TicketQueryEnum.En_Consulta))          
            .ReverseMap();

        }

        private string GetStatusFinalOwner(ICollection<TicketHistory> ticketHistories)
        {
            var lastHistory = ticketHistories.FirstOrDefault();

            if (lastHistory == null) return string.Empty;

            switch (lastHistory.IdStatusTicket)
            {
                case (int?)TicketStatusEnum.Asig_Agente:
                case (int?)TicketStatusEnum.Asig_Digitidor:
                case (int?)TicketStatusEnum.Asig_Reportero:
                case (int?)TicketStatusEnum.Asig_Traductor:
                case (int?)TicketStatusEnum.Asig_Supervisor:
                case (int?)TicketStatusEnum.Asig_Multiple:
                    return lastHistory.AsignedTo??string.Empty;
                case (int?)TicketStatusEnum.En_Consulta:
                    return "Abonado";
                default:
                    return string.Empty;
            }
        }
        private bool GetIsAgent(ICollection<TicketHistory> ticketHistories)
        {
            return ticketHistories.Any(x => x.AsignedTo != null && x.AsignedTo.StartsWith("A"));
        }

        private string GetAgentFrom(ICollection<TicketHistory> ticketHistories)
        {
            if (ticketHistories == null)
            {
                return string.Empty;
            }

            var history = ticketHistories.FirstOrDefault(x => x.AsignedTo != null && x.AsignedTo.StartsWith("A"));

            return history != null ? history.AsignedTo : string.Empty;
        }


        private static int GetReferencesValue(TicketHistory ticketHistory)
        {
            if(ticketHistory.IdTicketNavigation.TicketHistories.Any(x =>x.AsignationType!=null && x.AsignationType.Contains("RF") == true))
            {
                if (ticketHistory.IdTicketNavigation.TicketHistories.Where(x => x.AsignationType.Contains("RF") == true).FirstOrDefault().Flag == false)
                {
                    return 0; 
                }
                else
                {
                    return 1;
                }
            }
            else
            {
                return -1;
            }
        }
        private static string GetProcedureType(string? tram)
        {
            if (!string.IsNullOrEmpty(tram))
            {
                var value = int.Parse(tram);
                if (value <= 8)
                {
                    return "T" + value;
                }
                else
                {
                    switch (value)
                    {
                        case 9:
                            return "O1";
                        case 10:
                            return "O2";
                        case 11:
                            return "O3";
                    }
                }
            }
            return string.Empty;
        }
      
    }
}                                                                                                                                                   
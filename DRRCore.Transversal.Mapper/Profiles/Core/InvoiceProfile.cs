using AutoMapper;
using DRRCore.Application.DTO.Core.Response;
using DRRCore.Domain.Entities.SqlCoreContext;
using DRRCore.Transversal.Common;

namespace DRRCore.Transversal.Mapper.Profiles.Core
{
    public class InvoiceProfile : Profile
    {
        public InvoiceProfile()
        {
            CreateMap<Ticket, GetInvoiceSubscriberListResponseDto>()
                .ForMember(dest => dest.IdTicket, opt => opt?.MapFrom(src => src.Id))
                .ForMember(dest => dest.Number, opt => opt?.MapFrom(src => src.Number.ToString("D6")))
                .ForMember(dest => dest.RequestedName, opt => opt?.MapFrom(src => src.RequestedName))
                .ForMember(dest => dest.DispatchedName, opt => opt?.MapFrom(src => src.DispatchedName))
                .ForMember(dest => dest.OrderDate, opt => opt?.MapFrom(src => StaticFunctions.DateTimeToString(src.OrderDate)))
                .ForMember(dest => dest.ExpireDate, opt => opt?.MapFrom(src => StaticFunctions.DateTimeToString(src.ExpireDate)))
                .ForMember(dest => dest.DispatchDate, opt => opt?.MapFrom(src => StaticFunctions.DateTimeToString(src.DispatchtDate)))
                .ForMember(dest => dest.Country, opt => opt?.MapFrom(src => src.IdCountry != null ? src.IdCountryNavigation.Name : ""))
                .ForMember(dest => dest.FlagCountry, opt => opt?.MapFrom(src => src.IdCountry != null ? src.IdCountryNavigation.FlagIso : ""))
                .ForMember(dest => dest.SubscriberName, opt => opt?.MapFrom(src => src.IdSubscriber != null ? src.IdSubscriberNavigation.Name : ""))
                .ForMember(dest => dest.SubscriberCode, opt => opt?.MapFrom(src => src.IdSubscriber != null ? src.IdSubscriberNavigation.Code : ""))
                .ForMember(dest => dest.IdInvoiceState, opt => opt?.MapFrom(src => src.IdInvoiceState != null ? src.IdInvoiceState : 0))
             .ReverseMap();
            CreateMap<TicketHistory, GetInvoiceAgentListResponseDto>()
                .ForMember(dest => dest.IdTicket, opt => opt?.MapFrom(src => src.IdTicketNavigation.Id))
                .ForMember(dest => dest.IdTicketHistory, opt => opt?.MapFrom(src => src.Id))
                .ForMember(dest => dest.Number, opt => opt?.MapFrom(src => src.IdTicketNavigation.Number.ToString("D6")))
                .ForMember(dest => dest.RequestedName, opt => opt?.MapFrom(src => src.IdTicketNavigation.RequestedName))
                .ForMember(dest => dest.DispatchedName, opt => opt?.MapFrom(src => src.IdTicketNavigation.DispatchedName))
                .ForMember(dest => dest.ProcedureType, opt => opt?.MapFrom(src => src.IdTicketNavigation.ProcedureType))
                .ForMember(dest => dest.ReportType, opt => opt?.MapFrom(src => src.IdTicketNavigation.ReportType))
                .ForMember(dest => dest.OrderDate, opt => opt?.MapFrom(src => StaticFunctions.DateTimeToString(src.IdTicketNavigation.OrderDate)))
                .ForMember(dest => dest.ExpireDate, opt => opt?.MapFrom(src => StaticFunctions.DateTimeToString(src.IdTicketNavigation.ExpireDate)))
                .ForMember(dest => dest.ShippingDate, opt => opt?.MapFrom(src => StaticFunctions.DateTimeToString(src.ShippingDate)))
                .ForMember(dest => dest.Country, opt => opt?.MapFrom(src => src.IdTicketNavigation.IdCountry != null ? src.IdTicketNavigation.IdCountryNavigation.Name : ""))
                .ForMember(dest => dest.FlagCountry, opt => opt?.MapFrom(src => src.IdTicketNavigation.IdCountry != null ? src.IdTicketNavigation.IdCountryNavigation.FlagIso : ""))
                .ForMember(dest => dest.IdAgent, opt => opt?.MapFrom(src => src.UserTo))
                .ForMember(dest => dest.AgentName, opt => opt?.MapFrom(src => src.AsignedTo))
                .ForMember(dest => dest.AgentCode, opt => opt?.MapFrom(src => src.AsignedTo))
             .ReverseMap();
        }
    }
}

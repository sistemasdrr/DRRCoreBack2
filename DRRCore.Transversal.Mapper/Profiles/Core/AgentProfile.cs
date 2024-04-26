using AutoMapper;
using DRRCore.Application.DTO.Core.Request;
using DRRCore.Application.DTO.Core.Response;
using DRRCore.Domain.Entities.SqlCoreContext;
using DRRCore.Transversal.Common;

namespace DRRCore.Transversal.Mapper.Profiles.Core
{
    public class AgentProfile : Profile
    {
        public AgentProfile()
        {
            CreateMap<AddOrUpdateAgentResponseDto, Agent>()
           .ForMember(dest => dest.StartDate, opt => opt?.MapFrom(src => StaticFunctions.VerifyDate(src.StartDate)))
           .ForMember(dest => dest.IdCountry, opt => opt?.MapFrom(src => src.IdCountry == 0 ? null : src.IdCountry))
       .ReverseMap();
            CreateMap<Agent, GetListAgentResponseDto>()
           .ForMember(dest => dest.Country, opt => opt?.MapFrom(src => src.IdCountryNavigation.Iso))
           .ForMember(dest => dest.FlagCountry, opt => opt?.MapFrom(src => src.IdCountryNavigation.FlagIso))
           .ForMember(dest => dest.Status, opt => opt?.MapFrom(src => src.State))
       .ReverseMap();
        CreateMap<AddOrUpdateAgentPriceRequestDto, AgentPrice>()
           .ForMember(dest => dest.Date, opt => opt?.MapFrom(src => StaticFunctions.VerifyDate(src.Date)))
           .ForMember(dest => dest.IdAgent, opt => opt?.MapFrom(src => src.IdAgent == 0 ? null : src.IdAgent))
           .ForMember(dest => dest.IdContinent, opt => opt?.MapFrom(src => src.IdContinent == 0 ? null : src.IdContinent))
           .ForMember(dest => dest.IdCountry, opt => opt?.MapFrom(src => src.IdCountry == 0 ? null : src.IdCountry))
           .ForMember(dest => dest.IdCurrency, opt => opt?.MapFrom(src => src.IdCurrency == 0 ? null : src.IdCurrency))
       .ReverseMap();
            CreateMap<AgentPrice, GetListAgentPriceResponseDto>()
         .ForMember(dest => dest.Date, opt => opt?.MapFrom(src => StaticFunctions.DateTimeToString(src.Date)))
         .ForMember(dest => dest.IdAgente, opt => opt?.MapFrom(src => src.IdAgent == 0 ? null : src.IdAgent))
         .ForMember(dest => dest.Country, opt => opt?.MapFrom(src => src.IdCountryNavigation.Iso == null ? "" : src.IdCountryNavigation.Iso))
         .ForMember(dest => dest.FlagCountry, opt => opt?.MapFrom(src => src.IdCountryNavigation.FlagIso == null ? "" : src.IdCountryNavigation.FlagIso))
         .ForMember(dest => dest.PriceT1, opt => opt?.MapFrom(src => src.PriceT1 + " / " + src.DayT1))
         .ForMember(dest => dest.PriceT2, opt => opt?.MapFrom(src => src.PriceT2 + " / " + src.DayT2))
         .ForMember(dest => dest.PriceT3, opt => opt?.MapFrom(src => src.PriceT3 + " / " + src.DayT3))
         .ForMember(dest => dest.PricePN, opt => opt?.MapFrom(src => src.PricePn + " / " + src.DayPn))
         .ForMember(dest => dest.PriceBD, opt => opt?.MapFrom(src => src.PriceBd + " / " + src.DayBd))
         .ForMember(dest => dest.PriceRP, opt => opt?.MapFrom(src => src.PriceRp + " / " + src.DayRp))
         .ForMember(dest => dest.PriceCR, opt => opt?.MapFrom(src => src.PriceCr + " / " + src.DayCr))
         .ForMember(dest => dest.Currency, opt => opt?.MapFrom(src => src.IdCurrencyNavigation.Abreviation))
     .ReverseMap();
        }
    }
}

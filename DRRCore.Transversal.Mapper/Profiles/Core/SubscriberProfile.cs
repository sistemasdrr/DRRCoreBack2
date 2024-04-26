using AutoMapper;
using DRRCore.Application.DTO.Core.Request;
using DRRCore.Application.DTO.Core.Response;
using DRRCore.Domain.Entities.SqlCoreContext;
using DRRCore.Transversal.Common;

namespace DRRCore.Transversal.Mapper.Profiles.Core
{
    public class SubscriberProfile : Profile
    {
        public SubscriberProfile() 
        {
            CreateMap<AddOrUpdateSubscriberRequestDto, Subscriber>()
            .ForMember(dest => dest.StartDate, opt => opt?.MapFrom(src => StaticFunctions.VerifyDate(src.StartDate)))
            .ForMember(dest => dest.IdContinent, opt => opt?.MapFrom(src => src.IdContinent == 0 ? null : src.IdContinent))
            .ForMember(dest => dest.IdCountry, opt => opt?.MapFrom(src => src.IdCountry == 0 ? null : src.IdCountry))
            .ForMember(dest => dest.IdCurrency, opt => opt?.MapFrom(src => src.IdCurrency == 0 ? null : src.IdCurrency))
            .ForMember(dest => dest.IdSubscriberCategory, opt => opt?.MapFrom(src => src.IdSubscriberCategory == 0 ? null : src.IdSubscriberCategory))
        .ReverseMap();
            CreateMap<Subscriber, GetListSubscriberResponseDto>()
            .ForMember(dest => dest.Id, opt => opt?.MapFrom(src => src.Id))
            .ForMember(dest => dest.Code, opt => opt?.MapFrom(src => src.Code))
            .ForMember(dest => dest.Name, opt => opt?.MapFrom(src => src.Name))
            .ForMember(dest => dest.Acronym, opt => opt?.MapFrom(src => src.Acronym))
            .ForMember(dest => dest.Address, opt => opt?.MapFrom(src => src.Address))
            .ForMember(dest => dest.Country, opt => opt?.MapFrom(src => src.IdCountryNavigation != null ? src.IdCountryNavigation.Name : string.Empty))
            .ForMember(dest => dest.IsoCountry, opt => opt?.MapFrom(src => src.IdCountryNavigation != null ? src.IdCountryNavigation.Iso : string.Empty))
            .ForMember(dest => dest.FlagCountry, opt => opt?.MapFrom(src => src.IdCountryNavigation != null ? src.IdCountryNavigation.FlagIso : string.Empty))
            .ForMember(dest => dest.FacturationType, opt => opt?.MapFrom(src => src.FacturationType))
            .ForMember(dest => dest.Enable, opt => opt?.MapFrom(src => src.Enable))
        .ReverseMap();
            CreateMap<Subscriber, GetSubscriberResponseDto>()
            .ForMember(dest => dest.Id, opt => opt?.MapFrom(src => src.Id))
            .ForMember(dest => dest.IdContinent, opt => opt?.MapFrom(src => src.IdContinent))
            .ForMember(dest => dest.IdCountry, opt => opt?.MapFrom(src => src.IdCountry))
            .ForMember(dest => dest.StartDate, opt => opt?.MapFrom(src => src.StartDate))
            .ForMember(dest => dest.IdCurrency, opt => opt?.MapFrom(src => src.IdCurrency))
            .ForMember(dest => dest.Enable, opt => opt?.MapFrom(src => src.Enable))
            .ForMember(dest => dest.RemainingCoupons, opt => opt?.MapFrom(src => src.CouponBillingSubscribers.First().NumCoupon))
        .ReverseMap(); 
                 CreateMap<Subscriber, GetSubscriberDataResponseDto>()
            .ForMember(dest => dest.Id, opt => opt?.MapFrom(src => src.Id))
            .ForMember(dest => dest.Code, opt => opt?.MapFrom(src => src.Code))
            .ForMember(dest => dest.Name, opt => opt?.MapFrom(src => src.Name))
            .ForMember(dest => dest.TypeFact, opt => opt?.MapFrom(src => src.FacturationType))
        .ReverseMap();
            CreateMap<AddOrUpdateSubscriberPriceRequestDto, SubscriberPrice>()
            .ForMember(dest => dest.Date, opt => opt?.MapFrom(src => StaticFunctions.VerifyDate(src.Date)))
            .ForMember(dest => dest.IdSubscriber, opt => opt?.MapFrom(src => src.IdSubscriber == 0 ? null : src.IdSubscriber))
            .ForMember(dest => dest.IdContinent, opt => opt?.MapFrom(src => src.IdContinent == 0 ? null : src.IdContinent))
            .ForMember(dest => dest.IdCountry, opt => opt?.MapFrom(src => src.IdCountry == 0 ? null : src.IdCountry))
            .ForMember(dest => dest.IdCurrency, opt => opt?.MapFrom(src => src.IdCurrency == 0 ? null : src.IdCurrency))
        .ReverseMap();
            CreateMap<SubscriberPrice, GetSuscriberPriceResponseDto>()
           .ForMember(dest => dest.Date, opt => opt?.MapFrom(src => StaticFunctions.DateTimeToString(src.Date)))
           .ForMember(dest => dest.Country, opt => opt?.MapFrom(src => src.IdCountryNavigation != null ? src.IdCountryNavigation.Iso : string.Empty))
           .ForMember(dest => dest.FlagCountry, opt => opt?.MapFrom(src => src.IdCountryNavigation != null ? src.IdCountryNavigation.FlagIso : string.Empty))
           .ForMember(dest => dest.Currency, opt => opt?.MapFrom(src => src.IdCurrencyNavigation!= null ? src.IdCurrencyNavigation.Abreviation: string.Empty))
           .ForMember(dest => dest.PriceT1, opt => opt?.MapFrom(src => src.PriceT1 + " / " + src.DayT1))
           .ForMember(dest => dest.PriceT2, opt => opt?.MapFrom(src => src.PriceT2 + " / " + src.DayT2))
           .ForMember(dest => dest.PriceT3, opt => opt?.MapFrom(src => src.PriceT3 + " / " + src.DayT3))
           .ForMember(dest => dest.PriceB, opt => opt?.MapFrom(src => src.PriceB))
       .ReverseMap();
            CreateMap<SubscriberPrice, GetSuscriberPriceByIdResponseDto>()
            .ForMember(dest => dest.Date, opt => opt?.MapFrom(src => StaticFunctions.DateTimeToString(src.Date)))
        .ReverseMap();
            CreateMap<SubscriberPrice, GetComboValueResponseDto>()
           .ForMember(dest => dest.Id, opt => opt?.MapFrom(src => src.IdContinent == 0 ? null : src.IdContinent))
           .ForMember(dest => dest.Valor, opt => opt?.MapFrom(src => src.IdContinentNavigation != null ? src.IdContinentNavigation.Name : string.Empty))
       .ReverseMap();
            CreateMap<SubscriberPrice, GetComboValueFlagResponseDto>()
           .ForMember(dest => dest.Id, opt => opt?.MapFrom(src => src.IdCountry == 0 ? null : src.IdCountry))
           .ForMember(dest => dest.Valor, opt => opt?.MapFrom(src => src.IdCountryNavigation != null ? src.IdCountryNavigation.Name : string.Empty))
           .ForMember(dest => dest.Bandera, opt => opt?.MapFrom(src => src.IdCountryNavigation != null ? src.IdCountryNavigation.FlagIso : string.Empty))
       .ReverseMap();
            CreateMap<CouponBillingSubscriberHistory, GetCouponBillingSubscriberHistoryResponseDto>()
           .ForMember(dest => dest.PurchaseDate, opt => opt?.MapFrom(src => StaticFunctions.DateTimeToString(src.PurchaseDate)))
           .ForMember(dest => dest.IdCouponBilling, opt => opt?.MapFrom(src => src.IdCouponBilling == 0 ? null : src.IdCouponBilling))
           .ForMember(dest => dest.IdEmployee, opt => opt?.MapFrom(src => src.IdEmployee == 0 ? null : src.IdEmployee))
           .ForMember(dest => dest.CouponAmount, opt => opt?.MapFrom(src => src.CouponAmount))
           .ForMember(dest => dest.CouponUnitPrice, opt => opt?.MapFrom(src => src.CouponUnitPrice))
           .ForMember(dest => dest.TotalPrice, opt => opt?.MapFrom(src => src.TotalPrice))
        .ReverseMap();
            CreateMap<AddOrUpdateCouponBillingSubscriberHistoryRequestDto, CouponBillingSubscriberHistory>()
            .ForMember(dest => dest.IdCouponBilling, opt => opt?.MapFrom(src => src.IdCouponBilling == 0 ? null : src.IdCouponBilling))
            .ForMember(dest => dest.PurchaseDate, opt => opt?.MapFrom(src => StaticFunctions.VerifyDate(src.PurchaseDate)))
        .ReverseMap();
            CreateMap<AddOrUpdateCouponBillingSubscriberRequestDto, CouponBillingSubscriber>()
            .ForMember(dest => dest.IdSubscriber, opt => opt?.MapFrom(src => src.IdSubscriber == 0 ? null : src.IdSubscriber))
        .ReverseMap();
            CreateMap<CouponBillingSubscriber, GetCouponBillingSubscriberResponseDto>()
                .ForMember(dest => dest.IdSubscriber, opt => opt?.MapFrom(src => src.IdSubscriber == 0 ? null : src.IdSubscriber))
            .ReverseMap();
        }
    }
}

using AutoMapper;
using DRRCore.Application.DTO.Core.Request;
using DRRCore.Application.DTO.Core.Response;
using DRRCore.Domain.Entities.SqlCoreContext;

namespace DRRCore.Transversal.Mapper.Profiles.Core
{
    public class BillingPersonalProfile : Profile
    {
        public BillingPersonalProfile()
        {
            CreateMap<BillinPersonal, GetBillingPersonalResponseDto>()
               .ForMember(dest => dest.IdEmployee, opt => opt?.MapFrom(src => src.IdEmployee == 0 ?  null : src.IdEmployee))
               .ForMember(dest => dest.DirectTranslate, opt => opt?.MapFrom(src => src.DirectTranslate))
               .ReverseMap();
            CreateMap<AddOrUpdateBillingPersonal, BillinPersonal > ()
               .ForMember(dest => dest.IdEmployee, opt => opt?.MapFrom(src => src.IdEmployee == 0 ? null : src.IdEmployee))
               .ForMember(dest => dest.DirectTranslate, opt => opt?.MapFrom(src => src.DirectTranslate))
               .ReverseMap();
        }
    }
}

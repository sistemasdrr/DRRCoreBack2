using AutoMapper;
using DRRCore.Application.DTO.Core.Request;
using DRRCore.Application.DTO.Core.Response;
using DRRCore.Domain.Entities.SqlCoreContext;
using DRRCore.Transversal.Common;

namespace DRRCore.Transversal.Mapper.Profiles.Core
{
    public class AnniversaryProfile:Profile
    {
        public AnniversaryProfile() {

            CreateMap<AddOrUpdateAnniversaryRequestDto, Anniversary>()
                  .ForMember(dest => dest.StartDate, opt => opt?.MapFrom(src => StaticFunctions.VerifyDate(src.StartDate)))
                  .ForMember(dest => dest.EndDate, opt => opt?.MapFrom(src => StaticFunctions.VerifyDate(src.EndDate)))                  
                  .ReverseMap();           
            CreateMap<Anniversary, GetAnniversaryResponseDto>()
                 .ForMember(dest => dest.ShortDate, opt => opt?.MapFrom(src => GetShortDate(src.StartDate,src.EndDate)))
                 .ForMember(dest => dest.Name, opt => opt?.MapFrom(src => src.Name.ToUpper()))               
                 .ForMember(dest => dest.StartDate, opt => opt?.MapFrom(src => StaticFunctions.DateTimeToString(src.StartDate)))                     
                 .ForMember(dest => dest.EndDate, opt => opt?.MapFrom(src => StaticFunctions.DateTimeToString(src.EndDate)))               
                 .ReverseMap();
        }

        private object GetShortDate(DateTime startDate, DateTime? endDate)
        {
            string startDateStr = startDate.ToString("dd/MM");
            string? endDateStr = endDate != null ? "-"+ endDate?.ToString("dd/MM") : string.Empty;
            return startDateStr + endDateStr;

        }
    }
}

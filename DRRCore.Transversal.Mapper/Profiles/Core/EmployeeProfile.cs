using AutoMapper;
using DRRCore.Application.DTO.Core.Request;
using DRRCore.Application.DTO.Core.Response;
using DRRCore.Domain.Entities.SqlCoreContext;
using DRRCore.Transversal.Common;
using DRRCore.Transversal.Common.Interface;

namespace DRRCore.Transversal.Mapper.Profiles.Core
{
    public class EmployeeProfile:Profile
    {
           
        public EmployeeProfile() {           

            CreateMap<AddOrUpdateEmployeeRequestDto, Employee > ()
                 .ForMember(dest => dest.StartDate, opt => opt?.MapFrom(src => StaticFunctions.VerifyDate(src.StartDate)))
                 .ForMember(dest => dest.EndDate, opt => opt?.MapFrom(src => StaticFunctions.VerifyDate(src.EndDate)))
                 .ForMember(dest => dest.HealthInsurances, opt => opt?.MapFrom(src => src.HealthInsuranceRequestDto))
                 .ReverseMap();
            CreateMap<AddHealthInsuranceRequestDto, HealthInsurance>().ReverseMap();
            CreateMap<Employee, GetEmployeeResponseDto>()
                 .ForMember(dest => dest.ShortName, opt => opt?.MapFrom(src => src.FirstName +" "+ src.LastName))
                 .ForMember(dest => dest.Code, opt => opt?.MapFrom(src => "E" + src.Id.ToString("D3")))
                 .ForMember(dest => dest.StartDate, opt => opt?.MapFrom(src => StaticFunctions.DateTimeToString(src.StartDate)))
                 .ForMember(dest => dest.Enable, opt => opt?.MapFrom(src => src.Enable))
                 .ForMember(dest => dest.Department, opt => opt?.MapFrom(src => src.IdJobDepartmentNavigation.Name))
                 .ForMember(dest => dest.Job, opt => opt?.MapFrom(src => src.IdJobNavigation.Name))
                 .ForMember(dest => dest.EndDate, opt => opt?.MapFrom(src => StaticFunctions.DateTimeToString(src.EndDate)))
                 .ForMember(dest => dest.HealthInsuranceResponseDto, opt => opt?.MapFrom(src => src.HealthInsurances))
                 .ReverseMap();
            CreateMap<HealthInsurance, GetHealthInsuranceResponseDto>()
                 .ForMember(dest => dest.Code, opt => opt?.MapFrom(src => "HS"+src.Id.ToString("D3")))
                 .ReverseMap();

        }
    }
}

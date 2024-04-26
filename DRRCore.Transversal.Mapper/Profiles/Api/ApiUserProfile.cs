using AutoMapper;
using DRRCore.Application.DTO.API;
using DRRCore.Domain.Entities.SQLContext;
using System.ComponentModel.DataAnnotations;

namespace DRRCore.Transversal.Mapper.Profiles.Api
{
    public class ApiUserProfile : Profile
    {
        public ApiUserProfile()
        {
            CreateMap<ApiUserDto, ApiUser>()
                .ForMember(dest => dest.CodigoAbonado, opt => opt?.MapFrom(src => src.CodigoAbonado))
                .ForMember(dest => dest.Environment, opt => opt?.MapFrom(src => src.Environment))
               .ReverseMap();

        }
    }
}
 

using AutoMapper;
using DRRCore.Application.DTO.API;
using DRRCore.Application.DTO.Web;
using DRRCore.Domain.Entities;
using DRRCore.Domain.Entities.SQLContext;
using DRRCore.Transversal.Common;

namespace DRRCore.Transversal.Mapper.Profiles.Web
{
    public class DataProfile:Profile 
    {

        public DataProfile()
        {
            CreateMap<WebQuery, ReportDataDto>()
               .ForMember(dest => dest.Code, opt => opt?.MapFrom(src => src.CodigoEmpresaWeb))
               .ForMember(dest => dest.TaxId, opt => opt?.MapFrom(src => src.NumeroRegistro))
               .ForMember(dest => dest.BussinessName, opt => opt?.MapFrom(src => src.NombreEmpresa))
               .ForMember(dest => dest.IsoCountry, opt => opt?.MapFrom(src => src.PaisAbreviatura))
               .ForMember(dest => dest.QualityInformationAvailable, opt => opt?.MapFrom(src => GetQualityReportsAvaliable()))
               .ForMember(dest => dest.LastReport, opt => opt?.MapFrom(src => src.FechaInforme.Value.ToString(Constants.DateFormatEnglish)))
               .ReverseMap();


            CreateMap<WebQuery, WebDataDto>()
                .ForMember(dest => dest.CodigoEmpresaWeb, opt => opt?.MapFrom(src => src.CodigoEmpresaWeb))
                .ForMember(dest => dest.TaxId, opt => opt?.MapFrom(src => src.NumeroRegistro))
                .ForMember(dest => dest.NombreEmpresa, opt => opt?.MapFrom(src => src.NombreEmpresa))
                .ForMember(dest => dest.PaisEmpresa, opt => opt?.MapFrom(src => src.Pais))
                .ForMember(dest => dest.UltimoReporte, opt => opt?.MapFrom(src => src.FechaInforme.Value.ToString("dd/MM/yyyy")))
                .ForMember(dest => dest.FundacionEmpresa, opt => opt?.MapFrom(src => src.AnoFundacion ?? string.Empty))
                .ForMember(dest => dest.DireccionEmpresa, opt => opt?.MapFrom(src => src.Direccion ?? string.Empty))
                .ForMember(dest => dest.DepartamentoEmpresa, opt => opt?.MapFrom(src => src.Ciudad))
                .ForMember(dest => dest.SectorEmpresa, opt => opt?.MapFrom(src => src.RamoActividad ?? string.Empty))
                .ForMember(dest => dest.SectorEmpresaIngles, opt => opt?.MapFrom(src => src.RamoActividadIngles ?? string.Empty))
                .ForMember(dest => dest.CeoEmpresa, opt => opt?.MapFrom(src => GetCeoName(src.Persona??string.Empty)))
                .ForMember(dest => dest.CalidadDisponibleEsp, opt => opt?.MapFrom(src => GetQualityDescription(src.CalidadCodigo)))
                .ForMember(dest => dest.CalidadDisponibleEng, opt => opt?.MapFrom(src => GetQualityDescription(src.CalidadCodigo)))
                .ForMember(dest => dest.UltimobalanceEmpresa, opt => opt?.MapFrom(src => GetLastBalance(src.FechaBalance1, src.FechaBalance2, src.FechaBalance3))).ReverseMap();
                

        }
        private List<string> GetQualityReportsAvaliable()
        {
            return new List<string>
            {
                "A","B","C"
            };
        }
        private static string GetCeoName(string name)
        {
            if (string.IsNullOrEmpty(name)) return string.Empty;

            var length=name.Length;           
            return name.Substring(0, length/3).ToString() + "***";
        }
        private static string GetQualityDescription(int? calidadCodigo)
        {
            return calidadCodigo switch
            {
                1 or 2 => "A",
                3 or 4 => "B",
                _ => "C",
            };
        }
        private static string GetLastBalance(string? bal1,string? bal2,string? bal3)
        {
            var value = new List<string>();           
            if(!string.IsNullOrEmpty(bal1))
            {
               value.Add(bal1);
            }
            if(!string.IsNullOrEmpty(bal2))
            {
                value.Add(bal2);
            }
            if (!string.IsNullOrEmpty(bal3))
            {
                value.Add(bal3);
            }
            return string.Join('-', value);          
        }
        
    }
}

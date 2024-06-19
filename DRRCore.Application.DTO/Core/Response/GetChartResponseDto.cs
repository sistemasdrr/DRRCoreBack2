using System.Runtime.InteropServices;

namespace DRRCore.Application.DTO.Core.Response
{
    public class GetChartResponseDto
    {
        
    }
    public class GetQuery5_1_1ResponseDto
    {
        public List<GetQuery5_1_1_Subscribers>? SubscribersList { get; set; }
        public List<GetQuery5_1_1_Countries>? CountriesList { get; set; }
        public GetQuery5_1_1Procedure? ProcedureType { get; set; }
        public GetQuery5_1_1Report? ReportType { get; set; }
        public GetQuery5_1_1Currency? Currency { get; set; }
    }
    public class GetQuery5_1_1_Subscribers
    {
        public string? Code { get; set; }
        public string? Name { get; set; }
        public string? Country { get; set; }
        public string? FlagCountry { get; set; }
        public int? Quantity { get; set; }
    }
    public class GetQuery5_1_1_Countries
    {
        public string? Country { get; set; }
        public string? FlagCountry { get; set; }
        public int? Quantity { get; set; }
    }
    public class GetQuery5_1_1Procedure
    {
        public int? T1 { get; set; }
        public int? T2 { get; set; }
        public int? T3 { get; set; }
    }
    public class GetQuery5_1_1Report
    {
        public int? OR { get; set; }
        public int? RV { get; set; }
        public int? EF { get; set; }
    }
    public class GetQuery5_1_1Currency
    {
        public int? PEN { get; set; }
        public int? USD { get; set; }
    }

    public class GetQuery5_1_2ResponseDto
    {
        public List<GetQuery5_1_2_Subscribers>? SubscribersList { get; set; }
        public List<GetQuery5_1_2_Countries>? CountriesList { get; set; }
        public GetQuery5_1_2Procedure? ProcedureType { get; set; }
        public GetQuery5_1_2Report? ReportType { get; set; }
        public GetQuery5_1_2Currency? Currency { get; set; }
    }
    public class GetQuery5_1_2_Subscribers
    {
        public string? Code { get; set; }
        public string? Name { get; set; }
        public string? Country { get; set; }
        public string? FlagCountry { get; set; }
        public int? Quantity { get; set; }
    }
    public class GetQuery5_1_2_Countries
    {
        public string? Country { get; set; }
        public string? FlagCountry { get; set; }
        public int? Quantity { get; set; }
    }
    public class GetQuery5_1_2Procedure
    {
        public int? T1 { get; set; }
        public int? T2 { get; set; }
        public int? T3 { get; set; }
    }
    public class GetQuery5_1_2Report
    {
        public int? OR { get; set; }
        public int? RV { get; set; }
        public int? EF { get; set; }
    }
    public class GetQuery5_1_2Currency
    {
        public int? PEN { get; set; }
        public int? USD { get; set; }
    }
    public class GetQuery5_1_3ResponseDto
    {
        public string? Code { get; set; }
        public string? Name { get; set; }
        public string? Country { get; set; }
        public string? FlagCountry { get; set; }
    }
    public class GetQuery5_1_4ResponseDto
    {
        public int? Id { get; set; }
        public string? Ticket { get; set; }
        public string? OrderDate { get; set; }
        public string? DispatchDate { get; set; }
        public string? ExpireDate { get; set; }
        public string? RequestedName { get; set; }
        public string? Country { get; set; }
        public string? FlagCountry { get; set; }
        public string? ProcedureType { get; set; }
        public string? ReportType { get; set; }
        public decimal? Price { get; set; }
    }
    public class GetQuery5_1_5ResponseDto
    {
        public string? Code { get; set; }
        public string? Name { get; set; }
        public string? Country { get; set; }
        public string? FlagCountry { get; set; }
    }
    public class GetQuery5_1_6ResponseDto
    {
        public string? Code { get; set; }
        public string? Name { get; set; }
        public string? Country { get; set; }
        public string? FlagCountry { get; set; }
        public int? Total { get; set; }
    }
    public class GetQuery5_1_15ResponseDto
    {
        public string? Country { get; set; }
        public string? FlagCountry { get; set; }
    }
    public class GetQuery5_1_18ResponseDto
    {
        public string? Code { get; set; }
        public string? Name { get; set; }
        public int? January { get; set; }
        public int? February { get; set; }
        public int? March { get; set; }
        public int? April { get; set; }
        public int? May { get; set; }
        public int? June { get; set; }
        public int? July { get; set; }
        public int? August { get; set; }
        public int? September { get; set; }
        public int? October { get; set; }
        public int? November { get; set; }
        public int? December { get; set; }
        public int? Total { get; set; }
    }
    public class GetQuery5_1_19_1ResponseDto 
    {
        public List<GetQuery5_1_19SubscribersResponseDto> Subscribers { get; set; }
        public GetQueryProcedureType ProcedureType { get; set; }
        public GetQueryReportType ReportType { get; set; }
        public GetQueryLanguage Language { get; set; }

    }
    public class GetQueryProcedureType
    {
        public int? T1 { get; set; }
        public int? T2 { get; set; }
        public int? T3 { get; set; }
    }
    public class GetQueryReportType
    {
        public int? OR { get; set; }
        public int? RV { get; set; }
        public int? EF { get; set; }
        public int? DF { get; set; }
    }
    public class GetQueryLanguage
    {
        public int? English { get; set; }
        public int? Spanish { get; set; }
    }

    public class GetQuery5_1_19SubscribersResponseDto
    {
        public int? IdSubcsriber{ get; set; }
        public string? Name { get; set; }
        public string? Code { get; set; }
        public int? Day1 { get; set; }
        public int? Day2 { get; set; }
        public int? Day3 { get; set; }
        public int? Day4 { get; set; }
        public int? Day5 { get; set; }
        public int? Day6 { get; set; }
        public int? Day7 { get; set; }
        public int? Day8 { get; set; }
        public int? Day9 { get; set; }
        public int? Day10 { get; set; }
        public int? Day11 { get; set; }
        public int? Day12 { get; set; }
        public int? Day13 { get; set; }
        public int? Day14 { get; set; }
        public int? Day15 { get; set; }
        public int? Day16 { get; set; }
        public int? Day17 { get; set; }
        public int? Day18 { get; set; }
        public int? Day19 { get; set; }
        public int? Day20 { get; set; }
        public int? Day21 { get; set; }
        public int? Day22 { get; set; }
        public int? Day23 { get; set; }
        public int? Day24 { get; set; }
        public int? Day25 { get; set; }
        public int? Day26 { get; set; }
        public int? Day27 { get; set; }
        public int? Day28 { get; set; }
        public int? Day29 { get; set; }
        public int? Day30 { get; set; }
        public int? Day31 { get; set; }
        public int? Total { get; set; }
    }

    public class GetQuery5_1_19_2ResponseDto
    {
        public List<GetQuery5_1_19CountriesResponseDto> Countries { get; set; }
        public GetQueryProcedureType ProcedureType { get; set; }
        public GetQueryReportType ReportType { get; set; }
        public GetQueryLanguage Language { get; set; }

    }
    public class GetQuery5_1_19CountriesResponseDto
    {
        public int? IdCountry { get; set; }
        public string? Country { get; set; }
        public string? FlagCountry { get; set; }
        public int? Day1 { get; set; }
        public int? Day2 { get; set; }
        public int? Day3 { get; set; }
        public int? Day4 { get; set; }
        public int? Day5 { get; set; }
        public int? Day6 { get; set; }
        public int? Day7 { get; set; }
        public int? Day8 { get; set; }
        public int? Day9 { get; set; }
        public int? Day10 { get; set; }
        public int? Day11 { get; set; }
        public int? Day12 { get; set; }
        public int? Day13 { get; set; }
        public int? Day14 { get; set; }
        public int? Day15 { get; set; }
        public int? Day16 { get; set; }
        public int? Day17 { get; set; }
        public int? Day18 { get; set; }
        public int? Day19 { get; set; }
        public int? Day20 { get; set; }
        public int? Day21 { get; set; }
        public int? Day22 { get; set; }
        public int? Day23 { get; set; }
        public int? Day24 { get; set; }
        public int? Day25 { get; set; }
        public int? Day26 { get; set; }
        public int? Day27 { get; set; }
        public int? Day28 { get; set; }
        public int? Day29 { get; set; }
        public int? Day30 { get; set; }
        public int? Day31 { get; set; }
        public int? Total { get; set; }
    }
    public class GetQuery5_1_20ResponseDto
    {
        public List<GetQuery5_1_20SubscribersResponseDto> Subscribers { get; set; }
        public GetQueryProcedureType ProcedureType { get; set; }
        public GetQueryReportType ReportType { get; set; }
        public GetQueryLanguage Language { get; set; }
    }
    public class GetQuery5_1_20SubscribersResponseDto
    {
        public int? IdSubcsriber { get; set; }
        public string? Name { get; set; }
        public string? Code { get; set; }
        public int? Day1 { get; set; }
        public int? Day2 { get; set; }
        public int? Day3 { get; set; }
        public int? Day4 { get; set; }
        public int? Day5 { get; set; }
        public int? Day6 { get; set; }
        public int? Day7 { get; set; }
        public int? Day8 { get; set; }
        public int? Day9 { get; set; }
        public int? Day10 { get; set; }
        public int? Day11 { get; set; }
        public int? Day12 { get; set; }
        public int? Day13 { get; set; }
        public int? Day14 { get; set; }
        public int? Day15 { get; set; }
        public int? Day16 { get; set; }
        public int? Day17 { get; set; }
        public int? Day18 { get; set; }
        public int? Day19 { get; set; }
        public int? Day20 { get; set; }
        public int? Day21 { get; set; }
        public int? Day22 { get; set; }
        public int? Day23 { get; set; }
        public int? Day24 { get; set; }
        public int? Day25 { get; set; }
        public int? Day26 { get; set; }
        public int? Day27 { get; set; }
        public int? Day28 { get; set; }
        public int? Day29 { get; set; }
        public int? Day30 { get; set; }
        public int? Day31 { get; set; }
        public int? Total { get; set; }
    }
    public class GetQuery5_1_21ResponseDto
    {
        public int? IdSubcsriber { get; set; }
        public string? Name { get; set; }
        public string? Code { get; set; }

        public int? T1 { get; set; }
        public int? T2 { get; set; }
        public int? T3 { get; set; }

        public int? OR { get; set; }
        public int? RV { get; set; }
        public int? EF { get; set; }
        public int? DF { get; set; }

        public int? QualityA { get; set; }
        public int? QualityB { get; set; }
        public int? QualityC { get; set; }

        public int? Total { get; set; }
    }
    public class GetQuery5_1_26ResponseDto
    {
        public int? Year { get; set; }
        public int? QualityA { get; set; }
        public int? QualityB { get; set; }
        public int? QualityC { get; set; }
        public int? Total { get; set; }

    }
    public class GetQuery5_1_27ResponseDto
    {
        public int? IdSubscriber { get; set; }
        public string? Code { get; set; }
        public string? Name { get; set; }
        public string? Country { get; set; }
        public string? FlagCountry { get; set; }
        public int? T1 { get; set; }
        public int? T2 { get; set; }
        public int? T3 { get; set; }
        public int? OR { get; set; }
        public int? RV { get; set; }
        public int? EF { get; set; }
        public int? DF { get; set; }
        public int? QualityA { get; set; }
        public int? QualityB { get; set; }
        public int? QualityC { get; set; }
        public int? English { get; set; }
        public int? Spanish { get; set; }

        public int? Total { get; set; }
    }
    public class GetQuery5_2_1ResponseDto
    {
        public int? IdTicket { get; set; }
        public string? Ticket { get; set; }
        public string? OrderDate { get; set; }
        public string? ExpireDate { get; set; }
        public string? ShippingDate { get; set; }
        public string? RequestedName { get; set; }
        public string? Country { get; set; }
        public string? FlagCountry { get; set; }
        public string? ProcedureType { get; set; }
        public string? ReportType { get; set; }
        public string? Subscriber { get; set; }
        public decimal? Price { get; set; }
    }
    public class GetQuery5_2_2ResponseDto 
    {
        public int? IdTicket { get; set; }
        public string? RequestedName { get; set; }
        public string? OrderDate { get; set; }
        public string? ExpireDate { get; set; }
        public string? Country { get; set; }
        public string? FlagCountry { get; set; }
        public string? ProcedureType { get; set; }
        public string? ReportType { get; set; }
        public string? Subscriber { get; set; }
    }
    public class GetQuery5_2_3ResponseDto
    {
        public int? IdTicket { get; set; }
        public int? IdTicketHistory { get; set; }
        public string? RequestedName { get; set; }
        public string? Country { get; set; }
        public string? FlagCountry { get; set; }
        public string? Subscriber { get; set; }
        public string? OrderDate { get; set; }
        public string? ShippingDate { get; set; }
        public string? ExpireDate { get; set; }
        public string? ProcedureType { get; set; }
        public string? ReportType { get; set; }
    }
    public class GetQuery5_2_4ResponseDto
    {
        public string? AsignedTo { get; set; }
        public string? Name { get; set; }
        public int? T1 { get; set; }
        public int? T2 { get; set; }
        public int? T3 { get; set; }
        public int? OR { get; set; }
        public int? RV { get; set; }
        public int? EF { get; set; }
        public int? DF { get; set; }
        public int? QualityA { get; set; }
        public int? QualityB { get; set; }
        public int? QualityC { get; set; }
        public int? Total { get; set; }
    }

    public class GetQuery5_3_2ResponseDto
    {
        public int? Id { get; set; }
        public string? OrderDate { get; set; }
        public string? ExpireDate { get; set; }
        public string? ShippingDate { get; set; }
        public string? RequestedName { get; set; }
        public string? Country { get; set; }
        public string? FlagCountry { get; set; }
        public string? ProcedureType { get; set; }
        public string? ReportType { get; set; }
        public string? Subscriber { get; set; }
        public decimal? Price { get; set; }
    }
}

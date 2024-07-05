namespace DRRCore.Application.DTO.Core.Response
{
    public class GetQueryResponseDto
    {
    }
    public class GetQuery1_1ResponseDto
    {
        public int? IdSubscriber { get; set; }
        public string? SubscriberName { get; set; }
        public string? SubscriberCode { get; set; }
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
    public class GetQuery1_1ByMonthResponseDto
    {
        public int Id { get; set; }
        public string? RequestedName { get; set; }
        public int? IdCountry { get; set; }
        public string? Country { get; set; }
        public string? FlagCountry { get; set; }
        public string? OrderDate { get; set; }
        public string? DispatchDate { get; set; }
        public string? ProcedureType { get; set; }
        public string? ReportType { get; set; }
        public decimal? Price { get; set; }
    }

    public class GetQuery1_2ByYearResponseDto
    {
        public int? IdCountry { get; set; }
        public string? Country { get; set; }
        public string? FlagCountry { get; set; }
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

    public class GetQuery1_3BySubscriberResponseDto
    {
        public int? IdCountry { get; set; }
        public string? Country { get; set; }
        public string? FlagCountry { get; set; }
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
    public class GetQuery1_4SubscriberResponseDto
    {
        public int? IdSubscriber { get; set; }
        public string? Name { get; set; }
        public string? Code { get; set; }
        public int? IdCountry { get; set; }
        public string? Country { get; set; }
        public string? FlagCountry { get; set; }
    }
    public class GetQuery1_4ResponseDto
    {
        public List<GetQuery1_4ByCountryResponseDto> Query1_4ByCountries { get; set; }
        public List<GetQuery1_4ByProcedureTypeResponseDto> Query1_4ByProcedureType { get; set; }
        public List<GetQuery1_4ByReportTypeResponseDto> Query1_4ByReportType { get; set; }
    }
    public class GetQuery1_4ByCountryResponseDto
    {
        public int? IdCountry { get; set; }
        public string? Country { get; set; }
        public string? FlagCountry { get; set; }
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
    public class GetQuery1_4ByProcedureTypeResponseDto
    {
        public string? ProcedureType { get; set; }
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
    public class GetQuery1_4ByReportTypeResponseDto
    {
        public string? ReportType { get; set; }
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

    public class GetQuery1_5ResponseDto
    {
        public int IdTicket { get; set; }
        public string? OrderDate { get; set; }
        public string? ExpireDate { get; set; }
        public string? RequestedName { get; set; }
        public string? BusinessName { get; set; }
        public int? IdCountry { get; set; }
        public string? Country { get; set; }
        public string? FlagCountry { get; set; }
        public string? ProcedureType { get; set; }
        public string? ReportType { get; set; }
        public int? IdSubscriber { get; set; }
        public string? SubscriberName { get; set; }
        public string? SubscriberCode { get; set; }
        public decimal? Price { get; set; }
    }
    public class GetQuery1_6ResponseDto
    {
        public int? IdSubscriber { get; set; }
        public string? Name { get; set; }
        public string? Code { get; set; }
        public int? IdCountry { get; set; }
        public string? Country { get; set; }
        public string? FlagCountry { get; set; }
    }
    public class GetQuery1_6BySubscriberResponseDto
    {
        public int IdTicket { get; set; }
        public string? OrderDate { get; set; }
        public string? ExpireDate { get; set; }
        public string? RequestedName { get; set; }
        public string? BusinessName { get; set; }
        public int? IdCountry { get; set; }
        public string? Country { get; set; }
        public string? FlagCountry { get; set; }
        public string? ProcedureType { get; set; }
        public string? ReportType { get; set; }
        public int? IdSubscriber { get; set; }
        public string? SubscriberName { get; set; }
        public string? SubscriberCode { get; set; }
        public string? SubscriberCountry { get; set; }
        public string? SubscriberFlagCountry { get; set; }
        public decimal? Price { get; set; }
    }

    public class GetQuery1_7SubscriberResponseDto
    {
        public int IdSubscriber { get; set; }
        public string? Code { get; set; }
        public string? Name { get; set; }
        public int? IdCountry { get; set; }
        public string? Country { get; set; }
        public string? FlagCountry { get; set; }
        public string? Contact { get; set; }
        public string? Email { get; set; }
        public string? BillingType { get; set; }
    }
    public class GetQuery1_7TicketsReponseDto
    {
        public int IdTicket { get; set; }
        public string? OrderDate { get; set; }
        public string? ExpireDate { get; set; }
        public string? RequestedName { get; set; }
        public string? ReferenceCode { get; set; }
        public int? IdCountry { get; set; }
        public string? Country { get; set; }
        public string? FlagCountry { get; set; }
        public string? ProcedureType { get; set; }
        public string? ReportType { get; set; }
    }

    public class GetQuery1_8ResponseDto
    {
        public int? IdCountry { get; set; }
        public string? Country { get; set; }
        public string? FlagCountry { get; set; }
        public int? Quantity { get; set; }
    }
    public class GetQuery1_9ResponseDto
    {
        public int? IdSubscriber { get; set; }
        public string? Name { get; set; }
        public string? Code { get; set; }
        public int? Quantity { get; set; }
    }

    public class GetQuery1_10ResponseDto
    {
        public int? IdTicket { get; set; }
        public string? OrderDate { get; set; }
        public string? ExpireDate { get; set; }
        public string? DispatchDate { get; set; }
        public string? RequestedName { get; set; }
        public int? IdCountry { get; set; }
        public string? Country { get; set; }
        public string? FlagCountry { get; set; }
        public string? ProcedureType { get; set; }
        public string? ReportType { get; set; }
        public decimal? Price { get; set; }
    }
    public class GetQuery1_11SubscribersResponseDto
    {
        public int? IdSubscriber { get; set; }
        public string? Name { get; set; }
        public string? Code { get; set; }
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
    public class GetQuery1_11BySubscriberResponseDto
    {
        public int? IdTicket { get; set; }
        public string? RequestedName { get; set; }
        public int? IdCountry { get; set; }
        public string? Country { get; set; }
        public string? FlagCountry { get; set; }
        public string? OrderDate { get; set; }
        public string? DispatchDate { get; set; }
        public string? ProcedureType { get; set; }
        public string? ReportType { get; set; }
        public decimal? Price { get; set; }
    }

    public class GetReportersResponseDto
    {
        public string? AsignedTo { get; set; }
        public string? Name { get; set; }
    }
    public class GetQuery2_1ByYearResponseDto
    {
        public int? IdEmployee{ get; set; }
        public string? Name { get; set; }
        public string? Code { get; set; }
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
    public class GetQuery2_1ByMonthResponseDto
    {
        public int? Id { get; set; }
        public string? RequestedName { get; set; }
        public int? IdCountry { get; set; }
        public string? Country { get; set; }
        public string? FlagCountry { get; set; }
        public int? IdSubscriber { get; set; }
        public string? SubscriberName { get; set; }
        public string? SubscriberCode { get; set; }
        public string? OrderDate { get; set; }
        public string? ExpireDate { get; set; }
        public string? ShippingDate { get; set; }
        public string? ProcedureType { get; set; }
        public string? ReportType { get; set; }
    }
    public class GetQuery2_2ByYearResponseDto
    {
        public int? IdCountry{ get; set; }
        public string? Country { get; set; }
        public string? FlagCountry { get; set; }
        public int? January { get; set; }
        public GetQuery2_2ByMonthResponseDto? Month1 { get; set; }
        public int? February { get; set; }
        public GetQuery2_2ByMonthResponseDto? Month2 { get; set; }
        public int? March { get; set; }
        public GetQuery2_2ByMonthResponseDto? Month3 { get; set; }
        public int? April { get; set; }
        public GetQuery2_2ByMonthResponseDto? Month4 { get; set; }
        public int? May { get; set; }
        public GetQuery2_2ByMonthResponseDto? Month5 { get; set; }
        public int? June { get; set; }
        public GetQuery2_2ByMonthResponseDto? Month6 { get; set; }
        public int? July { get; set; }
        public GetQuery2_2ByMonthResponseDto? Month7 { get; set; }
        public int? August { get; set; }
        public GetQuery2_2ByMonthResponseDto? Month8 { get; set; }
        public int? September { get; set; }
        public GetQuery2_2ByMonthResponseDto? Month9 { get; set; }
        public int? October { get; set; }
        public GetQuery2_2ByMonthResponseDto? Month10 { get; set; }
        public int? November { get; set; }
        public GetQuery2_2ByMonthResponseDto? Month11 { get; set; }
        public int? December { get; set; }
        public GetQuery2_2ByMonthResponseDto? Month12 { get; set; }
        public int? Total { get; set; }
    }
    public class GetQuery2_2ByMonthResponseDto
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
    }

    public class GetQuery3_1ByYearResponseDto
    {
        public string? AsignedTo  { get; set; }
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
    public class GetQuery3_1ByMonthResponseDto
    {
        public string? RequestedName { get; set; }
        public int? IdCountry { get; set; }
        public string? Country { get; set; }
        public string? FlagCountry { get; set; }
        public string? EmitInvoiceDate { get; set; }
        public string? OrderDate { get; set; }
        public string? DispatchDate { get; set; }
        public string? ExpireDate { get; set; }
        public string? ProcedureType { get; set; }
        public string? ReportType { get; set; }
        public decimal? Price { get; set; }
    }

    public class GetQuery4_1_1ResponseDto
    {
        public int? IdSubscriber { get; set; }
        public string? Name { get; set; }
        public string? Code{ get; set; }
    }
    public class GetQuery4_1_2ResponseDto
    {
        public string? Date { get; set; }
    }
    public class GetQuery4_1_3ResponseDto
    {
        public int? IdSubscriber { get; set; }
        public string? Name { get; set; }
        public string? Code { get; set; }
        public int? IdCountry{ get; set; }
        public string? Country { get; set; }
        public string? FlagCountry { get; set; }
    }
    public class GetQuery4_1_4ResponseDto
    {
        public int? IdSubscriber { get; set; }
        public string? Name { get; set; }
        public string? Code { get; set; }
        public int? IdCountry { get; set; }
        public string? Country { get; set; }
        public string? FlagCountry { get; set; }
    }
    public class GetQuery4_1_5ResponseDto
    {
        public int? IdSubscriber { get; set; }
        public string? Name { get; set; }
        public string? Code { get; set; }
        public int? IdCountry { get; set; }
        public string? Country { get; set; }
        public string? FlagCountry { get; set; }
    }
    public class GetQuery4_2_1ResponseDto
    {
        public string? Name { get; set; }
        public string? Code { get; set; }
        public string? Country { get; set; }
        public string? FlagCountry { get; set; }
    }
    public class GetQuery4_2_2ResponseDto
    {
        public string? Name { get; set; }
        public string? Code { get; set; }
        public string? Country { get; set; }
        public string? FlagCountry { get; set; }
    }

    public class GetQuery5_1_1ResponseDto
    {
        public int? Id { get; set; }
        public string? Name { get; set; }
        public string? Code { get; set; }
        public string? Country { get; set; }
        public string? FlagCountry { get; set; }
        public bool? Flag { get; set; }
        public int? Quantity { get; set; }
        public List<GetQueryTicket5_1_1ResponseDto>? Tickets { get; set; }
    }
    public class GetQueryTicket5_1_1ResponseDto
    {

        public int Id { get; set; }
        public string Number { get; set; }
        public string? Language { get; set; }
        public string About { get; set; } = null!;
        public string? Status { get; set; }
        public string? StatusColor { get; set; }
        public string? Country { get; set; }
        public string? FlagCountry { get; set; }


        //ABONADO
        public string? SubscriberCode { get; set; }
        public string? SubscriberName { get; set; }
        public string? SubscriberCountry { get; set; }
        public string? SubscriberFlag { get; set; }
        public string? QueryCredit { get; set; }
        public string? TimeLimit { get; set; }
        public bool? RevealName { get; set; }
        public string? NameRevealed { get; set; }
        public string? ReferenceNumber { get; set; }
        public string? AditionalData { get; set; }
        public string? SubscriberIndications { get; set; }

        //EMPRESA
        public string? BusineesName { get; set; }
        public string? RequestedName { get; set; }
        public string? TaxType { get; set; }
        public string? TaxCode { get; set; }
        public string? InvestigatedIsoCountry { get; set; }
        public string? InvestigatedCountry { get; set; }
        public string? InvestigatedFlag { get; set; }
        public string? City { get; set; }
        public string? Email { get; set; }
        public string? Address { get; set; }
        public string? Telephone { get; set; }
        public string? WebPage { get; set; }

        //INFORME
        public string ReportType { get; set; } = null!;
        public string ProcedureType { get; set; } = null!;
        public string? OrderDate { get; set; }
        public string? ExpireDate { get; set; }
        public string? RealExpireDate { get; set; }

        public int? Flag { get; set; }
    }
    public class GetQuery5_1_2ResponseDto
    {
        public int? Id { get; set; }
        public string? Name { get; set; }
        public string? Code { get; set; }
        public string? Country { get; set; }
        public string? FlagCountry { get; set; }
        public bool? Flag { get; set; }
        public int? Quantity { get; set; }
        public List<GetQueryTicket5_1_2ResponseDto>? Tickets { get; set; }
    }
    public class GetQueryTicket5_1_2ResponseDto
    {

        public int Id { get; set; }
        public string Number { get; set; }
        public string? Language { get; set; }
        public string About { get; set; } = null!;
        public string? Status { get; set; }
        public string? StatusColor { get; set; }
        public string? Country { get; set; }
        public string? FlagCountry { get; set; }


        //ABONADO
        public string? SubscriberCode { get; set; }
        public string? SubscriberName { get; set; }
        public string? SubscriberCountry { get; set; }
        public string? SubscriberFlag { get; set; }
        public string? QueryCredit { get; set; }
        public string? TimeLimit { get; set; }
        public bool? RevealName { get; set; }
        public string? NameRevealed { get; set; }
        public string? ReferenceNumber { get; set; }
        public string? AditionalData { get; set; }
        public string? SubscriberIndications { get; set; }

        //EMPRESA
        public string? BusineesName { get; set; }
        public string? RequestedName { get; set; }
        public string? TaxType { get; set; }
        public string? TaxCode { get; set; }
        public string? InvestigatedIsoCountry { get; set; }
        public string? InvestigatedCountry { get; set; }
        public string? InvestigatedFlag { get; set; }
        public string? City { get; set; }
        public string? Email { get; set; }
        public string? Address { get; set; }
        public string? Telephone { get; set; }
        public string? WebPage { get; set; }

        //INFORME
        public string ReportType { get; set; } = null!;
        public string ProcedureType { get; set; } = null!;
        public string? OrderDate { get; set; }
        public string? ExpireDate { get; set; }
        public string? RealExpireDate { get; set; }

        public int? Flag { get; set; }
    }
}

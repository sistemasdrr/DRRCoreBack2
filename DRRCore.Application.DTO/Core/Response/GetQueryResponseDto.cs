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
        public string? Country { get; set;  }
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
        public int? IdCountry{ get; set; }
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
        public string? BillingType{ get; set; }
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
}

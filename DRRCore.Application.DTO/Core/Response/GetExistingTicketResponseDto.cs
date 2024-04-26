namespace DRRCore.Application.DTO.Core.Response
{
    public class GetExistingTicketResponseDto
    {
        public string TypeReport { get; set; } = "OR";
        public string LastSearchedDate { get; set; } = string.Empty;
        public List<GetListSameSearchedReportResponseDto> ListSameSearched { get; set; } = new List<GetListSameSearchedReportResponseDto>();

    }
    public class GetListSameSearchedReportResponseDto
    {
        public bool IsPending { get; set; }
        public DateTime DispatchtDate { get; set; }
        public string? DispatchtDateString { get; set; }
        public string TypeReport { get; set; } = string.Empty;
        public string TicketNumber { get; set; } = string.Empty;
        public string RequestedName { get; set; } = string.Empty;
        public string Dispatch { get; set; } = string.Empty;
        public string Subscriber { get; set; } = string.Empty;
        public string Procedure { get; set; } = string.Empty; 
        public string Status { get; set; } = string.Empty;
    }
}
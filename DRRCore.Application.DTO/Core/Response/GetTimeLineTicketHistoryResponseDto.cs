namespace DRRCore.Application.DTO.Core.Response
{
    public class GetTimeLineTicketHistoryResponseDto
    {
        public int Id{ get; set; }
        public string? AssignedTo { get; set; }
        public string? AssignedToName { get; set; }
        public string? Date { get; set; }
        public string? Time { get; set; }
        public int? IdStatusTicket { get; set; }
        public string? Status { get; set; }
        public string? Color { get; set; }
    }
}

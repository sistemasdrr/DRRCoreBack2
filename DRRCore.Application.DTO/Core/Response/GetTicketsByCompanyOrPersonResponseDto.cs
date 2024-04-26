namespace DRRCore.Application.DTO.Core.Response
{
    public class GetTicketsByCompanyOrPersonResponseDto
    {
        public int Id { get; set; }
        public string? Ticket { get; set; }
        public int? IdStatusTicket { get; set; }
        public string? Status { get; set; }
        public string? Color { get; set; }
        public string? RequestedName { get; set; }
        public string? SubscriberCode { get; set; }
        public string? ProcedureType { get; set; }
        public string? ReportType { get; set; }
        public string? Language { get; set; }
        public string? OrderDate { get; set; }
        public string? EndDate { get; set; }
        public string? DispatchDate { get; set; }
        public bool? Web { get; set; }
    }
}

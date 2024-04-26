namespace DRRCore.Application.DTO.Core.Response
{
    public class GetTicketHistorySubscriberResponseDto
    {
        public int Id { get; set; }
        public int IdCompany { get; set; }
        public string? Ticket { get; set; }
        public string? Name { get; set; }
        public int? IdCountry { get; set; }
        public string? Country { get; set; }
        public string? FlagCountry { get; set; }
        public string? DispatchDate { get; set; }
    }
}

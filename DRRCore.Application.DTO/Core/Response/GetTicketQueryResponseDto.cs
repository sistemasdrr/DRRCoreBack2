namespace DRRCore.Application.DTO.Core.Response
{
    public class GetTicketQueryResponseDto
    {
        public int IdTicket { get; set; }
        public DateTime QueryDate { get; set; }
        public int? IdSubscriber { get; set; }
        public string SubscriberName { get; set; } = string.Empty;
        public string Language { get; set; } = null!;
        public string? Email { get; set; }
        public string? Message { get; set; }     
        public int Status { get; set; }
        public string Report { get; set; } = string.Empty;
        public string Response { get; set; } = string.Empty;

    }
}

namespace DRRCore.Application.DTO.Core.Response
{
    public class GetTicketHistoryResponseDto
    {
        public int Id { get; set; }

        public int? IdTicket { get; set; }

        public string? UserFrom { get; set; }

        public string? UserTo { get; set; }

        public DateTime CreationDate { get; set; }

        public DateTime? UpdateDate { get; set; }

        public DateTime? DeleteDate { get; set; }

        public bool? Enable { get; set; }

        public int? IdStatusTicket { get; set; }

        public string? AsignedTo { get; set; }

        public bool? Flag { get; set; }

        public int? NumberAssign { get; set; }

        public bool? Balance { get; set; }

        public bool? References { get; set; }

        public string? Observations { get; set; }

        public DateTime? StartDate { get; set; }

        public DateTime? EndDate { get; set; }
    }

    public class PendingTaskResponseDto
    {
        public string? AsignedTo { get; set; }
        public int? Count { get; set; }
    }
    public class ObservedTickets
    {
        public string? AsignedTo { get; set; }
        public int? IdTicket { get; set; }
        public string? Ticket { get; set; }
    }
    public class PendingTaskSupervisorResponseDto
    {
        public string? Name { get; set; }
        public string? Code { get; set; }
        public List<PendingTaskPersonalResponseDto>? Details { get; set; }
    }
    public class PendingTaskPersonalResponseDto
    {
        public string? AsignedTo { get; set; }
        public string? Type { get; set; }
        public string? Name { get; set; }
        public string? Country { get; set; }
        public string? FlagCountry { get; set; }
        public List<PendingTaskPersonalDetailsResponseDto>? Details { get; set; }
    }
    public class PendingTaskPersonalDetailsResponseDto
    {
        public int? Id { get; set; }
        public string? Number { get; set; }
        public string? RequestedName { get; set; }
        public string? Country { get; set; }
        public string? FlagCountry { get; set; }
        public string? ExpireDate { get; set; }
        public int? Flag { get; set; }

    }


}

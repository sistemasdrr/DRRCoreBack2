using Microsoft.AspNetCore.Http;

namespace DRRCore.Application.DTO.Core.Request
{
    public class AddOrUpdateTicketFilesRequestDto
    {
        public int Id { get; set; }

        public int? IdTicket { get; set; }

        public string Name { get; set; } = null!;

        public string Path { get; set; } = null!;

        public string Extension { get; set; } = null!;


    }
}

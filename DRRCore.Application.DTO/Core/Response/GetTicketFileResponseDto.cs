namespace DRRCore.Application.DTO.Core.Response
{
    public class GetTicketFileResponseDto
    {
        public int Id { get; set; }

        public string Name { get; set; } = null!;

        public string Path { get; set; } = null!;

        public string Extension { get; set; } = null!;

    }
}

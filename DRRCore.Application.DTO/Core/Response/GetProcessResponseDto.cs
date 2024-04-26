namespace DRRCore.Application.DTO.Core.Response
{
    public class GetProcessResponseDto
    {
        public int Id { get; set; }

        public string Name { get; set; } = null!;

        public string? Menu { get; set; }

        public int? OrderItem { get; set; }

        public bool? Enable { get; set; }
    }
}

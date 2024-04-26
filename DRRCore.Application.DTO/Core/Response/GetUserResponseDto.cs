namespace DRRCore.Application.DTO.Core.Response
{
    public class GetUserResponseDto
    {
        public int Id { get; set; }

        public int? IdEmployee { get; set; }

        public string? UserLogin1 { get; set; }

        public string Password { get; set; } = null!;

        public bool? Enable { get; set; }

        public string? EmailPassword { get; set; }
    }
}

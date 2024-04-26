namespace DRRCore.Application.DTO.Core.Response
{
    public class GetPersonalAssignationResponseDto
    {
        public int Id { get; set; }
        public int? IdEmployee { get; set; }
        public int? IdUserLogin { get; set; }
        public string? Fullname { get; set; }
        public string? Type { get; set; }
        public string? Code { get; set; }
        public bool? Internal { get; set; }
    }
}

namespace DRRCore.Application.DTO.Core.Request
{
    public class AddOrUpdateAssignationsRequestDto
    {
        public string? UserFrom { get; set; }
        public string? UserTo { get; set; }
        public int? IdEmployee { get; set; }
        public string? AssignedToCode { get; set; }
        public string? AssignedToName { get; set; }
        public string? StartDate { get; set; }
        public string? EndDate { get; set; }
        public bool? Balance { get; set; }
        public bool? References { get; set; }
        public string? Observations { get; set; }
        public string? Type { get; set; }
    }

}

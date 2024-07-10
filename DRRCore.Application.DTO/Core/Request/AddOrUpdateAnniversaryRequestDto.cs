namespace DRRCore.Application.DTO.Core.Request
{
    public class AddOrUpdateAnniversaryRequestDto
    {
        public int Id { get; set; }

        public string? Name { get; set; }

        public string StartDate { get; set; }

        public string EndDate { get; set; }     
    }
    public class AddOrUpdateAnniversaryDto
    {
        public int Id { get; set; }
        public string? Title { get; set; }
        public string? GroupId { get; set; }
        public string? Details { get; set; }
        public string? ClassName { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
    }
}

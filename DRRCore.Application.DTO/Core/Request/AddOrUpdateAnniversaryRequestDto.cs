namespace DRRCore.Application.DTO.Core.Request
{
    public class AddOrUpdateAnniversaryRequestDto
    {
        public int Id { get; set; }

        public string? Name { get; set; }

        public string StartDate { get; set; }

        public string EndDate { get; set; }     
    }
}

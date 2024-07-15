namespace DRRCore.Application.DTO.Core.Response
{
    public class GetAnniversaryResponseDto
    {
        public int Id { get; set; }
        public string Name { get; set; } =string.Empty;
        public string ShortDate { get; set; } = string.Empty;
        public string StartDate { get; set; } = string.Empty;
        public string EndDate { get; set; } = string.Empty;
        public bool Enable { get; set; }
    }
    public class GetListAnniversaryResponseDto
    {
        public string? Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public DateTime? Start { get; set; } 
        public DateTime? End { get; set; }
        public string? ClassName { get; set; } = string.Empty;
        public string? GroupId { get; set; } = string.Empty; 
        public string? Details { get; set; } = string.Empty;
    }

}

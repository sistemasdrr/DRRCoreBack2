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
}

namespace DRRCore.Application.DTO.Core.Request
{
    public class AddOrUpdatePersonImagesRequestDto
    {
        public int Id { get; set; }

        public int? IdPerson { get; set; }

        public string? ImgDesc1 { get; set; }

        public string? Path1 { get; set; }

        public string? ImgDesc2 { get; set; }

        public string? Path2 { get; set; }

        public string? ImgDesc3 { get; set; }

        public string? Path3 { get; set; }

        public List<TraductionDto> Traductions { get; set; } = new List<TraductionDto>();
    }
}

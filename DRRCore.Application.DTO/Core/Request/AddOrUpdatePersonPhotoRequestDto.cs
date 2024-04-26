namespace DRRCore.Application.DTO.Core.Request
{
    public class AddOrUpdatePersonPhotoRequestDto
    {
        public int Id { get; set; }

        public int? IdPerson { get; set; }

        public int? NumImg { get; set; }

        public string? Base64 { get; set; }

        public string? Description { get; set; }

        public string? DescriptionEng { get; set; }

        public bool? PrintImg { get; set; }

    }
}

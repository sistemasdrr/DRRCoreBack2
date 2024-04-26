namespace DRRCore.Application.DTO.Core.Response
{
    public class GetCompanyPartnersResponseDto
    {
        public int Id { get; set; }

        public int? IdCompany { get; set; }

        public int? IdPerson { get; set; }

        public bool? MainExecutive { get; set; }

        public string? Profession { get; set; }

        public int? Participation { get; set; }

        public string? StartDate { get; set; }

    }
}

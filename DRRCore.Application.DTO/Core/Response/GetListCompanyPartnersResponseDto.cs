namespace DRRCore.Application.DTO.Core.Response
{
    public class GetListCompanyPartnersResponseDto
    {
        public int Id { get; set; }

        public int? IdCompany { get; set; }

        public int? IdPerson { get; set; }

        public string? Name { get; set; }

        public string? Nationality { get; set; }

        public string? BirthDate { get; set; }
        
        public string? IdentificationDocument { get; set; }

        public bool? MainExecutive { get; set; }

        public string? Profession { get; set; }

        public int? Participation { get; set; }

        public string? StartDate { get; set; }

    }
}
